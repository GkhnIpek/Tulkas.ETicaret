using Tulkas.ETicaret.Core.DbModels;

namespace Tulkas.ETicaret.Core.Specifications
{
    public class ProductWithTypeAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductWithTypeAndBrandSpecification(ProductSpecParams productSpecParams)
            : base(x =>
                 (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
                 &&
                 (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
                 &&
                 (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))

        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);

            ApplyingPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductWithTypeAndBrandSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
