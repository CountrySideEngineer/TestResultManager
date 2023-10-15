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
	public class TestExecutionTypeDAO_Test
	{
		[Fact]
		public void Test_INSERT_SELECT_UPDATE_DELETE_001()
		{
			var dto1 = new TestExecutionTypeDTO()
			{
				TypeText = "ExecutionType_001",
				IsRun = false
			};
			var dto2 = new TestExecutionTypeDTO()
			{
				TypeText = "ExecutionType_002",
				IsRun = true
			};

			var dao = new TestExecutionTypeDAO();
			int count = (int)dao.Insert(dto1);

			Assert.Equal(1, count);

			count = (int)dao.Insert(dto2);

			Assert.Equal(1, count);

			var records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Equal(2, records.Count());
			Assert.Equal("ExecutionType_001", ((TestExecutionTypeDTO)records.ElementAt(0)).TypeText);
			Assert.False(((TestExecutionTypeDTO)records.ElementAt(0)).IsRun);
			Assert.Equal("ExecutionType_002", ((TestExecutionTypeDTO)records.ElementAt(1)).TypeText);
			Assert.True(((TestExecutionTypeDTO)records.ElementAt(1)).IsRun);

			var dto3 = new TestExecutionTypeDTO()
			{
				TypeText = "ExecutionType_001",
				IsRun = true
			};
			var dto4 = new TestExecutionTypeDTO()
			{
				TypeText = "ExecutionType_002",
				IsRun = false
			};

			count = (int)dao.Update(dto3);

			Assert.Equal(1, count);

			count = (int)dao.Update(dto4);

			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Equal(2, records.Count());
			Assert.Equal("ExecutionType_001", ((TestExecutionTypeDTO)records.ElementAt(0)).TypeText);
			Assert.True(((TestExecutionTypeDTO)records.ElementAt(0)).IsRun);
			Assert.Equal("ExecutionType_002", ((TestExecutionTypeDTO)records.ElementAt(1)).TypeText);
			Assert.False(((TestExecutionTypeDTO)records.ElementAt(1)).IsRun);

			count = (int)dao.Delete(dto3);

			Assert.Equal(1, count);

			count = (int)dao.Delete(dto4);

			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Empty(records);
		}
	}
}
