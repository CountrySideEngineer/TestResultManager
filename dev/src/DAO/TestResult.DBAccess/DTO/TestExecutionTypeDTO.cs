using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResult.DBAccess.DTO
{
	public class TestExecutionTypeDTO : DTOBase
	{
		public string TypeText { get; set; } = string.Empty;

		public bool IsRun { get; set; } = false;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestExecutionTypeDTO() : base() { }
	}
}
