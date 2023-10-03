using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResult.DBAccess.DTO
{
	public class TestCaseDTO : DTOBase
	{
		public string TestCode { get; set; } = string.Empty;

		public string Summary {  get; set; } = string.Empty;

		public string Detail { get; set; } = string.Empty;

		public TestCaseDTO? BaseTestCase { get; set; } = null;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestCaseDTO() : base() { }
	}
}
