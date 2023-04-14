using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.AdvertisementApp.Core.ResponseObject
{
    public class DataGenericResponse<T> : Response,IDataGenericResponse<T>  
    {
        public T Data { get; set; }
        public List<CustomValidationError> ValidateErrors { get; set; }

        public DataGenericResponse(ResponseType responseType, T data):base(responseType) 
        {
            Data = data;
        }
        public DataGenericResponse(ResponseType responseType, T data, List<CustomValidationError> errors) : base(responseType)
        {
            ValidateErrors = errors;
            Data = data;
        }

        public DataGenericResponse( T data,List<CustomValidationError> errors):base(ResponseType.ValidationError)
        {
            Data= data;
            ValidateErrors = errors;
        }

        public DataGenericResponse(ResponseType responseType,string message):base(responseType,message)
        {
        }

    }
}
