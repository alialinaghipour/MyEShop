using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.ProductComments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.PersistenceEF.ProductComments
{
    public class EFProductCommentRepository : ProductCommentRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductComment> _set;

        public EFProductCommentRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.ProductComments;
        }

        public async Task<ProductComment> FindById(int id)
        {
            return await _set.FindAsync(id);
        }
    }
}
