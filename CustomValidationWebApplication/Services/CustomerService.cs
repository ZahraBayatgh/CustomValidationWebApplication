using CustomValidationWebApplication.Model;

namespace CustomValidationWebApplication.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly List<Customer> Customers = new List<Customer>
         {
             new()
             {
                 FullName = "Zahra Bayat",
                 Email = "BytZahra@gmail.Com",
                 Age = 19,
             },
             new Customer()
             {
                 FullName = "Sara Smith",
                 Email = "Sara.Smith@gmail.Com",
                 Age = 25,
             },
             new Customer()
             {
                 FullName = "Jeo Deu",
                 Email = "Jeo.Deu@gmail.Com",
                Age = 39,
             },
         };
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
        public Customer? GetByEmail(string email)
        {
            var customerDto = Customers.FirstOrDefault(x => x.Email == email);
            return customerDto;
        }
    }

}
