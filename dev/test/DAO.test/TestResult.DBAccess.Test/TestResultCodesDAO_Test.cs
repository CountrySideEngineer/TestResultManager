using DBConnector.DTO;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestResult.DBAccess.DAO;
using TestResult.DBAccess.DTO;
using Xunit.Sdk;

namespace TestResult.DBAccess.Test
{
	[Collection("TEST DAO")]
	public class TestResultCodesDAO_Test
	{
		[Fact]
		public void Test_INSERT_SELECT_UPDATE_DELETE_001()
		{
			TestResultCodeDTO dto1 = new TestResultCodeDTO()
			{
				ResultText = "OK"
			};
			var dao = new TestResultCodeDAO();
			int count = (int)dao.Insert(dto1);

			Assert.Equal(1, count);

			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Single(records);
			Assert.Equal("OK", ((TestResultCodeDTO)records.ElementAt(0)).ResultText);

			TestResultCodeDTO dto2 = new TestResultCodeDTO()
			{
				ResultText = "NG"
			};
			var dtos = new List<DTOBase>();
			dtos.Add(dto1);
			dtos.Add(dto2);
			count = (int)dao.Update(dtos);

			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Single(records);
			Assert.Equal("NG", ((TestResultCodeDTO)records.ElementAt(0)).ResultText);

			count = (int)dao.Delete(dto2);

			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Empty(records);
		}
	}
}
