using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly BookEcommerceContext _context;
        public CheckoutRepository(BookEcommerceContext context) => _context = context;
        public CheckoutRepository()
        {
            _context = new BookEcommerceContext();
        }

      

        public void addCheckout(Checkout newcheckout)
        {
            try
            {
                _context.Checkouts.Add(newcheckout);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool deleteCheckout(int checkoutId)
        {
            Checkout checkout = _context.Checkouts.Find(checkoutId);
            if (checkout != null)
            {
                try
                {
                    _context.Checkouts.Remove(checkout);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                }
            }
            return false;
        }

        public List<Checkout> getAllCheckout()
        {
            List<Checkout> checkouts = _context.Checkouts.ToList();
            return checkouts;
        }
      
       

        public Checkout getDetailCheckout(int checkoutId)
        {
            Checkout checkout = _context.Checkouts.Find(checkoutId);
            return checkout;
        }
        public List<Checkout> selectByCheckOutId(int CheckOutId)
        {
            List<Checkout> Checkouts = _context.Checkouts.Where(b => b.Id == CheckOutId).ToList();
            return Checkouts;
        }

        public bool updateCheckout(Checkout newcheckout)
        {
            Checkout checkout = _context.Checkouts.SingleOrDefault(checkout => checkout.Id == newcheckout.Id);
            if (checkout != null)
            {
                try
                {
                    checkout.Status = newcheckout.Status;
                    checkout.ShippingfeeId = newcheckout.ShippingfeeId;
                    checkout.Depositornumber = newcheckout.Depositornumber;
                    checkout.Receivernumber = newcheckout.Receivernumber;
                    checkout.PaymentId = newcheckout.PaymentId;
                    _context.Checkouts.Update(newcheckout);
                    _context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
    }
}
