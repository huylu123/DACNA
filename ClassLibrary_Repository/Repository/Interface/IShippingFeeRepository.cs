using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface IShippingFeeRepository
    {
        List<ShippingFee> getAllShippingFee();
        void addShippingFee(ShippingFee newshippingfee);
        bool updateShippingFee(ShippingFee newshippingfee);
        bool deleteShippingFee(int shippingfeeId);
        ShippingFee getShippingFee(int shippingfeeId);
    }
}
