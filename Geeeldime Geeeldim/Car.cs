using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geeeldime_Geeeldim
{
    [Serializable]
    class Car
    {
        private static int count = 0;
        public Car()
        {
            this.Id = ++count;
        }
        static public void SetCounter(int count)
        {
            Car.count = count;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Engine { get; set; }
        public int Year { get; set; }
        public int BanNo { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public int Mileage { get; set; }
        public double Price { get; set; }
        public int ModelId { get; set; }
        public override string ToString()
        {
            return $"||  ModelId: {ModelId} ||  Car Name: {Name} || Car Id: {Id} || Car Year: {Year} || Car Engine: {Engine} ||" +
               $"\n|| Car Transmission: {Transmission} || Car Color: {Color} || Car Price: {Price} || Car BanNo: {BanNo} || Car MileAge: {Mileage} ||" +
               $"\n************************************************************************************************************************";
                
                
        }

    }
}
