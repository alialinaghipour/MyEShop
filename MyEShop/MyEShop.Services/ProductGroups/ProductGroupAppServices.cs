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

        public ProductGroupAppServices(UnitOfWork unitOfWork, ProductGroupRepository repository)
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
                    ParentId = dto.ParentId
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

        public async Task Delete(int id)
        {
            var group = await _repository.FindById(id);
            CheckedExistsProductGroup(group);
            CheckedHsaSubGroup(group.ProductGroups.Count);
            _repository.Delete(group);
            await _unitOfWork.Complate();
        }

        public void CheckedHsaSubGroup(int subGroupCount)
        {
            if (subGroupCount > 0)
            {
                throw new ProductGroupHasSubGroupException();
            }
        }

        public async Task<IList<GetAllProductGroupDto>> GetAll()
        {
            var headGroups = await _repository.FindHeadGroups();

            IList<GetAllProductGroupDto> getAllProductGroupDtos = new List<GetAllProductGroupDto>();

            foreach (var item in headGroups)
            {
                getAllProductGroupDtos.Add(new GetAllProductGroupDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    CountSubGroups = item.ProductGroups.Count
                });
            }
            return getAllProductGroupDtos;
        }

        public async Task<GetByIdProductGroupDto> GetById(int id)
        {
            var group = await _repository.FindById(id);
            CheckedExistsProductGroup(group);

            IList<SubGroupDto> SubGroupsDto = new List<SubGroupDto>();
            foreach (var item in group.ProductGroups)
            {
                SubGroupsDto.Add(new SubGroupDto
                {
                    Id = item.Id,
                    Title = item.Title
                });
            }

            GetByIdProductGroupDto getByIdProductGroupDto = new GetByIdProductGroupDto()
            {
                Id = group.Id,
                Title = group.Title,
                SubGroupsDto = SubGroupsDto
            };

            return getByIdProductGroupDto;
        }

        public async Task Update(int id, UpdateProductGroupDto dto)
        {
            var group = await _repository.FindById(id);
            CheckedExistsProductGroup(group);
            if (dto.ParentId != 0)
            {
                group.Title = dto.Title;
                group.ParentId = dto.ParentId;
                await _unitOfWork.Complate();
            }
            group.Title = dto.Title;
            await _unitOfWork.Complate();
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
