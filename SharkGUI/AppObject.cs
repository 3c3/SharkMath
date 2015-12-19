using SharkMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharkGUI
{
    class AppObject
    {

        public AppObject()
        {
            simpleEquationDescriptor = new SimpleEquationDescriptor();
        }
        public SimpleEquationDescriptor simpleEquationDescriptor
        {
            get;
            set;
        }
        public void test(Dictionary<string, Object> o){
            Console.WriteLine(o);
            foreach (KeyValuePair<string, Object> kvp in o) {
                Console.WriteLine("row: {0} , {1}", kvp.Key , kvp.Value);
                var A = kvp.Value as Object[];
                if(A != null){
                    foreach (Object obj in A) {
                        Console.WriteLine("sub_value: {0}", obj);
                    }
                }
            }
        }
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
        public void Show(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
