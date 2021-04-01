using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
using MyEShop.Services.Features;
using MyEShop.Services.Features.Exceptions;
using MyEShop.Services.Products;
using MyEShop.Services.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductFeatures
{
    public class ProductFeatureAppServices : ProductFeatureServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductFeatureRepository _repository;
        private readonly FeatureRepository _featureRepository;
        private readonly ProductRepository _productRepository;

        public ProductFeatureAppServices(
            UnitOfWork unitOfWork,
            ProductFeatureRepository repository,
            FeatureRepository featureRepository,
            ProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _featureRepository = featureRepository;
            _productRepository = productRepository;
        }

        public async Task<int> Add(int productId, AddProductFeatureDto dto)
        {
            await CheckedExistsProduct(productId);
            await CheckedExistsFeature(dto.FeatureId);
            ProductFeature productFeature = new ProductFeature()
            {
                Value = dto.Value.Trim(),
                FeatureId = dto.FeatureId,
                ProductId = productId
            };
            _repository.Add(productFeature);
            await _unitOfWork.Complate();
            return productFeature.Id;
        }

        private async Task CheckedExistsFeature(int featureId)
        {
            if (!await _featureRepository.IsExistsById(featureId))
            {
                throw new FeatureNotFoundException();
            }
        }

        private async Task CheckedExistsProduct(int productId)
        {
            if (!await _productRepository.IsExistsById(productId))
            {
                throw new ProductNotFoundExecption();
            }
        }
    }
}
