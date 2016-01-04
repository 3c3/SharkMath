using SharkMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using SharkMath.MathProblems;

namespace SharkGUI
{
    class AppObject
    {
        private const int WM_NCHITTEST = 0x84;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private IntPtr Handle;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public void MoveWin()
        {
            Console.WriteLine("event: click");
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        public AppObject(IntPtr Handle)
        {
            this.Handle = Handle;
            simpleEquationDescriptor = new ReducedSEquationDescriptor();
        }
        public ReducedSEquationDescriptor simpleEquationDescriptor;

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
        public string Generate(Dictionary<string, Object> jsObject)
        {
            var desc_t = typeof(ReducedSEquationDescriptor);
            foreach(KeyValuePair<string,Object> field in jsObject){
                Console.WriteLine("Key: {0}, Type: {1}", field.Key, field.Value.GetType());
                if(field.Value is Int32){
                    Int32? val = field.Value as Int32?;
                    desc_t.GetField(field.Key).SetValue(simpleEquationDescriptor, (byte)val);

                }
                else if (field.Value is String)
                {
                    String val = field.Value as String;
                    var object_field = desc_t.GetField(field.Key);

                    if (object_field.FieldType == typeof(char))
                    {
                        desc_t.GetField(field.Key).SetValue(simpleEquationDescriptor, val[0]);
                    }
                    else {
                        desc_t.GetField(field.Key).SetValue(simpleEquationDescriptor, val);
                    }
                }
                else {
                    throw new Exception(String.Format("Unkonw data type of object {0} with type {1}", simpleEquationDescriptor, typeof(SimpleEquationDescriptor)));
                }

                
                
            }

            return Generator.getEquation(simpleEquationDescriptor.letter, simpleEquationDescriptor.toSEquationDescriptor()).print();
        }
        public void Show(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
