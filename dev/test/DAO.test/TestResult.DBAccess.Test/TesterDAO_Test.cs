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
	public class TesterDAO_Test
	{
		[Fact]
		public void Test_INSERT_SELECT_UPDATE_DELETE_001()
		{
			var dto = new TesterDTO()
			{
				TesterCode = "TesterCode_001",
				Company = "TesterCompany_001",
				Section = "TesterSection_001",
				Name = "TesterName_001"
			};
			var dao = new TesterDAO();
			int count = (int)dao.Insert(dto);

			Assert.Equal(1, count);

			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Single(records);
			Assert.Equal("TesterCode_001", ((TesterDTO)records.ElementAt(0)).TesterCode);
			Assert.Equal("TesterCompany_001", ((TesterDTO)records.ElementAt(0)).Company);
			Assert.Equal("TesterSection_001", ((TesterDTO)records.ElementAt(0)).Section);
			Assert.Equal("TesterName_001", ((TesterDTO)records.ElementAt(0)).Name);

			var dto2 = new TesterDTO()
			{
				TesterCode = "TesterCode_001",
				Company = "TesterCompany_002",
				Section = "TesterSection_002",
				Name = "TesterName_002"
			};
			count = (int)dao.Update(dto2);

			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Single(records);
			Assert.Equal("TesterCode_001", ((TesterDTO)records.ElementAt(0)).TesterCode);
			Assert.Equal("TesterCompany_002", ((TesterDTO)records.ElementAt(0)).Company);
			Assert.Equal("TesterSection_002", ((TesterDTO)records.ElementAt(0)).Section);
			Assert.Equal("TesterName_002", ((TesterDTO)records.ElementAt(0)).Name);

			count = (int)dao.Delete(dto2);
			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Empty(records);
		}
	}
}
