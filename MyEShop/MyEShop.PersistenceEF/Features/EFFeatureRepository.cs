using Microsoft.EntityFrameworkCore;
using MyEShop.Entities;
using MyEShop.Services.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Delete(Feature feature)
        {
            _set.Remove(feature);
        }

        public async Task<Feature> FindById(int id)
        {
            return await _set
                .Include(_ => _.ProductFeatures)
                .SingleOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<IList<GetAllFeatureDto>> GetAll()
        {
            return await _set
                .Select(_ => new GetAllFeatureDto
                {
                    Id = _.Id,
                    Title = _.Title
                }).ToListAsync();
        }
    }
}
