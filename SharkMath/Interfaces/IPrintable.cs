using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public interface IPrintable
    {
        /// <summary>
        /// Принтира
        /// </summary>
        /// <param name="attach">дали да рисува знака като за слепване</param>
        /// <param name="brackets">дали да е в скоби</param>
        /// <returns>Принтираното нещо</returns>
        string print(bool attach, bool brackets);
    }
}
