using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestResult.DBAccess.DTO;

namespace TestResult.DBAccess.DAO
{
	public class FunctionDAO : SimpleDAO<FunctionDTO>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public FunctionDAO() : base("functions") { }
	}
}
