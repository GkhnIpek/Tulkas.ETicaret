using System.Collections.Generic;

namespace Tulkas.ETicaret.Core.DbModels
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; } 
    }
}
