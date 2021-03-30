using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.ProductSelectedGroups;
using System;
using System.Collections.Generic;
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

        public async Task<bool> IsExistsByProductIdAndGroupId(int productId, int groupId)
        {
            return await _set.AnyAsync(_ => _.ProductId == productId && _.ProductGroupId == groupId);
        }

        
    }
}
