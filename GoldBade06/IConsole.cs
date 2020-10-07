using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBade03
{
        public interface IConsole
        {
            void WriteLine(string s);
            void WriteLine(object o);
            void Clear();
            string ReadLine();
            ConsoleKeyInfo ReadKey();
        }
}
