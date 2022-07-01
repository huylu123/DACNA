using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using ClassLibrary_RepositoryDLL.Models;
using AutoMapper;

namespace ClassLibrary_RepositoryDLL.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;
        public CartItemService(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public List<ProductModel> getAllBook()
        {
            var products = _mapper.Map<List<ProductModel>>(_repo.getAllBook());
            return products;
        }
        public ProductModel getDetailBook(int bookId)
        {
            var productModel = _mapper.Map<ProductModel>(_repo.getDetailBook(bookId));
            return productModel;
        }
    }
}
