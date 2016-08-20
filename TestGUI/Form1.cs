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

        private int nSet = 0;
        int idx = 0;
        public ProblemGroup[] groups = new ProblemGroup[20];
        
        private void button3_Click(object sender, EventArgs e)
        {
            string exePath = System.Reflection.Assembly.GetEntryAssembly().Location;

            int len = 0;
            int pidx = 0;
            for(int i = exePath.Length - 1; i >= 0; i--) if(exePath[i]=='\\')
                {
                    pidx = i;
                    len = exePath.Length - i;
                    break;
                }
            exePath = exePath.Remove(pidx, len);

            //MessageBox.Show(exePath);
            OutputType t = OutputType.All;

            if (comboBox1.SelectedIndex == 0) t = OutputType.ProblemsOnly;
            else if (comboBox1.SelectedIndex == 1) t = OutputType.SolutionsOnly;

            int varCount = int.Parse(varCountTb.Text);

            for(int v = 1; v <= varCount; v++)
            {
                ts = new TestMaker(dirTb.Text, String.Format("{0}-{1}", fileNameTb.Text, v), t, exePath);

                int total = 0;
                for (int i = 0; i < idx; i++) total += groups[i].count;

                UiData[] data = new UiData[total];

                int dIdx = 0;
                for (int i = 0; i < idx; i++)
                {
                    UiData[] current;
                    if (groups[i].type == ProblemType.Equation) current = UiConnection.getEquations(groups[i].count, groups[i].desc);
                    else current = UiConnection.getInequations(groups[i].count, groups[i].desc);

                    for (int j = 0; j < current.Length; j++) data[dIdx + j] = current[j];
                    dIdx += current.Length;
                }

                ts.AddData(data);
                ts.createTex();
            }
            MessageBox.Show("Вашите задачи са генерирани и се намират в папка " + dirTb.Text);  
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Add("група задачи " + (idx+1).ToString() + " - неконфигурирани");
            idx++;
            generateBtn.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int sidx = listBox1.SelectedIndex;
            if(sidx != -1)
            {
                bool willChange = false;
                if (groups[sidx] == null) willChange = true;

                DescriptorFiller df = new DescriptorFiller(this, sidx);
                df.ShowDialog();
                if (willChange) nSet++;
                if(nSet == idx)
                {
                    generateBtn.Enabled = true;
                }
                
            }

            listBox1.Items[sidx] = "група задачи " + (sidx + 1).ToString() + " - OK";
        }

        private void dirTb_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                dirTb.Text = folderDialog.SelectedPath;
            }
        }
    }
}
