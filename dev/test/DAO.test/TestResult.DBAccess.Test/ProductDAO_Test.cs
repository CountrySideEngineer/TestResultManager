using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestResult.DBAccess.DAO;
using TestResult.DBAccess.DTO;

namespace TestResult.DBAccess.Test
{
	[Collection("TEST DAO")]
	public class ProductDAO_Test
	{
		[Fact]
		public void Test_SelectAll_001()
		{
			ProductDAO dao = new ProductDAO();
			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Equal(2, records.Count());
			Assert.Equal("products_001", ((ProductDTO)records.ElementAt(0)).Name);
			Assert.Equal("products_002", ((ProductDTO)records.ElementAt(1)).Name);
		}
	}
}
