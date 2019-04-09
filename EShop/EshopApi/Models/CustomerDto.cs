﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopApi.Models
{
    public class CustomerDto
    {
        public CustomerDto(Customer customer)
        {
            CustomerId = customer.CustomerId;
            Name = customer.Name;
            City = customer.ContactInfo.City;
            Street = customer.ContactInfo.Street;
            Zip = customer.ContactInfo.Zip;
            Phone = customer.ContactInfo.Phone;
            Email = customer.ContactInfo.Email;
            Country = customer.ContactInfo.Country;
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public Customer ToCustomer()
        {
            return new Customer()
            {
                CustomerId = CustomerId,
                Name = Name,
                ContactInfo = CustomerId > 0 ? null : new ContactInfo() // Don't make a new ContactInfo if the customer is already persisted in the database
                {
                    City = City,
                    Zip = Zip,
                    Street = Street,
                    Phone = Phone,
                    Email = Email,
                    Country = Country
                }
            };
        }
    }
}
