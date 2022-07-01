using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface IPublisherRepository
    {
        List<Publisher> searchPub(string keyword);
        List<Publisher> getAllPublisher();
        void addPublisher(Publisher newpub);
        bool updatePublisher(Publisher newpub);
        bool deletePublisher(int pubId);
        Publisher getDetailPublisher(int pubId);
    }
}
