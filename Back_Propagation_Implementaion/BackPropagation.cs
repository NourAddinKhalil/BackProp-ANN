using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Back_Propagation_Implementaion
{
    public partial class BackPropagation : Form
    {
        //BackPropV2 backProp;
        LastShotBackProp backProp;
        List<int> networkLayers = new List<int>();
        float[][] trainingInput;
        float[][] trainingOutput;
        // readonly List<List<float>> inputLayers = new List<List<float>>();
        public BackPropagation()
        {
            InitializeComponent();
        }

        private float[] ConvertToArray(string[] stringArray)
        {
            float[] array = new float[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                array[i] = float.Parse(stringArray[i]);
            }

            return array;
        }
        
        private List<List<string>> SplitArrayAndConvertToList(string[] stringArray)
        {
            List<List<string>> listItem = new List<List<string>>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                string[] arr = stringArray[i].Split(',');
                listItem.Add(new List<string>());
                listItem[i].AddRange(arr.ToList());
                listItem[i].RemoveAll((x) => x == "");
            }
            listItem.RemoveAll((x) => x == null);

            return listItem;
        }

        private void FillTheLists()
        {
            int input = int.Parse(inputLayertxt.Text.Trim());
            int output = int.Parse(outputLayertxt.Text.Trim());
            List<string> hidden = hiddenLayertxt.Text.Split(',').ToList();
            hidden.RemoveAll((x) => x == "");
            List<string> tInputs = trainingInputTxt.Text.Split('/').ToList();
            tInputs.RemoveAll((x) => x == "");
            List<string> tOutput = trainingOutputTxt.Text.Split('/').ToList();
            tOutput.RemoveAll((x) => x == "");
            List<List<string>> trainInputList = SplitArrayAndConvertToList(tInputs.ToArray());
            List<List<string>> trainOutputList = SplitArrayAndConvertToList(tOutput.ToArray());
            List<int> hiddenList = new List<int>();
            trainingInput = new float[tInputs.Count][];
            trainingOutput = new float[tOutput.Count][];

            for (int i = 0; i < hidden.Count; i++)
            {
                hiddenList.Add(int.Parse(hidden[i].Trim()));
            }

            for (int i = 0; i < trainingInput.Length; i++)
            {
                trainingInput[i] = ConvertToArray(trainInputList[i].ToArray());
            }

            for (int i = 0; i < trainingOutput.Length; i++)
            {
                trainingOutput[i] = ConvertToArray(trainOutputList[i].ToArray());
            }

            networkLayers.Add(input);
            networkLayers.AddRange(hiddenList);
            networkLayers.Add(output);
        }

        private bool CheckIfTheSame(float[][] arr, int length)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length != length)
                    return false;
            }
            return true;
        }
        private void TrainBtn_Click(object sender, EventArgs e)
        {
            networkLayers = new List<int>();
            FillTheLists();
            correctedWeightTxt.Clear();
            outputTxt.Clear();

            if(trainingInput.Length != trainingOutput.Length)
            {
                MessageBox.Show("The Inputs And The Outputs Aren't The Same Length", "Fail To Train", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            float learnRate = float.Parse(learnRateTxt.Text.Trim());
            bool same = CheckIfTheSame(trainingInput, int.Parse(inputLayertxt.Text.Trim())) &&
                        CheckIfTheSame(trainingOutput, int.Parse(outputLayertxt.Text.Trim()));
            if (!same)
            {
                MessageBox.Show("Check Out The Input And The Output Length", "Fail To Train", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            backProp = new LastShotBackProp(networkLayers.ToArray(), learnRate);
            backProp.OnTestCompleteEventHandeler += BackProp_OnTestCompleteEventHandeler;
            backProp.OnTrainingCompleteEventHandeler += BackProp_OnTrainingCompleteEventHandeler;
            backProp.StartTraining(trainingInput, trainingOutput);

            //backProp = new BackPropV2(networkLayers);

            //backProp.OnTrainingCompleteEventHandeler += BackProp_OnTrainingCompleteEventHandeler;
            //backProp.OnTestCompleteEventHandeler += BackProp_OnTestCompleteEventHandeler;

            //backProp.Train(trainingInput, trainingOutput);
        }

        private void BackProp_OnTrainingCompleteEventHandeler(Layer[] results)
        {
            int counter = 1;
            for (int layer = 0; layer < results.Length; layer++)
            {
                for (int i = 0; i < results[layer].NumOfOutputs; i++)
                {
                    for (int j = 0; j < results[layer].NumOfInputs; j++)
                    {
                        float weight = results[layer].Weights[i, j];
                        correctedWeightTxt.Text += $"Layer : {layer + 1} , Node : {i + 1} , W  {counter++} : {weight}" + Environment.NewLine;
                    }
                }
            }

            //float[] output = results[results.Length - 1].Outputs;

            //for (int i = 0; i < output.Length; i++)
            //{
            //    outputTxt.Text += $"The Output : {i + 1} : {output[i]} ," + Environment.NewLine;
            //}
        }
        int calledNum = 0;
        private void BackProp_OnTestCompleteEventHandeler(float[] results)
        {
            for (int i = 0; i < results.Length; i++)
            {
                outputTxt.Text += $"The Output : {++calledNum} : {results[i]} ," + Environment.NewLine;
            }
        }

        //private void BackProp_OnTestCompleteEventHandeler(float[] results)
        //{
        //    //correctedWeightTxt.Clear();
        //    for (int i = 0; i < results.Length; i++)
        //    {
        //        //for (int j = 0; j < results[i].Length; j++)
        //        //{
        //        //    correctedWeightTxt.Text += $"Input Number : {i + 1} , Node : {j + 1} , Output : {results[i][j]}" + Environment.NewLine;
        //        //}
        //        outputTxt.Text += $"The Output : {i + 1} : {results[i]} ," + Environment.NewLine;
        //    }
        //}

        //private void BackProp_OnTrainingCompleteEventHandeler(float[][][] newWeights, float[] output)
        //{
        //    correctedWeightTxt.Clear();
        //    int counter = 1;
        //    for (int i = 0; i < newWeights.Length; i++)
        //    {
        //        for (int j = 0; j < newWeights[i].Length; j++)
        //        {
        //            for (int k = 0; k < newWeights[i][j].Length; k++)
        //            {
        //                correctedWeightTxt.Text += $"Layer : {i + 1} , Node : {j + 1} , W  {counter++} : {newWeights[i][j][k]}" + Environment.NewLine;
        //            }
        //        }
        //    }
        //    outputTxt.Clear();
        //    for (int i = 0; i < output.Length; i++)
        //    {
        //        outputTxt.Text += $"The Output : {output[i]} ," + Environment.NewLine;
        //    }
        //}

        private void TestBtn_Click(object sender, EventArgs e)
        {
            if(backProp == null)
            {
                MessageBox.Show("The Network Didn't Get Any Training", "Fail To Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            calledNum = 0;
            List<string> tInputs = trainingInputTxt.Text.Split('/').ToList();
            tInputs.RemoveAll((x) => x == "");
            List<List<string>> trainInputList = SplitArrayAndConvertToList(tInputs.ToArray());
            trainingInput = new float[tInputs.Count][];
            outputTxt.Clear();

            for (int i = 0; i < trainingInput.Length; i++)
            {
                trainingInput[i] = ConvertToArray(trainInputList[i].ToArray());
            }

            for (int i = 0; i < trainingInput.Length; i++)
            {
                backProp.Test(trainingInput[i]);
            }
        }

    }
}
