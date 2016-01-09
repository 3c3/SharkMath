using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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

        public TestMaker(string path, string fileName, OutputType t)
        {
            dirPath = path;
            this.fileName = fileName;
            type = t;
        }

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

        public void createTex()
        {
            if (type == OutputType.ProblemsOnly)
            {
                File.WriteAllText(String.Format("{0}\\{1}.tex", dirPath, fileName), header + contentProblems + footer);
                Process.Start("pdflatex", String.Format("\"{0}\\{1}.tex\"", dirPath, fileName));
            }
            else if (type == OutputType.ProblemsOnly)
            {
                File.WriteAllText(String.Format("{0}\\{1}.tex", dirPath, fileName), header + contentSolutions + footer);
            }
            else
            {
                File.WriteAllText(String.Format("{0}\\{1}_problems.tex", dirPath, fileName), header + contentProblems + footer);
                File.WriteAllText(String.Format("{0}\\{1}_solutions.tex", dirPath, fileName), header + contentSolutions + footer);
            }
        }
    }
}
