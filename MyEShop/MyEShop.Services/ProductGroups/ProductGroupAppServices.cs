using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
using MyEShop.Services.ProductGroups.Contracts;
using MyEShop.Services.ProductGroups.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductGroups
{
    public class ProductGroupAppServices : ProductGroupServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductGroupRepository _repository;

        public ProductGroupAppServices(UnitOfWork unitOfWork,ProductGroupRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        
        public async Task<int> Add(AddProductGroupDto dto)
        {
            ProductGroup productGroup;
            if (dto.ParentId != 0)
            {
                var group = await _repository.FindById(dto.ParentId);
                CheckedExistsProductGroup(group);
                productGroup = new ProductGroup()
                {
                    Title = dto.Title,
                    ParentId=dto.ParentId
                };
                _repository.Add(productGroup);
                await _unitOfWork.Complate();
                return productGroup.Id;
            }
            productGroup = new ProductGroup()
            {
                Title = dto.Title,
            };
            _repository.Add(productGroup);
            await _unitOfWork.Complate();
            return productGroup.Id;
        }

        private void CheckedExistsProductGroup(ProductGroup productGroup)
        {
            if (productGroup == null)
            {
                throw new ProductGroupNotFoundException();
            }
        }
    }
}
