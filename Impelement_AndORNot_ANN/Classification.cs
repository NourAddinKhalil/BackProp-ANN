using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Impelement_AndORNot_ANN
{
    public partial class Classification : Form
    {
        CalcGates calcGates;
        public Classification()
        {
            InitializeComponent();
            calcGates = new CalcGates();
        }

        readonly List<String> gates = new List<string>()
        {
             "And",
             "Or",
             "Not",
             "NAnd",
             "NOr",
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            gatesCmbBx.DataSource = gates;
        }

        private void CalcBtn_Click(object sender, EventArgs e)
        {
            calcGates = new CalcGates(gatesCmbBx.SelectedIndex + 1, w1NumUpDwn.Value,
                                      w2NumUpDwn.Value, threesholdNumUpDwn.Value,
                                      trainRateNumUpDwn.Value);
            calcGates.CalcFinishedHandeler += CalcGates_CalcFinishedHandeler;
            calcGates.InputErrorHandeler += CalcGates_InputErrorHandeler;
            calcGates.GetOutput();
        }

        private void CalcGates_InputErrorHandeler(string errorText)
        {
            errorLbl.Text = errorText;
        }

        private void CalcGates_CalcFinishedHandeler(decimal correctW1, decimal correctW2)
        {
            correctW1NumUpDwn.Value = correctW1;
            correctW2NumUpDwn.Value = correctW2;
        }
    }
}

class CalcGates
{
    public delegate void ClacFinished(decimal correctW1, decimal correctW2);
    public event ClacFinished CalcFinishedHandeler;
    public delegate void InputError(String errorText);
    public event InputError InputErrorHandeler;
    public int GateType { get; set; }
    public decimal Weight1 { get; set; }
    public decimal Weight2 { get; set; }
    public decimal Threeshold { get; set; }
    //public int Input1 { get; set; }
    //public int Input2 { get; set; }
    public decimal LearningRate { get; set; }

    private int[] expectedInputs1 = { 0, 0, 1, 1 };
    private int[] expectedInputs2 = { 0, 1, 0, 1 };

    public CalcGates()
    {

    }

    public CalcGates(int type, decimal w1, decimal w2, decimal threeshold, decimal learnRate)
    {
        this.GateType = type;
        this.Weight1 = w1;
        this.Weight2 = w2;
        this.Threeshold = threeshold;
        //this.Input1 = in1;
        //this.Input2 = in2;
        this.LearningRate = learnRate;
    }

    public void GetOutput()
    {
        if (this.GateType == 1)
        {
            CalcAnd();
        }
        else if (this.GateType == 2)
        {
            CalcOr();
        }
        else if (this.GateType == 3)
        {
            CalcNot();
        }
        else if (this.GateType == 4)
        {
            CalcNAnd();
        }
        else if (this.GateType == 5)
        {
            CalcNOr();
        }
    }

    private bool CheckForErrorDifference(double error)
    {
        if (error != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void CalcCorrectWieght(int[] expctedRes, bool oneInput = false)
    {
        if (oneInput)
        {
            for (int j = 0; j < expctedRes.Length; j++)
            {
                expctedRes[j] = Convert.ToInt32((expectedInputs2[j] == 0));
            }
        }

        int maxLoop = 0;
        int i = 0;
        int counter = 0;
        decimal oldW1 = 0;
        decimal oldW2 = 0;

        for (; ; )
        {
            decimal output = (this.Weight1 * (oneInput ? this.expectedInputs2[i] : this.expectedInputs1[i])) +
                            (oneInput ? 0 : (this.Weight2 * this.expectedInputs2[i]));
            int actualOutput = Convert.ToInt32(output >= this.Threeshold);

            if (CheckForErrorDifference(expctedRes[i] - actualOutput))
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
            oldW1 = this.LearningRate * (expctedRes[i] - actualOutput) *
                                               (oneInput ? expectedInputs2[i] : expectedInputs1[i]) + this.Weight1;
            if (!oneInput)
                oldW2 = this.LearningRate * (expctedRes[i] - actualOutput) * expectedInputs2[i] + this.Weight2;

            if (oldW1 == this.Weight1)
            {
                if (oneInput)
                {
                    InputErrorHandeler("You Need To Provide Another Inputs Values It Seems It's Endless Loop");
                    return;
                }
                else
                {
                    if (oldW2 == this.Weight2)
                    {
                        InputErrorHandeler("You Need To Provide Another Inputs Values It Seems It's Endless Loop");
                        return;
                    }
                }
            }

            this.Weight1 = oldW1;
            this.Weight2 = oldW2;

            if (counter == expctedRes.Length)
            {
                CalcFinishedHandeler(this.Weight1, oneInput ? 0 : this.Weight2);
                break;
            }

            i++;
            maxLoop++;
            if (i >= expctedRes.Length)
            {
                i = 0;
            }
            //if (maxLoop > 1000000)
            //{
            //    InputErrorHandeler("You Need To Provide Another Inputs Values It Seems It's Endless Loop");
            //    break;
            //}
        }
    }

    private void CalcAnd()
    {
        if (this.Threeshold < 0)
        {
            this.InputErrorHandeler("You Need To Provide Positave Threeshold Value");
            return;
        }
        int[] expctedRes = { 0, 0, 0, 1 };
        //int expectedOutput = GetExpectedOutput(expctedRes);
        CalcCorrectWieght(expctedRes);
    }

    private void CalcOr()
    {
        if (this.Threeshold < 0)
        {
            this.InputErrorHandeler("You Need To Provide Positave Threeshold Value");
            return;
        }
        int[] expctedRes = { 0, 1, 1, 1 };
        CalcCorrectWieght(expctedRes);
    }

    private void CalcNot()
    {

        if (this.Threeshold > 0)
        {
            this.InputErrorHandeler("You Need To Provide Negative Threeshold Value");
            return;
        }
        int[] expctedRes = { 0, 1 };
        CalcCorrectWieght(expctedRes, true);
    }

    private void CalcNAnd()
    {
        if (this.Threeshold > 0)
        {
            this.InputErrorHandeler("You Need To Provide Negative Threeshold Value");
            return;
        }
        int[] expctedRes = { 1, 1, 1, 0 };
        //int expectedOutput = GetExpectedOutput(expctedRes);
        CalcCorrectWieght(expctedRes);
    }

    private void CalcNOr()
    {
        if (this.Threeshold > 0)
        {
            this.InputErrorHandeler("You Need To Provide Negative Threeshold Value");
            return;
        }
        int[] expctedRes = { 1, 0, 0, 0 };
        CalcCorrectWieght(expctedRes);
    }
}
