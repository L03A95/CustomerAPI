using CustomerAPI.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Repositories
{
    public class CustomerDatabaseContext : DbContext
    {
        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options) : base(options) 
        { 

        }


        public DbSet<CustomerModel> customer { get; set; }

        public async Task<CustomerModel> Get(long id)
        {
            return await customer.FirstAsync(x => x.id == id);
        }

        public async Task<CustomerModel> Add(CreateCustomerDto customerDto)
        {
            CustomerModel entity = new CustomerModel()
            {
                id = null,
                firstname = customerDto.FirstName,
                lastname = customerDto.LastName,
                email = customerDto.Email,
                phone = customerDto.Phone,
                address = customerDto.Address
            };

            EntityEntry<CustomerModel> response = await customer.AddAsync(entity);
            await SaveChangesAsync();

            return await Get(response.Entity.id ?? throw new Exception("No se ha podido guardar"));

        }
    }

    public class CustomerModel
    {
        public long? id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string address { get; set; }
    }
}
