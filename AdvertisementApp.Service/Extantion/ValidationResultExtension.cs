using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.ResponseObject;

namespace Udemy.AdvertisementApp.Service.Extantion
{
    public static class ValidationResultExtension
    {
        public static List<CustomValidationError> CustomValidationError(this ValidationResult result)
        {
            List < CustomValidationError > errors = new List < CustomValidationError >();
            foreach (var error in result.Errors)
            {
                errors.Add(
                new CustomValidationError()
                {
                    PropertyName = error.PropertyName,
                    ErrorMessage = error.ErrorMessage
                });  
            }
            return errors;
        }
    }
}
