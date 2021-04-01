using MyEShop.Entities;
using MyEShop.Infrastructure.Application;
using MyEShop.Services.ProductComments.Exceptions;
using MyEShop.Services.Products;
using MyEShop.Services.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEShop.Services.ProductComments
{
    public class ProductCommnetAppServices : ProductCommentServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductCommentRepository _repository;
        private readonly ProductRepository _productRepository;

        public ProductCommnetAppServices(
            UnitOfWork unitOfWork,
            ProductCommentRepository repository,
            ProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _productRepository = productRepository;
        }
        public async Task<int> Add(int productId, AddCommmentDto dto)
        {
            var product = await _productRepository.FindById(productId);
            CheckedExistsProduct(product);

            ProductComment productComment = new ProductComment()
            {
                ProductId = product.Id,
                CreateDate = DateTime.Now,
                Comment = dto.Comment,
                Email = dto.Email,
                Name = dto.Name,
            };

            product.ProductComments.Add(productComment);
            await _unitOfWork.Complate();
            return productComment.Id;
        }

        private void CheckedExistsProduct(Product product)
        {
            if (product == null)
            {
                throw new ProductNotFoundExecption();
            }
        }

        public async Task<int> AddReplyComment(int commentId, AddCommmentDto dto)
        {
            var commnet = await _repository.FindById(commentId);
            CheckedExistsProductCommnet(commnet);

            ProductComment productComment = new ProductComment()
            {
                ProductId = commnet.ProductId,
                CreateDate = DateTime.Now,
                Comment = dto.Comment,
                Email = dto.Email,
                Name = dto.Name,
                ParentId = commnet.Id
            };

            var product = await _productRepository.FindById(commnet.ProductId);
            product.ProductComments.Add(productComment);

            await _unitOfWork.Complate();
            return productComment.Id;
        }

        private void CheckedExistsProductCommnet(ProductComment commnet)
        {
            if (commnet == null)
            {
                throw new CommentNotFoundException();
            }
        }
    }
}
