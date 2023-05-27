using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample_DotNetCore_WebAPI.Data.Entities
{
    //Sayantan
    //create below POCO class that represents our table
    public class Gadgets
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public decimal Cost { get; set; }
        public string Type { get; set; }
    }
}
