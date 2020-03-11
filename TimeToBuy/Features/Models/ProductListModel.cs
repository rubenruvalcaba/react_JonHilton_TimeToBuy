using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeToBuy.Features
{
    public class ProductListModel
    {
        public List<ProductListItem> Products { get; set; } = new List<ProductListItem>();

        public class ProductListItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}