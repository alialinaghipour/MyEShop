using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.PersistenceEF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<Product> _set;
        public EFProductRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.Products;
        }

        public void Add(Product product)
        {
            _set.Add(product);
        }

        public async Task<int> CountProductByFilter(string filter)
        {
            return await _set.CountAsync(
                _ => EF.Functions.Like(_.Title, $"%{filter}%")
                || EF.Functions.Like(_.ShortDescription, $"%{filter}%")
                || EF.Functions.Like(_.Text, $"%{filter}%")
                );
        }

        public void Delete(Product product)
        {
            _set.Remove(product);
        }

        public async Task<Product> FindById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IList<GetAllProductDto>> GetAll(string filter,int skip, int take)
        {
            return await _set
                .Where(_ => 
                EF.Functions.Like(_.Title, $"%{filter}%")
                || EF.Functions.Like(_.ShortDescription, $"%{filter}%")
                || EF.Functions.Like(_.Text, $"%{filter}%"))
                .Skip(skip)
                .Take(take)
                .Select(_ => new GetAllProductDto
                {
                    ShortDescription = _.ShortDescription,
                    CreateData = _.CreateData,
                    Id = _.Id,
                    ImageName = _.ImageName,
                    Price = _.Price,
                    Text = _.Text,
                    Title = _.Title
                }).ToListAsync();
        }

        public async Task<IList<GetAllProductDto>> GetAll()
        {
            return await _set.Select(_ => new GetAllProductDto
            {
                ShortDescription = _.ShortDescription,
                CreateData = _.CreateData,
                Id = _.Id,
                ImageName = _.ImageName,
                Price = _.Price,
                Text = _.Text,
                Title = _.Title
            }).ToListAsync();
        }
    }
}
