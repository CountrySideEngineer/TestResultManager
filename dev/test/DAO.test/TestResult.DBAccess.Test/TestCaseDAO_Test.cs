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
	public class TestCaseDAO_Test
	{
		[Fact]
		public void Test_INSERT_SELECT_UPDATE_DELETE_001()
		{
			TestCaseDTO dto = new TestCaseDTO()
			{
				TestName = "TestCase_001",
				Detail = "TestDetail_001",
				Summary = "TestSummary_001"
			};
			var dao = new TestCaseDAO();
			int count = (int)dao.Insert(dto);

			Assert.Equal(1, count);

			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Single(records);
			Assert.Equal("TestCase_001", ((TestCaseDTO)records.ElementAt(0)).TestName);
			Assert.Equal("TestDetail_001", ((TestCaseDTO)records.ElementAt(0)).Detail);
			Assert.Equal("TestSummary_001", ((TestCaseDTO)records.ElementAt(0)).Summary);

			TestCaseDTO newDto = new TestCaseDTO()
			{
				ID = records.ElementAt(0).ID,
				TestName = "TestCase_001_v2",
				Detail = "TestDetail_001_v2",
				Summary = "TestSummary_001_v2"
			};
			count = (int)dao.Update(newDto);

			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Single(records);
			Assert.Equal("TestCase_001_v2", ((TestCaseDTO)records.ElementAt(0)).TestName);
			Assert.Equal("TestDetail_001_v2", ((TestCaseDTO)records.ElementAt(0)).Detail);
			Assert.Equal("TestSummary_001_v2", ((TestCaseDTO)records.ElementAt(0)).Summary);

			count = (int)dao.Delete(newDto);
			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Empty(records);
		}

	}
}
