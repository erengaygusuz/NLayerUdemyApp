﻿using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductsWithCategoryDto>>> GetProductsWithCategory()
        {
            var product = await _productRepository.GetProductsWithCategory();

            var productsDto = _mapper.Map<List<ProductsWithCategoryDto>>(product);

            return CustomResponseDto<List<ProductsWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
