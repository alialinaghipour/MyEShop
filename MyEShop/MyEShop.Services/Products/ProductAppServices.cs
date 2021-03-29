using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
using MyEShop.Services.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.Products
{
    public class ProductAppServices : ProductServices
    {
        private readonly UnitOfWork _unitofwork;
        private readonly ProductRepository _repository;

        public ProductAppServices(UnitOfWork unitofwork,ProductRepository repository)
        {
            _unitofwork = unitofwork;
            _repository = repository;
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

            _repository.Add(product);
            await _unitofwork.Complate();
            return product.Id;
        }


        public async Task Update(int id, UpdateProductDto dto)
        {
            var product = await _repository.FindById(id);
            CheckedExistsProduct(product);
            product.Title = dto.Title;
            product.ShortDescription = dto.ShortDescription;
            product.Text = dto.Text;
            product.Price = dto.Price;
            await _unitofwork.Complate();
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

        public async Task<IList<GetAllProductDto>> GetAll(string filter, int pageId,int take)
        {
            int countProducts = await _repository.CountProductByFilter(filter);

            if (take > countProducts)
                take = (int)Math.Ceiling((double)countProducts / 2);

            int totalPage = (int)Math.Ceiling((double)countProducts / take);

            if (pageId > totalPage)
                pageId = 1;

            int skip = (pageId - 1) * take;

            return await _repository.GetAll(filter,skip, take);
        }

        public async Task<IList<GetAllProductDto>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
