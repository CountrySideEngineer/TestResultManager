using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResult.DBAccess.DTO
{
	public class SimpleDTO : DTOBase
	{
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SimpleDTO() : base() { }
	}
}
