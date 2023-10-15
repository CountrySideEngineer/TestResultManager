using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResult.DBAccess.DTO
{
	public class TestVersionDTO : DTOBase
	{
		public string VersionCode { get; set; } = string.Empty;

		public TestVersionDTO? PreviousVersion { get; set; } = null;

		public ProductDTO? Product { get; set; } = null;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestVersionDTO() : base() { }
	}
}
