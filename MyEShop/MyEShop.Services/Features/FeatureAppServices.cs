using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
using MyEShop.Services.Features.Exceptions;
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

        public FeatureAppServices(UnitOfWork unitOfWork, FeatureRepository repository)
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


        public async Task<IList<GetAllFeatureDto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Update(int id, UpdateFeatureDto dto)
        {
            var feature = await _repository.FindById(id);
            CheckedExistsFeature(feature);
            feature.Title = dto.Title.Trim();
            await _unitOfWork.Complate();
        }

        private void CheckedExistsFeature(Feature feature)
        {
            if (feature == null)
            {
                throw new FeatureNotFoundException();
            }
        }
        public async Task Delete(int id)
        {
            var feature = await _repository.FindById(id);
            CheckedExistsFeature(feature);
            CheckedProductFeatureToFeature(feature.ProductFeatures.Count);
            _repository.Delete(feature);
            await _unitOfWork.Complate();
        }

        public void CheckedProductFeatureToFeature(int productFeatureCount)
        {
            if (productFeatureCount > 0)
            {
                throw new FeatureNotDeleteException();
            }
        }
    }
}
