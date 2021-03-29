using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
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
    }
}
