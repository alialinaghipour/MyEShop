using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.Features
{
    public interface FeatureServices
    {
        Task<int> Add(AddFeatureDto dto);
        Task Update(int id,UpdateFeatureDto dto);
        Task<IList<GetAllFeatureDto>> GetAll();

    }
}
