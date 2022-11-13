﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_Propagation_Implementaion
{
    class BackPropV2
    {
        private static readonly Random random = new Random();
        public delegate void OnTrainingComplete(float[][][] newWeights , float[] output);
        public event OnTrainingComplete OnTrainingCompleteEventHandeler;

        public delegate void OnTestComplete(float[] results);
        public event OnTestComplete OnTestCompleteEventHandeler;


        ///first section is the number of the layer
        ///second is the number of the node at that layer
        readonly private float[][] values;
        ///first section is the number of the layer
        ///second is the number of the node at that layer
        readonly private float[] biases;
        ///first section is the number of the layer
        ///second is describe what node is the weight connectd to
        ///third is describe what node is the weight connectd from
        readonly private float[][][] weights;

        readonly private float[][] targetValues;

        public const float learinigRate = 0.1f;
        /// <summary>
        /// this initailize the network tree by giving each node random
        /// weight 
        /// </summary>
        /// <param name="structure">this parameter for the structure it self
        /// for example 1 2 3 1 
        /// 1 is the input layer and it has 1 node
        /// 2 is the first hidden layer and it has 2 nodes
        /// 3 is the second hidden layer and it has 3 nodes
        /// 1 is the output layer and it has 1 nodes</param>
        public BackPropV2(IReadOnlyList<int> structure)
        {
            values = new float[structure.Count][];
            biases = new float[structure.Count];
            targetValues = new float[structure.Count][];
            weights = new float[structure.Count - 1][][];

            //here we put how many nodes on each layer
            //for example layer one has 2 nodes and so on.....
            for (int i = 0; i < structure.Count; i++)
            {
                values[i] = new float[structure[i]];
                targetValues[i] = new float[structure[i]];
                //initailze random biases for each layer on network
                biases[i] = (float)(random.NextDouble() * Math.Sqrt(2f / biases.Length));
            }

            // here we define how many links on each weight layer to the other layers
            for (int i = 0; i < structure.Count - 1; i++)
            {
                //we leave the first layer [ input layer ]
                // we are starting From the first hidden layer
                // for example the first hidden Layer has 3 nodes
                // we initialize them in the previuos for Loop
                weights[i] = new float[values[i + 1].Length][];


                // here we define what node is the weight stays in
                // so we already Know That eg: hidden layer 1 has 2 nodes
                // that means it has 2 weighs value
                for (int j = 0; j < weights[i].Length; j++)
                {
                    // this means how many lines does each node has
                    weights[i][j] = new float[values[i].Length];

                    //initialize random weight for each connection
                    for (int k = 0; k < weights[i][j].Length; k++)
                    {
                        weights[i][j][k] = (float)(random.NextDouble() * Math.Sqrt(2f / weights[i][j].Length));
                    }
                }
            }
        }

        /// <summary>
        /// here we calc the net of the current node
        /// v*w....... and so on..
        /// </summary>
        /// <param name="values"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        private static float Sum(IEnumerable<float> values, IReadOnlyList<float> weights)
        {
            return values.Select((v, i) => v * weights[i]).Sum();//v1*w1+v2*w2 and so on!!
        }

        /// <summary>
        /// here we get the output of the current node
        /// 1/1+e^-net
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static float Sigmoid(float x) => 1f / (1f + (float)Math.Exp(-x));

        private static float TanH(float x) => (float)Math.Tanh(x);

        private static float TanHDerivative(float x) => (float)(1 / Math.Pow(Math.Cosh(x), 2));


        //private static float HardSigmoid(float x)
        //{
        //    if(x< 2.5f)
        //    {
        //        return 0;
        //    }
        //    if(x> 2.5f)
        //    {
        //        return 1;
        //    }
        //    return 0.2f * x + 0.5f;
        //}


        /// <summary>
        /// Clac The Output Of each Node And Store them on value Arraty
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        private float[] CalcOutput(float[] inputs)
        {
            //set the inputs
            for (int i = 0; i < values[0].Length; i++)
            {
                values[0][i] = inputs[i];
            }

            // iterate over nodes
            // calc the output of the next layer
            for (int i = 1; i < values.Length; i++)
            {
                for (int j = 0; j < values[i].Length; j++)
                {
                    //calcualte their values
                    values[i][j] = TanH(Sum(values[i - 1], weights[i - 1][j]) + biases[i - 1]);
                    targetValues[i][j] = values[i][j];
                }
            }

            //return the output
            return values[values.Length - 1];
        }

        public void Train(float[][] trainigInputs, float[][] trainingOutputs)
        {
            for (int epoch = 0; epoch < 5000; epoch++)
            {
                for (int i = 1; i < trainigInputs.Length; i++)
                {
                    CalcOutput(trainigInputs[i - 1]);

                    // set correct/ target outputs of network
                    // here we get the last layer of "targetValues" and that is the last layer
                    // and set the "trainingOutput" to it
                    int outputLayerLength = targetValues[targetValues.Length - 1].Length;
                    for (int j = 0; j < outputLayerLength; j++)
                    {
                        targetValues[targetValues.Length - 1][j] = trainingOutputs[i][j];
                    }

                    // begin backpropagation process

                    for (int j = values.Length - 1; j >= 1; j--)
                    {
                        // iterate on evry node
                        for (int k = 0; k < values[j].Length; k++)
                        {
                            float error = targetValues[j][k] - values[j][k];
                            // store by how much we need to smudge the weight and bias
                            float biaseSmudge = TanHDerivative(values[j][k]) * error;

                            for (int l = 0; l < values[j - 1].Length; l++)
                            {
                                // j - 1 is the output of the previous layer so the Derivative 
                                // error will be the error * the current output * the output of the previous layer
                                float weightSmudge = values[j - 1][l] * biaseSmudge;
                                weights[j - 1][k][l] += -weightSmudge * learinigRate;
                                // adjust the weights of the current wieght line
                                // float valueSmudge = weights[j - 1][k][l] * biaseSmudge ;
                                // store the correct / desired value of the previous layer
                                //targetValues[j - 1][l] += valueSmudge;
                            }
                        }
                    }
                }
            }

            OnTrainingCompleteEventHandeler?.Invoke(weights, values[values.Length - 1]);
        }

        public void Test(float[] inputs)
        {

            ////iterate over nodes
            //for (int i = 0; i < inputs.Length; i++)
            //{
            //    for (int j = 0; j < inputs[i].Length; j++)//todo come here
            //    {
            //        //calcualte their values
            //        inputs[i][j] = Sigmoid(Sum(values[i], weights[i][j]));// + biases[i][j]);
            //    }
            //}
            //set the inputs
            for (int i = 0; i < values[0].Length; i++)
            {
                values[0][i] = inputs[i];
            }

            // iterate over nodes
            // calc the output of the next layer
            for (int i = 1; i < values.Length; i++)
            {
                for (int j = 0; j < values[i].Length; j++)
                {
                    //calcualte their values
                    values[i][j] = Sigmoid(Sum(values[i - 1], weights[i - 1][j]) + biases[i - 1]);
                    targetValues[i][j] = values[i][j];
                }
            }

            //return the output
            OnTestCompleteEventHandeler?.Invoke(values[values.Length - 1]);
        }

        private static float SigmoidDerivative(float x) => x * (1 - x);
    }


}
