using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem
{
   public class Brand
    {
        static int counter;
        public Brand()
        {
            this.Id = ++counter;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
       

        public override string ToString()
        {
            return $"{Id}. Marka: {Name} ";
        }
    }
}
