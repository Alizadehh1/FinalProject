using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geeeldime_Geeeldim
{
    [Serializable]
    class Model
    {
        private static int count = 0;
        public Model()
        {
            this.Id = ++count;
        }
        static public void SetCounter(int count)
        {
            Model.count = count;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarkaId { get; set; }

        public override string ToString()
        {
            return $"{Name} || Id: {Id}";
        }

    }
}
