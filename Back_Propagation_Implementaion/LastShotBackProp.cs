using System;

namespace Back_Propagation_Implementaion
{
    class LastShotBackProp
    {
        public delegate void OnTrainingComplete(Layer[] results);
        public event OnTrainingComplete OnTrainingCompleteEventHandeler;

        public delegate void OnTestComplete(float[] results);
        public event OnTestComplete OnTestCompleteEventHandeler;

        private int[] layers;
        private Layer[] layersC;
        public LastShotBackProp(int [] layers, float learnRate)
        {
            this.layers = new int[layers.Length];

            for (int i = 0; i < layers.Length; i++)
            {
                this.layers[i] = layers[i];
            }
            layersC = new Layer[layers.Length - 1];

            for (int i = 0; i < layersC.Length; i++)
            {
                layersC[i] = new Layer(layers[i], layers[i + 1], learnRate);
            }
        }

        /// <summary>
        /// this Function Returns The Outputs Of The Network
        /// and FeedForward The Inputs (Forward Propagation)
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        private float[] ClacOutput(float[] inputs)
        {
            layersC[0].FeedForward(inputs);

            for (int i = 1; i < layersC.Length; i++)
            {
                layersC[i].FeedForward(layersC[i - 1].Outputs);
            }

            return layersC[layersC.Length - 1].Outputs;
        }

        public void Test(float[] inputs)
        {
            layersC[0].FeedForward(inputs);

            for (int i = 1; i < layersC.Length; i++)
            {
                layersC[i].FeedForward(layersC[i - 1].Outputs);
            }

            OnTestCompleteEventHandeler?.Invoke(layersC[layersC.Length - 1].Outputs);
        }

        public void StartTraining(float[][] inputs, float[][] expectedOutputs)
        {
            for (int epoch = 0; epoch < 5000; epoch++)
            {
                for (int inputNum = 0; inputNum < inputs.Length; inputNum++)
                {
                    Train(inputs[inputNum], expectedOutputs[inputNum]);
                }
            }
            OnTrainingCompleteEventHandeler?.Invoke(this.layersC);
        }

        /// <summary>
        /// This Function Train The Givin Network With Givin Data
        /// </summary>
        /// <param name="inputs">This The Inputs Of The First Layer(InputLayer)</param>
        /// <param name="expectedOutputs">This is The Target Output Of The Givivn Inputs</param>
        private void Train(float[] inputs, float[] expectedOutputs)
        {
            ClacOutput(inputs);
            BackProp(expectedOutputs);
        }

        private void BackProp(float[] expected)
        {
            for (int i = layersC.Length - 1; i >= 0; i--)
            {
                if(i == layersC.Length - 1)
                {
                    layersC[i].BackPropOutput(expected);
                }
                else
                {
                    layersC[i].BackPropHidden(layersC[i + 1].Gammas, layersC[i + 1].Weights);
                }
            }

            for (int i = 0; i < layersC.Length; i++)
            {
                layersC[i].UpdateWeights();
            }
        }
    }

    public class Layer
    {
        // number of neuron of the previuos layer the incoming connection
        public int NumOfInputs { get; private set; }
        //number of neuron of the current layer
        public int NumOfOutputs { get; private set; }
        private static readonly Random random = new Random();

        public float[] Inputs { get; private set; }
        public float[] Outputs { get; private set; }
        public float[,] Weights { get; private set; }
        public float[,] WeightsDeltas { get; private set; }
        public float[] Gammas { get; private set; }
        public float[] Errors { get; private set; }
        public float LearninigRate { get; private set; } = 0.001f;

        public Layer(int numOfInputs, int numOfOutputs , float learningRate)
        {
            this.NumOfInputs = numOfInputs;
            this.NumOfOutputs = numOfOutputs;

            Inputs = new float[numOfInputs];
            Outputs = new float[numOfOutputs];

            Weights = new float[numOfOutputs, numOfInputs];
            WeightsDeltas = new float[numOfOutputs, numOfInputs];

            Gammas = new float[numOfOutputs];
            Errors = new float[numOfOutputs];

            this.LearninigRate = learningRate;

            InitializeWeights();
        }

        private void InitializeWeights()
        {
            for (int i = 0; i < NumOfOutputs; i++)
            {
                for (int j = 0; j < NumOfInputs; j++)
                {
                    Weights[i, j] = (float)random.NextDouble() - 0.5f;
                }
            }
        }

        private static float Sigmoid(float x) => 1f / (1f + (float)Math.Exp(-x));

        private static float TanH(float x) => (float)Math.Tanh(x);

        private static float SigmoidDerivative(float x) => x * (1 - x);

        private static float TanHDerivative(float x) => (float)(1 / Math.Pow(Math.Cosh(x), 2));

        /// <summary>
        /// this fucion calc the output of the current layer 
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        public float[] FeedForward(float[] inputs)
        {
            this.Inputs = inputs;

            for (int i = 0; i < NumOfOutputs; i++)
            {
                Outputs[i] = 0;

                for (int j = 0; j < NumOfInputs; j++)
                {
                    Outputs[i] += inputs[j] * Weights[i, j];
                }
                // sigmoid function
                Outputs[i] = TanH(Outputs[i]);
            }
            return Outputs;
        }

        public void BackPropOutput(float [] target)
        {
            // Clac Error difference
            for (int i = 0; i < NumOfOutputs; i++)
            {
                Errors[i] = Outputs[i] - target[i];
            }
            // clac gamma which is error * Derivative of Current layer which is in this case
            // the output layer
            for (int i = 0; i < NumOfOutputs; i++)
            {
                Gammas[i] = Errors[i] * TanHDerivative(Outputs[i]);
            }
            // this calc how much we need to increase / decrease the weight
            // and we clac it by gamma * the output of the previous layer
            for (int i = 0; i < NumOfOutputs; i++)
            {
                for (int j = 0; j < NumOfInputs; j++)
                {
                    WeightsDeltas[i, j] = Gammas[i] * Inputs[j];
                }
            }
        }

        /// <summary>
        /// this function calc the correct weight for the hidden layers
        /// </summary>
        /// <param name="gammaForward">
        /// this is the gamma of the next layer 
        /// for example the gamma we calculate on output layer and so on
        /// </param>
        /// <param name="weightsForward">
        /// this is the updated weight of the next layer 
        /// for example the weights we update that connect to the output layer and so on
        /// </param>
        public void BackPropHidden(float [] gammaForward, float[,] weightsForward)
        {
            for (int i = 0; i < NumOfOutputs; i++)
            {
                Gammas[i] = 0;

                for (int j = 0; j < gammaForward.Length; j++)
                {
                    Gammas[i] += gammaForward[j] * weightsForward[j, i];
                }

                Gammas[i] *= TanHDerivative(Outputs[i]);
            }

            for (int i = 0; i < NumOfOutputs; i++)
            {
                for (int j = 0; j < NumOfInputs; j++)
                {
                    WeightsDeltas[i, j] = Gammas[i] * Inputs[j];
                }
            }
        }

        public void UpdateWeights()
        {
            // this is the magical touch where we update the weight of the curren connection
            for (int i = 0; i < NumOfOutputs; i++)
            {
                for (int j = 0; j < NumOfInputs; j++)
                {
                    Weights[i, j] -= WeightsDeltas[i, j] * LearninigRate;
                }
            }
        }

    }
}
