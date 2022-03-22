using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem
{
    internal class Brand
    {
        static int counter = 0;

        public Brand()
        {
            this.Id = ++counter;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
       

        public override string ToString()
        {
            return $"{Id}. {Name} ";
        }
    }
}
