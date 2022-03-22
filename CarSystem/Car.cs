﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem
{
    public class Car
    {
        static int counter = 0;

        public Car()
        {
            this.Id = ++counter;
        }

        public int Id { get; private set; }
        public int ModelId { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public double Engine { get; set; }
        public DateTime Year { get; set; }
        
        public enum FuelType 
        {
            Automatic=1,
            Mechanic

        }

        public override string ToString()
        {
            return $"{Id}. {Color} {Price} {Engine}  {Year:yyyy} ModelId:{ModelId}";
        }

    }
}   
