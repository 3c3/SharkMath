using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    /// <summary>
    /// Прави израза по-приличен, изкарава знаци и множители(коефициенти)
    /// </summary>
    interface ISimplifiable
    {
        void simplify();
    }
}
