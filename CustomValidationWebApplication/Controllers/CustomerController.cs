using CustomValidationWebApplication.Model;
using CustomValidationWebApplication.Services;
using CustomValidationWebApplication.Validations;
using Microsoft.AspNetCore.Mvc;

namespace CustomValidationWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly CustomerValidator _customerValidator;

        public CustomerController(ICustomerService customerService, CustomerValidator customerValidator)
        {
            _customerService = customerService;
            _customerValidator = customerValidator;
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var validationResult = _customerValidator.Validate(customer);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _customerService.AddCustomer(customer);

            return Ok();
        }

    }
}
