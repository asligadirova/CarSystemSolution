using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Managers
{
    internal class BrandManager
    {
        Brand[] data = new Brand[0];


        public void Add(Brand entity)
        {
            int len = data.Length;
            Array.Resize(ref data, len + 1);
            data[len] = entity;
        }

        public Brand[] GetAll()
        {
            return data;
        }
}    }
