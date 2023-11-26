﻿using Domain.Interfaces.Repositories;
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
            if (createCustomerRequest.Phone.Length != 11)
                throw new InvalidOperationException("Telefone inválido");

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

        public ICollection<CustomerResponse> GetCustomers(int currentPage, int takeQuantity = 10)
        {
            var customers = _customerRepository.GetAll(currentPage, takeQuantity);

            if (!customers.Any())
                throw new InvalidOperationException("Nenhum cliente encontrado");

            var customerResponse = new List<CustomerResponse>();

            foreach (var customer in customers)
            {
                customerResponse.Add(new CustomerResponse(customer.CustomerId, customer.Name, customer.Phone, customer.Description));
            }

            return customerResponse;
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
