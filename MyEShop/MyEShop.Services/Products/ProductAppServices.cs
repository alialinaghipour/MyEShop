using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
using MyEShop.Services.ProductGroups.Contracts;
using MyEShop.Services.ProductGroups.Exceptions;
using MyEShop.Services.Products.Exceptions;
using MyEShop.Services.ProductSelectedGroups;
using MyEShop.Services.ProductSelectedGroups.Exceptions;
using MyEShop.Services.ProductTags;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.Products
{
    public class ProductAppServices : ProductServices
    {
        private readonly UnitOfWork _unitofwork;
        private readonly ProductRepository _repository;
        private readonly ProductGroupRepository _productGroupRepository;
        private readonly ProductSelectedGroupRepository _productSelectedGroupRepository;
        private readonly ProductTagRepository _productTagRepository;

        public ProductAppServices(
            UnitOfWork unitofwork,
            ProductRepository repository,
            ProductGroupRepository productGroupRepository,
            ProductSelectedGroupRepository productSelectedGroupRepository,
            ProductTagRepository productTagRepository)
        {
            _unitofwork = unitofwork;
            _repository = repository;
            _productGroupRepository = productGroupRepository;
            _productSelectedGroupRepository = productSelectedGroupRepository;
            _productTagRepository = productTagRepository;
        }
        public async Task<int> Add(AddProductDto dto)
        {
            Product product = new Product()
            {
                Text = dto.Text,
                ShortDescription = dto.ShortDescription,
                Title = dto.Title,
                ImageName = "no",
                Price = dto.Price,
                CreateData = DateTime.Now
            };

            await AddProductSelectedGroups(dto.ProductSelectedGroupDtos, product);

            string[] tags = dto.ProductTags.Split(',');
            AddProductTags(product, tags);

            _repository.Add(product);
            await _unitofwork.Complate();
            return product.Id;
        }

        private void AddProductTags(Product product, string[] tags)
        {
            var productTags = new HashSet<ProductTag>();
            foreach (var item in tags)
            {
                productTags.Add(new ProductTag
                {
                    ProductId = product.Id,
                    Title = item.Trim()
                });
            }
            product.ProductTags = productTags;
        }

        private async Task AddProductSelectedGroups(IList<ProductSelectedGroupDto> productSelectedGroups, Product product)
        {
            var productSelectedgroups = new HashSet<ProductSelectedGroup>();
            foreach (var item in productSelectedGroups)
            {
                await CheckedExistsProductGroup(item.GroupId);
                productSelectedgroups.Add(new ProductSelectedGroup
                {
                    ProductGroupId = item.GroupId,
                    ProductId = product.Id
                });
            }
            product.ProductSelectedGroups = productSelectedgroups;
        }

        private async Task CheckedExistsProductGroup(int groupId)
        {
            if (!await _productGroupRepository.IsExistsById(groupId))
            {
                throw new ProductGroupNotFoundException();
            }
        }

        public async Task Update(int id, UpdateProductDto dto)
        {
            var product = await _repository.FindById(id);
            CheckedExistsProduct(product);
            product.Title = dto.Title;
            product.ShortDescription = dto.ShortDescription;
            product.Text = dto.Text;
            product.Price = dto.Price;

            DeleteProductSelectedGroups(product.ProductSelectedGroups);
            await AddProductSelectedGroups(dto.ProductSelectedGroupDtos, product);

            DeleteProductTags(product.ProductTags);
            AddProductTags(product, dto.ProductTags.Split(','));

            await _unitofwork.Complate();
        }

        private void DeleteProductTags(HashSet<ProductTag> productTags)
        {
            foreach (var item in productTags)
            {
                _productTagRepository.Delete(item);
            }
        }

        private void DeleteProductSelectedGroups(HashSet<ProductSelectedGroup> productSelectedGroups)
        {
            foreach (var item in productSelectedGroups)
            {
                _productSelectedGroupRepository.Delete(item);
            }
        }

        private void CheckedExistsProduct(Product product)
        {
            if (product == null)
            {
                throw new ProductNotFoundExecption();
            }
        }

        public async Task Delete(int id)
        {
            var product = await _repository.FindById(id);
            CheckedExistsProduct(product);
            _repository.Delete(product);
            await _unitofwork.Complate();
        }

        public async Task<GetByIdProductDto> GetById(int id)
        {
            var product = await _repository.FindById(id);
            CheckedExistsProduct(product);

            GetByIdProductDto getByIdProductDto = new GetByIdProductDto()
            {
                Id = product.Id,
                Text = product.Text,
                ShortDescription = product.ShortDescription,
                ImageName = product.ImageName,
                Price = product.Price,
                CreateData = product.CreateData,
                Title = product.Title
            };

            return getByIdProductDto;
        }

        public async Task<IList<GetAllProductDto>> GetAll(string filter, int pageId)
        {
            int countProducts = await _repository.CountProductByFilter(filter);

            int take = 2;

            if (take > countProducts)
                take = (int)Math.Ceiling((double)countProducts / 2);

            int totalPage = (int)Math.Ceiling((double)countProducts / take);

            if (pageId > totalPage)
                pageId = 1;

            int skip = (pageId - 1) * take;

            return await _repository.GetAll(filter,skip, take);
        }
    }
}
