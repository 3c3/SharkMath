using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    /// <summary>
    /// Добавя към текущия елемент, променяйки го
    /// </summary>
    interface IAddable
    {
        /// <summary>
        /// Добавя, не променя аргумента
        /// </summary>
        /// <param name="arg"></param>
        void Add(Node arg);
    }
}
