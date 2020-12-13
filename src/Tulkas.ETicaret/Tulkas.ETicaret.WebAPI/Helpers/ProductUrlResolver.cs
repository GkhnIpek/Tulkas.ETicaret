using AutoMapper;
using System;
using Microsoft.Extensions.Configuration;
using Tulkas.ETicaret.Core.DbModels;
using Tulkas.ETicaret.WebAPI.Dtos;

namespace Tulkas.ETicaret.WebAPI.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
