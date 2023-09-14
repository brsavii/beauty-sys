using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Objects.Reponses;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task DeleteCustomer(int id) => await _customerRepository.Delete(id);

        public async Task<CustomerResponse> GetById(int id)
        {
            var customers = await _customerRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum cliente encontrado.");

            var customerResponse = new CustomerResponse(customers.Name, customers.Phone, customers.Description);

            return customerResponse;
        }

        public async Task<List<CustomerResponse>> GetCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();

            var customerResponse = new List<CustomerResponse>();

            foreach (var customer in customers)
            {
                customerResponse.Add(new CustomerResponse(customer.Name, customer.Phone, customer.Description));
            }

            return customerResponse;
        }
    }
}
