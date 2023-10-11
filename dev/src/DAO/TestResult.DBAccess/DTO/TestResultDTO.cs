using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestResult.DBAccess.DTO
{
	public class TestResultDTO : DTOBase
	{
		/// <summary>
		/// Product name
		/// </summary>
		public string Product { get; set; } = string.Empty;

		/// <summary>
		/// Function name
		/// </summary>
		public string Function { get; set; } = string.Empty;

		/// <summary>
		/// Test level
		/// </summary>
		public string TestLevel { get; set; } = string.Empty;

		/// <summary>
		/// Test case name
		/// </summary>
		public string TestCase { get; set; } = string.Empty;

		/// <summary>
		/// Test version
		/// </summary>
		public string Version { get; set; } = string.Empty;

		/// <summary>
		/// Test execution type.
		/// </summary>
		public string ExecutionType { get; set; } = string.Empty;

		/// <summary>
		/// Test result code
		/// </summary>
		public string TestResultCode { get; set; } = string.Empty;

		/// <summary>
		/// Tester company
		/// </summary>
		public string TesterCompany { get; set; } = string.Empty;

		/// <summary>
		/// Section name of the tester belong to.
		/// </summary>
		public string TesterSection { get; set;} = string.Empty;

		/// <summary>
		/// Tester name.
		/// </summary>
		public string TesterName { get; set;} = string.Empty;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestResultDTO() : base() { }

	}
}
