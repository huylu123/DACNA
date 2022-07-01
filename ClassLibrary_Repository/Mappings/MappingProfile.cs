using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Services;
using ClassLibrary_RepositoryDLL.Models;
using ClassLibrary_RepositoryDLL.Mappings;

namespace ClassLibrary_RepositoryDLL.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, ProductModel>().ForMember(destination => destination.Name, action => action.MapFrom(source => source.Bookname));
            CreateMap<Book, Author>().ForMember(destination => destination.Id, action => action.MapFrom(source => source.Id));
            //CreateMap<Book, Category>();
            //CreateMap<Book, Publisher>();
            //CreateMap<Book, Cart>();
            CreateMap<Book, CartItem>().ForMember(destination => destination.Book, action => action.MapFrom(source => source.Id));
            //CreateMap<Account, Cart>();
            //CreateMap<Account, Role>();
            //CreateMap<Account, Checkout>();
            //CreateMap<Checkout, Account>();
            //CreateMap<Checkout, PaymentMethod>();
            //CreateMap<Checkout, ShippingFee>();
        }
    }
}
