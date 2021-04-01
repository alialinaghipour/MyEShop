using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEShop.PersistenceEF.Features
{
    public class EFFeatureRepository : FeatureRepository
    {
        private readonly EFDataContext _context;
        private readonly DbSet<Feature> _set;

        public EFFeatureRepository(EFDataContext context)
        {
            _context = context;
            _set = _context.Features;
        }

        public void Add(Feature feature)
        {
            _set.Add(feature);
        }
    }
}
