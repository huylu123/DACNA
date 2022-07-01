using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class ShippingFeeRepository: IShippingFeeRepository
    {
        private readonly BookEcommerceContext _context;
        public ShippingFeeRepository(BookEcommerceContext context) =>  _context = context;

        public void addShippingFee(ShippingFee newshippingfee)
        {
            try
            {
                _context.ShippingFees.Add(newshippingfee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool deleteShippingFee(int shippingfeeId)
        {
            ShippingFee shippingfee = _context.ShippingFees.Find(shippingfeeId);
            if (shippingfee != null)
            {
                try
                {
                    _context.ShippingFees.Remove(shippingfee);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public List<ShippingFee> getAllShippingFee()
        {
            List<ShippingFee> shippingfees = _context.ShippingFees.ToList();
            return shippingfees;
        }
        public ShippingFee getShippingFee(int shippingfeeId)
        {
            ShippingFee shippingfee = _context.ShippingFees.Find(shippingfeeId);
            return shippingfee;
        }

        public bool updateShippingFee(ShippingFee newshippingfee)
        {
            ShippingFee shippingfee = _context.ShippingFees.SingleOrDefault(shippingfee => shippingfee.Id.Equals(newshippingfee.Id));
            if (shippingfee != null)
            {
                try
                {
                    _context.ShippingFees.Update(shippingfee);
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
