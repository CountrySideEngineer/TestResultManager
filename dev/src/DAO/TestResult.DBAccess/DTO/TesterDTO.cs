using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResult.DBAccess.DTO
{
	public class TesterDTO : DTOBase
	{
		public string TesterCode { get; set; } = string.Empty;

		public string Company { get; set; } = string.Empty;

		public string Section { get; set; } = string.Empty;

		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TesterDTO() : base() { }


	}
}
