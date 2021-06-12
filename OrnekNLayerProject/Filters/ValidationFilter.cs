using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using OrnekNLayerProject.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Filters
{
    public class ValidationFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {

                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 400;

                IEnumerable < ModelError > modelErrors = context.ModelState.Values.SelectMany(v => v.Errors);

                modelErrors.ToList().ForEach(x =>
                {
                    errorDto.Errors.Add(x.ErrorMessage);
                });

                context.Result = new BadRequestObjectResult(errorDto);

            }
        }
    }
}
