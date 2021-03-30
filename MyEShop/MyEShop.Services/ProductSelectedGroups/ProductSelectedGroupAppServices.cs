using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
using MyEShop.Services.ProductGroups.Contracts;
using MyEShop.Services.ProductGroups.Exceptions;
using MyEShop.Services.Products;
using MyEShop.Services.Products.Exceptions;
using MyEShop.Services.ProductSelectedGroups.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductSelectedGroups
{
    public class ProductSelectedGroupAppServices : ProductSelectedGroupServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductSelectedGroupRepository _repository;
        private readonly ProductRepository _productRepository;
        private readonly ProductGroupRepository _productGroupRepository;

        public ProductSelectedGroupAppServices(
            UnitOfWork unitOfWork,
            ProductSelectedGroupRepository repository,
            ProductRepository productRepository,
            ProductGroupRepository productGroupRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
        }

        public async Task<int> Add(AddProdcutSelectedGroupDto dto)
        {
            await CheckedExistsProduct(dto.ProductId);
            await CheckedExistsProductGroup(dto.ProductGroupId);
            await CheckedExistsProductIdAndGroupId(dto.ProductId, dto.ProductGroupId);

            ProductSelectedGroup productSelectedGroup = new ProductSelectedGroup()
            {
                ProductId = dto.ProductId,
                ProductGroupId = dto.ProductGroupId
            };

            _repository.Add(productSelectedGroup);
            await _unitOfWork.Complate();
            return productSelectedGroup.Id;
        }

        private async Task CheckedExistsProduct(int producId)
        {
            if (!await _productRepository.IsExistsById(producId))
            {
                throw new ProductNotFoundExecption();
            }
        }

        private async Task CheckedExistsProductGroup(int groupId)
        {
            if (!await _productGroupRepository.IsExistsById(groupId))
            {
                throw new ProductGroupNotFoundException();
            }
        }

        private async Task CheckedExistsProductIdAndGroupId(int productId, int groupId)
        {
            if (await _repository.IsExistsByProductIdAndGroupId(productId, groupId))
            {
                throw new ExistsProductIdToGroupIdException();
            }
        }
    }
}
