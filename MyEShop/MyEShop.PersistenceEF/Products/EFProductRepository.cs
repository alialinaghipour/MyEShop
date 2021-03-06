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
            return await _set
                .Where(_ => EF.Functions.Like(_.Title, $"%{filter}%")
                || EF.Functions.Like(_.ShortDescription, $"%{filter}%")
                || EF.Functions.Like(_.Text, $"%{filter}%"))
                .Distinct()
                .CountAsync();
        }

        public void Delete(Product product)
        {
            _set.Remove(product);
        }

        public async Task<Product> FindById(int id)
        {
            return await _set
                .Include(_=>_.ProductSelectedGroups)
                .Include(_=>_.ProductTags)
                .Include(_=>_.ProductGalleries)
                .Include(_=>_.ProductFeatures)
                .SingleOrDefaultAsync(_=>_.Id==id);
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
                })
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> IsExistsById(int id)
        {
            return await _set.AnyAsync(_ => _.Id == id);
        }
    }
}
