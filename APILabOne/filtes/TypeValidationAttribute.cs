using LabOne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LabOne.filtes
{
    public class TypeValidationAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Car? car = context.ActionArguments["car"] as Car;

            var allowedTypes = "Electric,Gas,Diesel,Hybrid".Split(',');

            if (car == null || !allowedTypes.Contains(car.type))
            {
                context.ModelState.AddModelError("type", "type isn't valid");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
