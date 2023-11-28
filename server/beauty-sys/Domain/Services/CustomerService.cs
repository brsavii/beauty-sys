using AutoMapper;
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
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task CreateCustomer(CreateCustomerRequest createCustomerRequest) => await _customerRepository.SaveAsync(_mapper.Map<Customer>(createCustomerRequest));

        public async Task DeleteCustomer(int id) => await _customerRepository.Delete(id);

        public ICollection<CustomerResponse> GetCustomers(int currentPage, int takeQuantity, int? id, string? name)
        {
            var customers = _customerRepository.GetCustomers(currentPage, takeQuantity, id, name);

            if (!customers.Any())
                throw new InvalidOperationException("Nenhum cliente encontrado");

            return customers;
        }

        public async Task UpdateCustomer(int id, UpdateCustomerRequest updateCustomerRequest)
        {
            var customer = await _customerRepository.GetById(id) ?? throw new InvalidOperationException("Nenhum cliente encontrado");

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
