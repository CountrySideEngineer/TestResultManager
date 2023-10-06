using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using TestResult.DBAccess.DTO;

namespace TestResult.DBAccess.DAO
{
	public class ProductDAO : SimpleDAO<ProductDTO>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ProductDAO() : base("products") { }
	}
}
