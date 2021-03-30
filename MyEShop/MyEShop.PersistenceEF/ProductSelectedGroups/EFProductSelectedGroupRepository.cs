using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.ProductSelectedGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.PersistenceEF.ProductSelectedGroups
{
    public class EFProductSelectedGroupRepository: ProductSelectedGroupRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductSelectedGroup> _set;
        public EFProductSelectedGroupRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.ProductSelectedGroups;
        }

        public void Add(ProductSelectedGroup productSelectedGroup)
        {
            _set.Add(productSelectedGroup);
        }

        public void Delete(ProductSelectedGroup productSelectedGroup)
        {
            _set.Remove(productSelectedGroup);
        }

        public async Task<ProductSelectedGroup> FindById(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IList<GetAllProductSelectedGroupDto>> GetAll()
        {
            return await _set
                .Include(_ => _.Product)
                .Include(_ => _.ProductGroup)
                .Select(_ => new GetAllProductSelectedGroupDto
                {
                    Id = _.Id,
                    ProductId = _.ProductId,
                    ProductTitle = _.Product.Title,
                    ProductGroupId = _.ProductGroupId,
                    GroupTitle = _.ProductGroup.Title
                }).ToListAsync();
        }

        public async Task<bool> IsExistsByProductIdAndGroupId(int productId, int groupId)
        {
            return await _set.AnyAsync(_ => _.ProductId == productId && _.ProductGroupId == groupId);
        }

        
    }
}
