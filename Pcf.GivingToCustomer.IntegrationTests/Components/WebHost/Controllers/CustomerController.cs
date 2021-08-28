using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Pcf.GivingToCustomer.Core.Domain;
using Pcf.GivingToCustomer.DataAccess.Repositories;
using Pcf.GivingToCustomer.WebHost.Controllers;
using Pcf.GivingToCustomer.WebHost.Models;
using Xunit;

namespace Pcf.GivingToCustomer.IntegrationTests.Components.WebHost.Controllers
{
   public class CustomersControllerTests: IClassFixture<MongoDatabaseFixture>
    {
        private readonly CustomersController _customersController;
        private readonly MongoRepository<Customer> _customerRepository;
        private readonly MongoRepository<Preference> _preferenceRepository;
        
        public CustomersControllerTests(MongoDatabaseFixture databaseFixture)
        {
            _customerRepository = new MongoRepository<Customer>(
                databaseFixture.CustomerCollection, databaseFixture.MongoSession);
            _preferenceRepository = new MongoRepository<Preference>(
                databaseFixture.PreferenceCollection, databaseFixture.MongoSession);
            
            _customersController = new CustomersController(
                _customerRepository, 
                _preferenceRepository);
        }
        
        [Fact]
        public async Task CreateCustomerAsync_CanCreateCustomer_ShouldCreateExpectedCustomer()
        {
            //Arrange 
            var preferenceId = Guid.Parse("ef7f299f-92d7-459f-896e-078ed53ef99c");
            var request = new CreateOrEditCustomerRequest()
            {
                Email = "some@mail.ru",
                FirstName = "Иван",
                LastName = "Петров",
                PreferenceIds = new List<Guid>()
                {
                    preferenceId
                }
            };

            //Act
            var result = await _customersController.CreateCustomerAsync(request);
            var actionResult = result.Result as CreatedAtActionResult;
            var id = (Guid)actionResult.Value;
            
            //Assert
            var actual = await _customerRepository.GetByIdAsync(id);
            
            actual.Email.Should().Be(request.Email);
            actual.FirstName.Should().Be(request.FirstName);
            actual.LastName.Should().Be(request.LastName);
            actual.Preferences.Should()
                .ContainSingle()
                .And
                .Contain(x => x.Id == preferenceId);
        }
    }
}
