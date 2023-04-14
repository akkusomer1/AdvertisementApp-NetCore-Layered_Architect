using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.IdentityModel.Tokens;
using Udemy.AdvertisementApp.Core.ResponseObject;

namespace Udemy.AdvertisementApp.UI.Extantion
{

    //Redirect eden metoduma controllerName'de ekliyorum böylece ilgili Controller dışındaki bir Controller'ada yönlendirebilirim.
    //Bu string controllerName="" en başta null bırakıyorum.eğer doldurulursa İlgili Controllerdaki Action metoda gider.
    //Eğer girilmezse problem yok default olarak string.Empty'dir.
    public static class ControllerExtantion
    {
        public static IActionResult ResponseRedirectAction<T>(this Controller controller, IDataGenericResponse<T> response, string actionName,string controllerName="")
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();

            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in response.ValidateErrors)
                {
                    controller.ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return controller.View(response.Data);
            }

            if (string.IsNullOrEmpty(controllerName))
            {
                return controller.Redirect(actionName);
            }
            else
            {
                return controller.RedirectToAction(actionName,controllerName);
            }
         
        }


        public static IActionResult ResponseView<T>(this Controller controller, IDataGenericResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
                       
            return controller.View(response.Data);
        }

        public static IActionResult ResponseRedirectAction(this Controller controller, IResponse response,string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();

            return controller.Redirect(actionName);
        }
    }
}
