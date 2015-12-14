using SharkMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharkGUI
{
    class App
    {
        public string Add(string a, string b)
        {
            Polynomial p1 = new Polynomial(a);
            Polynomial p2 = new Polynomial(b);
            Polynomial result = p1 + p2;
            return result.print(false, false);
        }
        public string Generate()
        {
            Polynomial p1 = new Polynomial("x2 - 3x + 5");
            Polynomial p2 = new Polynomial("x - 3");

            PolyNode pn1 = new PolyNode(p1);
            PolyNode pn2 = new PolyNode(p2);

            FracNode fn = new FracNode(pn1, pn2);
            return fn.print(false, false);
        }
        public string Show(string name)
        {
            MessageBox.Show("Hello " + name, "Greeter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return "Hello " + name;
        }
    }
}
