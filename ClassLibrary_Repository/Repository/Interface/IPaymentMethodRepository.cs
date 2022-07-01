using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface IPaymentMethodRepository
    {
        List<PaymentMethod> getAllPaymentMethod();
        void addPaymentMethod(PaymentMethod newpaymethod);
        bool updatePaymentMethod(PaymentMethod newpaymethod);
        bool deletePaymentMethod(int paymethodId);
        PaymentMethod getPaymentMethod(int paymethodId);
    }
}
