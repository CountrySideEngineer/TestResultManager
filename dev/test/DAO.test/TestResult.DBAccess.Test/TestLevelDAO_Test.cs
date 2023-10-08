using DBConnector.DTO;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Helpers;
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
	public class TestLevelDAO_Test
	{
		[Fact]
		public void Test_SelectAll_001()
		{
			TestLevelDAO dao = new TestLevelDAO();
			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Equal(2, records.Count());
			Assert.Equal("test_levels_001", ((TestLevelDTO)records.ElementAt(0)).Name);
		}
	}
}
