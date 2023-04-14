using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Core.ResponseObject
{
    public interface IDataGenericResponse<T>: IResponse
       
    {
         T Data { get; set; }
         List<CustomValidationError> ValidateErrors { get; set; }
    }
}
