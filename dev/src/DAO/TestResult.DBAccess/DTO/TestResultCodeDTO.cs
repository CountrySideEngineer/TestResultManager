using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResult.DBAccess.DTO
{
	public class TestResultCodeDTO : DTOBase
	{
		public string ResultText { get; set; } = string.Empty;

		public string OutputText { get; set; } = string.Empty;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestResultCodeDTO() : base() { }
	}
}
