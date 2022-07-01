using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using ClassLibrary_RepositoryDLL.Mappings;
using ClassLibrary_RepositoryDLL.Models;
using AutoMapper;

namespace ClassLibrary_RepositoryDLL.Services
{
    public class MenuService : IMenuService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public MenuService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public List<Category> getAllCategories()
        {
            return _repo.getAllCategory();
        }
    }
}