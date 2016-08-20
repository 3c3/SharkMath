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
    public partial class DescriptorFiller : Form
    {
        public DescriptorFiller(Form1 f, int i)
        {
            InitializeComponent();

            main = f;
            probIdx = i;

            ProblemGroup pg = main.groups[probIdx];

            if(pg!=null)
            {
                nProblemsTb.Text = pg.count.ToString();
                typeCbox.SelectedIndex = pg.type == ProblemType.Equation ? 0 : 1;

                ReducedSEquationDescriptor rsed = pg.desc;
                letterTb.Text = rsed.letter.ToString();
                powerTb.Text = rsed.power.ToString();
                maxPowerTb.Text = rsed.maxVisualPower.ToString();
                fracTb.Text = rsed.pFractions.ToString();
                pIrrTb.Text = rsed.pIrrational.ToString();
                transMinTb.Text = rsed.minTransformations.ToString();
                transMaxTb.Text = rsed.maxTransformations.ToString();

            }

            
        }

        private Form1 main;
        private int probIdx;

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

        private void DescriptorFiller_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProblemType pt = typeCbox.SelectedIndex == 0 ? ProblemType.Equation : ProblemType.Inequation;
            main.groups[probIdx] = new ProblemGroup(inputDescriptor(), int.Parse(nProblemsTb.Text), pt);
            this.Close();
        }
    }
}
