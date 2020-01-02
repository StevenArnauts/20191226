using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Server.Entities.UnitOfWork {

	public class UnitOfWorkFilter<TContext> : IActionFilter where TContext : DbContext {

		private readonly TContext _unitOfWork;
		private readonly ILogger _logger;

		public UnitOfWorkFilter(TContext unitOfWork, ILoggerFactory logger) {
			this._unitOfWork = unitOfWork;
			this._logger = logger.CreateLogger<UnitOfWorkFilter<TContext>>();
		}

		public void OnActionExecuting(ActionExecutingContext context) {
			// do nothing (or init uow?)
		}

		public void OnActionExecuted(ActionExecutedContext context) {
			if (context.Exception != null) {
				this._logger.LogWarning("Will not commit because " + context.Exception.Message);
				return;
			}
			this._unitOfWork.SaveChanges();
			this._logger.LogDebug("Committed");
		}

	}

}
