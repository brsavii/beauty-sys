using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Objects.Reponses;
using Domain.Objects.Requests;

namespace Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateCustomer(CreateCustomerRequest createCustomerRequest)
        {
            var customer = new Customer
            {
                Name = createCustomerRequest.Name,
                Phone = createCustomerRequest.Phone,
                Description = createCustomerRequest.Description,
                InsertedAt = DateTime.Now
            };

            await _customerRepository.SaveAsync(customer);
        }

        public async Task DeleteCustomer(int id) => await _customerRepository.Delete(id);

        public async Task<CustomerResponse> GetById(int id)
        {
            var customers = await _customerRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum cliente encontrado.");

            var customerResponse = new CustomerResponse(customers.CustomerId, customers.Name, customers.Phone, customers.Description);

            return customerResponse;
        }

        public async Task<List<CustomerResponse>> GetCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();

            var customerResponse = new List<CustomerResponse>();

            foreach (var customer in customers)
            {
                customerResponse.Add(new CustomerResponse(customer.CustomerId, customer.Name, customer.Phone, customer.Description));
            }

            return customerResponse;
        }

        public async Task UpdateCustomer(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            var customer = await _customerRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum cliente encontrado.");

            if (updateCustomerRequest.Name != null)
                customer.Name = updateCustomerRequest.Name;

            if (updateCustomerRequest.Phone != null)
                customer.Phone = updateCustomerRequest.Phone;

            if (updateCustomerRequest.Description != null)
                customer.Description = updateCustomerRequest.Description;

            customer.UpdatedAt = DateTime.Now;

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
