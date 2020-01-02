using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Server.Entities;
using Server.Utilities.Exceptions;

namespace Server.Utilities.Filters {

	public class ExceptionFilter : IActionFilter {

		public void OnActionExecuting(ActionExecutingContext context) { }

		public void OnActionExecuted(ActionExecutedContext context) {

			if (context.Exception == null) return;

			var body = new ErrorResult {
				Trace = Hasher.GenerateRandomString(6, Hasher.LettersAndNumbers),
				Message = context.Exception.Message
			};

			if (context.Exception is ObjectNotFoundException) {
				body.Code = "not_found";
				context.Result = new ObjectResult(body) {
					StatusCode = 404
				};
			} else if (context.Exception is BusinessException) {
				body.Code = "client_error";
				context.Result = new ObjectResult(body) {
					StatusCode = 400
				};
			} else {
				body.Code = "server_error";
				context.Result = new ObjectResult(body) {
					StatusCode = 500
				};
			}

			context.ExceptionHandled = true;

		}

	}

}
