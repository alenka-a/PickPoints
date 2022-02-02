using FluentValidation.TestHelper;
using PickPoints.Core.Models;
using PickPoints.Core.Validators;
using Xunit;

namespace PickPoints.Tests.ValidatorsTest
{
    public class CreateOrderRequestValidatorTests
    {
        private CreateOrderRequestValidator _validator;

        public CreateOrderRequestValidatorTests()
        {
            _validator = new CreateOrderRequestValidator();
        }

        [Fact]
        public void Should_Have_Error_When_RecipientPhone_Is_Null()
        {
            var model = new CreateOrderRequest() 
            {  
                Cost = 10,
                Goods = new string[] { "товар1"},
                PostampNumber = "1",
                RecipientFullname = ""
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.RecipientPhone);
        }

        [Fact]
        public void Should_Not_Have_Error_When_RecipientPhone_Is_NonCorrect()
        {
            var model = new CreateOrderRequest()
            {
                RecipientPhone = "+7(312)9090000000"
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.RecipientPhone);
        }

        [Fact]
        public void Should_Not_Have_Error_When_RecipientPhone_Is_Correct()
        {
            var model = new CreateOrderRequest()
            { 
                RecipientPhone = "+7909-000-00-00"
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.RecipientPhone);
        }

        [Fact]
        public void Should_Have_Error_When_PostampNumber_Is_Null()
        {
            var model = new CreateOrderRequest()
            {
                RecipientPhone = "+7909-000-00-00"                
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.PostampNumber);
        }

        [Fact]
        public void Should_Not_Have_Error_When_PostampNumber_Is_NonCorrect()
        {
            var model = new CreateOrderRequest()
            {
                RecipientPhone = "+7909-000-00-00",
                PostampNumber = "11"
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.PostampNumber);
        }

        [Fact]
        public void Should_Not_Have_Error_When_PostampNumber_Is_Correct()
        {
            var model = new CreateOrderRequest()
            {
                RecipientPhone = "+7909-000-00-00",
                PostampNumber = "1111-111"
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.PostampNumber);
        }
    }
}
