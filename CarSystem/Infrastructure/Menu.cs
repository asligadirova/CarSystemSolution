using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Infrastructure
{
    public enum Menu : byte
    {  


        CarAdd = 1,
        CarEdit,
        CarRemove,
        CarSingle,
        CarsAll,


        BrandAdd,
        BrandEdit,
        BrandRemove,
        BrandSingle,
        BrandsAll,


        ModelAdd,
        ModelEdit,
        ModelRemove,
        ModelSingle,
        ModelsAll,
        All,
        Exit
    }
}
