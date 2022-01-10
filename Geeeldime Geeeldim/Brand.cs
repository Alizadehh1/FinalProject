using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geeeldime_Geeeldim
{
    [Serializable]
    class Brand
    {
        private static int count = 0;
        public Brand()
        {
            this.Id = ++count;
        }
        static public void SetCounter(int count)
        {
            Brand.count = count;
        }

        public int Id { get; set;}
        public string Name { get; set; }
        public override string ToString()
        {
            return $"|| Id: {Id} || Name: {Name} ||";
        }
    }
}
