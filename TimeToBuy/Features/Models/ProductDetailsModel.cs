using System;
using System.Linq;

namespace TimeToBuy.Features
{
    public class ProductDetailsModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}