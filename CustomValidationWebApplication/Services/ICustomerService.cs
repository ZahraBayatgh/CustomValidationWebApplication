using CustomValidationWebApplication.Model;

namespace CustomValidationWebApplication.Services
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        Customer? GetByEmail(string email);
    }

}
