using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class PublisherRepository: IPublisherRepository
    {
        private readonly BookEcommerceContext _context;
        public PublisherRepository(BookEcommerceContext context) => _context = context;
        public PublisherRepository()
        {
            _context = new BookEcommerceContext();
        }
        public void addPublisher(Publisher newpub)
        {
            try
            {
                _context.Publishers.Add(newpub);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool deletePublisher(int pubId)
        {
            Publisher publisher = _context.Publishers.Find(pubId);
            if (publisher != null)
            {
                try
                {
                    _context.Publishers.Remove(publisher);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public List<Publisher> getAllPublisher()
        {
            List<Publisher> publishers = _context.Publishers.ToList();
            return publishers;
        }
        public Publisher getDetailPublisher(int pubId)
        {
            Publisher publisher = _context.Publishers.Find(pubId);
            return publisher;
        }

        public List<Publisher> searchPub(string keyword)
        {
            List<Publisher> publishers = _context.Publishers.Where(p => p.Publishname.Contains(keyword)).ToList();
            return publishers;
        }

        public bool updatePublisher(Publisher newpub)
        {
            Publisher publisher = _context.Publishers.SingleOrDefault(publisher => publisher.Id.Equals(newpub.Id));
            if (publisher != null)
            {
                try
                {
                    publisher.Publishname = newpub.Publishname;
                    //_context.Publishers.Update(publisher);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
    }
}
