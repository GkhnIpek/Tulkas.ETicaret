using System.Collections.Generic;

namespace Tulkas.ETicaret.Core.DbModels
{
    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
