using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tulkas.ETicaret.Core.DbModels;
using Tulkas.ETicaret.Core.Interfaces;
using Tulkas.ETicaret.Core.Specifications;
using Tulkas.ETicaret.WebAPI.Dtos;
using Tulkas.ETicaret.WebAPI.Helpers;

namespace Tulkas.ETicaret.WebAPI.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository, IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<Pagination<ProductDto>>> GetAllProducts([FromQuery] ProductSpecParams productSpecParams)
        {
            var spec = new ProductWithTypeAndBrandSpecification(productSpecParams);
            var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);
            var totalItems = await _productRepository.CountAsync(spec);
            var products = await _productRepository.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            return Ok(new Pagination<ProductDto>(productSpecParams.PageIndex, productSpecParams.PageSize, totalItems, data));
        }

        [HttpGet("GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var spec = new ProductWithTypeAndBrandSpecification(id);
            var product = await _productRepository.GetEntityWithSpec(spec);
            var result = _mapper.Map<Product, ProductDto>(product);
            return Ok(result);
        }

        [HttpGet("GetAllProductBrand")]
        public async Task<ActionResult<List<ProductBrand>>> GetAllProductBrand()
        {
            var data = await _productRepository.ListAllAsync();
            return Ok(data);
        }

        [HttpGet("GetAllProductType")]
        public async Task<ActionResult<List<ProductType>>> GetAllProductType()
        {
            var data = await _productRepository.ListAllAsync();
            return Ok(data);
        }
    }
}
