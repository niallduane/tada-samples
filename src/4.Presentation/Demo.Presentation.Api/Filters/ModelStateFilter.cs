using Demo.Domain.Core;
using Demo.Domain.Core.Types;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Presentation.Api.Filters;

public class ModelStateFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var validationErrors = context.ModelState
                .Select(model =>
                {
                    var errors = model.Value?.Errors?.Select(x => x.ErrorMessage)?.ToArray() ?? Array.Empty<string>();
                    return new ValidationError(model.Key, errors);
                }).ToArray() ?? Array.Empty<ValidationError>();

            var result = new ApiErrorResponse(StatusCodes.Status422UnprocessableEntity, new ValidationErrorList("Validation failed", ErrorTypes.Invalid, validationErrors));
            context.Result = new JsonResult(result)
            {
                StatusCode = StatusCodes.Status422UnprocessableEntity
            };
        }
        base.OnActionExecuting(context);
    }
}