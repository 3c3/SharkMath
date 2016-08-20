using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using SharkMath;

namespace TestGUI
{
    public enum OutputType
    {
        ProblemsOnly, SolutionsOnly, All
    }

    public class TestMaker
    {
        public string dirPath;
        public string fileName;
        private OutputType type;
        private static string header = tex_template.header;
        private static string footer = tex_template.footer;

        public TestMaker(string path, string fileName, OutputType t, string ePath)
        {
            dirPath = path;
            this.fileName = fileName;
            type = t;
            exePath = ePath;
        }

        private string exePath = "";
        private string contentProblems = "";
        private string contentSolutions = "";
        private int countP = 1;
        private int countS = 1;

        private void AddLineProblem(string line)
        {
            contentProblems+=String.Format("{0}. ${1}$ \\\\\n", countP, line);
            countP++;
        }

        private void AddLineSolution(string line)
        {
            contentSolutions+=String.Format("{0}. ${1}$ \\\\\n", countS, line);
            countS++;
        }

        public void AddData(UiData[] uid)
        {
            if(type == OutputType.ProblemsOnly) foreach(UiData ud in uid) AddLineProblem(ud.problem);
            else if(type == OutputType.SolutionsOnly) foreach(UiData ud in uid) AddLineSolution(ud.solution);
            else foreach(UiData ud in uid)
            {
                AddLineProblem(ud.problem);
                AddLineSolution(ud.solution);
            }
        }

        void convertToPdf(string file)
        {
            Process convertProc = new Process();

            convertProc.StartInfo.FileName = "pdflatex";
            convertProc.StartInfo.Arguments = String.Format("\"{0}.tex\"", file);
            convertProc.StartInfo.CreateNoWindow = true;

            convertProc.Start();
            convertProc.WaitForExit();

            string pdfFile = String.Format("{0}.pdf", file);
            string newLoc = String.Format("{0}\\{1}.pdf", dirPath, file);
            File.Copy(pdfFile, newLoc, true);
        }

        public void createTex()
        {
            if (type == OutputType.ProblemsOnly)
            {
                File.WriteAllText(String.Format("{0}.tex", fileName), header + contentProblems + footer);
                convertToPdf(fileName);
                
            }
            else if (type == OutputType.ProblemsOnly)
            {
                File.WriteAllText(String.Format("{0}.tex", fileName), header + contentSolutions + footer);
                convertToPdf(fileName);
            }
            else
            {
                File.WriteAllText(String.Format("{0}_problems.tex", fileName), header + contentProblems + footer);
                convertToPdf(String.Format("{0}_problems", fileName));

                File.WriteAllText(String.Format("{0}_solutions.tex", fileName), header + contentSolutions + footer);
                convertToPdf(String.Format("{0}_solutions", fileName));
            }
        }
    }
}
