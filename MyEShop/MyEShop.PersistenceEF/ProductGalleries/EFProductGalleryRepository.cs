using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.ProductGalleries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.ProductGalleries
{
    public class EFProductGalleryRepository : ProductGalleryRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<ProductGallery> _set;

        public EFProductGalleryRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.ProductGalleries;
        }
        public void Add(ProductGallery productGallery)
        {
            _set.Add(productGallery);
        }
    }
}
