using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly BookEcommerceContext _context;
        public PaymentMethodRepository(BookEcommerceContext context) => _context = context;
        public void addPaymentMethod(PaymentMethod newpaymethod)
        {
            try
            {
                _context.PaymentMethods.Add(newpaymethod);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool deletePaymentMethod(int paymethodId)
        {
            PaymentMethod payment = _context.PaymentMethods.Find(paymethodId);
            if(payment != null)
            {
                try
                {
                    _context.PaymentMethods.Remove(payment);
                    _context.SaveChanges();
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public List<PaymentMethod> getAllPaymentMethod()
        {
            List<PaymentMethod> payments = _context.PaymentMethods.ToList();
            return payments;
        }

        public PaymentMethod getPaymentMethod(int paymethodId)
        {
            PaymentMethod payment = _context.PaymentMethods.Find(paymethodId);
            return payment;
        }

        public bool updatePaymentMethod(PaymentMethod newpaymethod)
        {
            PaymentMethod payment = _context.PaymentMethods.SingleOrDefault(payment => payment.Id.Equals(newpaymethod.Id));
            if (payment != null)
            {
                try
                {
                    payment.Paymentname = newpaymethod.Paymentname;
                    _context.PaymentMethods.Update(payment);
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
