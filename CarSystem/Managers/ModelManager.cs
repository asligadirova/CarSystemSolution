using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Managers
{
    internal class ModelManager
    {
        Model[] data = new Model[0];


        public void Add(Model entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public Model[] GetAll()
        {
            return data;
        }
    }
}
