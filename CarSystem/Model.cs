using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem
{
    public class Model
    {
        static int counter ;

        public Model()
        {
            this.Id =++ counter;
        }
        public int Id { get; private set; }
        public int ModelId { get; set; }
        public string Name{ get; set; }
        

        public override string ToString()
        {
            return $"{Id}. {Name} (ModelId: {ModelId})";
        }
    }
}
