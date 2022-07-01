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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repo;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public List<Author> getAllAuthor()
        {
            return _repo.getAllAuthor();
        }
    }
}