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
		public void Test_INSERT_SELECT_UPDATE_DELETE_001()
		{
			var testLevels = new List<DTOBase>();
			for (int index = 0; index < 7; index++)
			{
				var testLevel = new TestLevelDTO()
				{
					Name = $"TestLevels_{(index + 1):D3}"
				};
				testLevels.Add(testLevel);
			}

			int sum = 0;
			TestLevelDAO dao = new TestLevelDAO();
			foreach (var testLevel in testLevels)
			{
				sum += (int)dao.Insert(testLevel);
			}

			Assert.Equal(7, sum);

			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Equal(7, records.Count());
			Assert.Equal("TestLevels_001", ((SimpleDTO)records.ElementAt(0)).Name);
			Assert.Equal("TestLevels_002", ((SimpleDTO)records.ElementAt(1)).Name);
			Assert.Equal("TestLevels_003", ((SimpleDTO)records.ElementAt(2)).Name);
			Assert.Equal("TestLevels_004", ((SimpleDTO)records.ElementAt(3)).Name);
			Assert.Equal("TestLevels_005", ((SimpleDTO)records.ElementAt(4)).Name);
			Assert.Equal("TestLevels_006", ((SimpleDTO)records.ElementAt(5)).Name);
			Assert.Equal("TestLevels_007", ((SimpleDTO)records.ElementAt(6)).Name);

			var dtos = new List<DTOBase>()
			{
				records.ElementAt(0),
				new TestLevelDTO()
				{
					Name = "TestLevels_101"
				}
			};
			int count = (int)dao.Update(dtos);

			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Equal(7, records.Count());
			Assert.Equal("TestLevels_101", ((SimpleDTO)records.ElementAt(0)).Name);
			Assert.Equal("TestLevels_002", ((SimpleDTO)records.ElementAt(1)).Name);
			Assert.Equal("TestLevels_003", ((SimpleDTO)records.ElementAt(2)).Name);
			Assert.Equal("TestLevels_004", ((SimpleDTO)records.ElementAt(3)).Name);
			Assert.Equal("TestLevels_005", ((SimpleDTO)records.ElementAt(4)).Name);
			Assert.Equal("TestLevels_006", ((SimpleDTO)records.ElementAt(5)).Name);
			Assert.Equal("TestLevels_007", ((SimpleDTO)records.ElementAt(6)).Name);

			sum = 0;
			foreach (var record in records)
			{
				sum += (int)dao.Delete(record);
			}

			Assert.Equal(7, sum);

			records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Empty(records);

		}
	}
}