using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharkMath;
using SharkMath.MathProblems;

namespace TestGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TestMaker ts;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = folderDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dirTb.Text = folderDialog.SelectedPath;
            }
        }

        
        private ReducedSEquationDescriptor inputDescriptor()
        {
            ReducedSEquationDescriptor rsed = new ReducedSEquationDescriptor();
            rsed.letter = letterTb.Text[0];
            rsed.maxTransformations = byte.Parse(transMaxTb.Text);
            rsed.maxVisualPower = byte.Parse(maxPowerTb.Text);
            rsed.minTransformations = byte.Parse(transMinTb.Text);
            rsed.pFractions = byte.Parse(fracTb.Text);
            rsed.pIrrational = byte.Parse(pIrrTb.Text);
            rsed.power = byte.Parse(powerTb.Text);
            return rsed;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OutputType t = OutputType.All;

            if (comboBox1.SelectedIndex == 0) t = OutputType.ProblemsOnly;
            else if (comboBox1.SelectedIndex == 1) t = OutputType.SolutionsOnly;

            ts = new TestMaker(dirTb.Text, fileNameTb.Text, t);

            UiData[] data = UiConnection.getEquations(int.Parse(nProblemsTb.Text), inputDescriptor());
            ts.AddData(data);
            ts.createTex();
        }
    }
}
