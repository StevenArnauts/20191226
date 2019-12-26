using System;

namespace Server.Domain {

	public class BusinessException : ApplicationException {

		public BusinessException(string message) : base(message) { }

	}

}
