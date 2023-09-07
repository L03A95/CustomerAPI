using CustomerAPI.Dtos;
using CustomerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerDatabaseContext _customerDatabaseContext;

        public CustomerController(CustomerDatabaseContext customerDatabaseContext)
        {
            _customerDatabaseContext = customerDatabaseContext;
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
        public async Task<IActionResult> GetCustomer(long id)
        {
            var vacio = new CustomerDto();
            
            return new OkObjectResult(vacio);
        }

        [HttpGet]
        public async Task<List<CustomerDto>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]

        public async Task<IActionResult> PostCustomer(CreateCustomerDto customer)
        {
            CustomerModel result = await _customerDatabaseContext.Add(customer);

            return new CreatedResult($"http://localhost:7089/api/customer/{result.id}", null);
        }
    }
}
