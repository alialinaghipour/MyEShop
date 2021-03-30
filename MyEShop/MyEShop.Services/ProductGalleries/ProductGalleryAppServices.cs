using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
using MyEShop.Services.Products;
using MyEShop.Services.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductGalleries
{
    public class ProductGalleryAppServices : ProductGalleryServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductGalleryRepository _repository;
        private readonly ProductRepository _productRepository;

        public ProductGalleryAppServices(
            UnitOfWork unitOfWork,
            ProductGalleryRepository repository,
            ProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<int> Add(AddProductGalleryDto dto)
        {
            await CheckedExistsProduct(dto.ProductId);

            ProductGallery productGallery = new ProductGallery()
            {
                ImageName = dto.ImageName,
                ProductId = dto.ProductId,
                Title = dto.Title
            };

            _repository.Add(productGallery);
            await _unitOfWork.Complate();
            return productGallery.Id;
        }

        private async Task CheckedExistsProduct(int producId)
        {
            if (!await _productRepository.IsExistsById(producId))
            {
                throw new ProductNotFoundExecption();
            }
        }
    }
}
