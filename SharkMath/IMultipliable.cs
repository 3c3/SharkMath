using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    /// <summary>
    /// Променя самият елемент, като го умножава
    /// </summary>
    interface IMultipliable
    {
        /// <summary>
        /// Умножава по елемент
        /// </summary>
        /// <param name="arg">Умножителят</param>
        void Multiply(Node arg);
    }
}
