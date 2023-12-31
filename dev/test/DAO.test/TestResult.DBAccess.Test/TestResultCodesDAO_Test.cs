﻿using DBConnector.DTO;
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
				ResultText = "OK",
				OutputText = "●",
			};
			TestResultCodeDTO dto2 = new TestResultCodeDTO()
			{
				ResultText = "PASSED",
				OutputText = "●",
			};
			int count = 0;
			var dao = new TestResultCodeDAO();

			count += (int)dao.Insert(dto1);
			count += (int)dao.Insert(dto2);
			count += (int)dao.Insert(dto1);

			Assert.Equal(2, count);

			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Equal(2, records.Count());
			Assert.Equal("OK", ((TestResultCodeDTO)records.ElementAt(0)).ResultText);
			Assert.Equal("●", ((TestResultCodeDTO)records.ElementAt(0)).OutputText);
			Assert.Equal("PASSED", ((TestResultCodeDTO)records.ElementAt(1)).ResultText);
			Assert.Equal("●", ((TestResultCodeDTO)records.ElementAt(1)).OutputText);

			TestResultCodeDTO dto3 = new TestResultCodeDTO()
			{
				ResultText = "NG",
				OutputText = "×"
			};
			var dtos = new List<DTOBase>();
			dtos.Add(dto1);
			dtos.Add(dto3);
			count = (int)dao.Update(dtos);

			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Equal(2, records.Count());
			Assert.Equal("NG", ((TestResultCodeDTO)records.ElementAt(0)).ResultText);
			Assert.Equal("×", ((TestResultCodeDTO)records.ElementAt(0)).OutputText);
			Assert.Equal("PASSED", ((TestResultCodeDTO)records.ElementAt(1)).ResultText);
			Assert.Equal("●", ((TestResultCodeDTO)records.ElementAt(1)).OutputText);

			count = 0;
			count += (int)dao.Delete(dto2);
			count += (int)dao.Delete(dto3);

			Assert.Equal(2, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();
			Assert.Empty(records);
		}
	}
}
