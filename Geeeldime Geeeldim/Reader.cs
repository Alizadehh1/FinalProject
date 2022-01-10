using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geeeldime_Geeeldim
{
    class Reader
    {
        public static int ReadInteger(string caption)
        {
            int a;
            Console.Write(caption);
            a = Convert.ToInt32(Console.ReadLine());
            return a;
        }
        public static string ReadString(string caption)
        {
        l1:
            Console.Write(caption);
            string value = Console.ReadLine();
            if (string.IsNullOrEmpty(value))
                goto l1;
            return value;
        }
    }
}
