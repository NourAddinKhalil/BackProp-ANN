using System;

namespace BackPropagationXor
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Train();
        //}

        class Sigmoid
        {
            public static double Output(double x)
            {
                return 1.0 / (1.0 + Math.Exp(-x));
            }

            public static double Derivative(double x)
            {
                return x * (1 - x);
            }
        }

        class Neuron
        {
            public double[] inputs = new double[2];
            public double[] weights = new double[2];
            public double error;

            private double biasWeight;

            private Random r = new Random();

            public double Output
            {
                get
                {
                    return Sigmoid.Output(weights[0] * inputs[0] + weights[1] * inputs[1] + biasWeight);
                }
            }

            public void RandomizeWeights()
            {
                weights[0] = r.NextDouble();
                weights[1] = r.NextDouble();
                biasWeight = r.NextDouble();
            }

            public void AdjustWeights()
            {
                weights[0] += error * inputs[0];
                weights[1] += error * inputs[1];
                biasWeight += error;
            }
        }

        private static void Train()
        {
            // the input values
            double[,] inputs =
            {
                { 0, 0},
                { 0, 1},
                { 1, 0},
                { 1, 1}
            };

            // desired results
            double[] results = { 0, 1, 1, 0 };

            // creating the neurons
            Neuron hiddenNeuron1 = new Neuron();
            Neuron hiddenNeuron2 = new Neuron();
            Neuron outputNeuron = new Neuron();

            // random weights
            hiddenNeuron1.RandomizeWeights();
            hiddenNeuron2.RandomizeWeights();
            outputNeuron.RandomizeWeights();

            int epoch = 0;

            RETRY:
            epoch++;
            for (int i = 0; i < 4; i++)  // very important, do NOT train for only one example
            {
                // 1) forward propagation (calculates output)
                hiddenNeuron1.inputs = new double[] { inputs[i, 0], inputs[i, 1] };
                hiddenNeuron2.inputs = new double[] { inputs[i, 0], inputs[i, 1] };

                outputNeuron.inputs = new double[] { hiddenNeuron1.Output, hiddenNeuron2.Output };

                Console.WriteLine("{0} xor {1} = {2}", inputs[i, 0], inputs[i, 1], outputNeuron.Output);

                // 2) back propagation (adjusts weights)

                // adjusts the weight of the output neuron, based on its error
                outputNeuron.error = Sigmoid.Derivative(outputNeuron.Output) * (results[i] - outputNeuron.Output);
                outputNeuron.AdjustWeights();

                // then adjusts the hidden neurons' weights, based on their errors
                hiddenNeuron1.error = Sigmoid.Derivative(hiddenNeuron1.Output) * outputNeuron.error * outputNeuron.weights[0];
                hiddenNeuron2.error = Sigmoid.Derivative(hiddenNeuron2.Output) * outputNeuron.error * outputNeuron.weights[1];

                hiddenNeuron1.AdjustWeights();
                hiddenNeuron2.AdjustWeights();
            }

            if (epoch < 2000)
                goto RETRY;

            Console.ReadLine();
        }
    }
}