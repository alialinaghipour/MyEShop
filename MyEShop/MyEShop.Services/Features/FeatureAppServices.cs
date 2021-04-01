using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.Features
{
    public class FeatureAppServices : FeatureServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly FeatureRepository _repository;

        public FeatureAppServices(UnitOfWork unitOfWork,FeatureRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<int> Add(AddFeatureDto dto)
        {
            Feature feature = new Feature()
            {
                Title = dto.Title.Trim()
            };
            _repository.Add(feature);
            await _unitOfWork.Complate();
            return feature.Id;
        }
    }
}
