using MyEShop.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.Features
{
    public interface FeatureRepository
    {
        void Add(Feature feature);
        Task<Feature> FindById(int id);
        Task<IList<GetAllFeatureDto>> GetAll();
    }
}
