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
	public class TestVersionsDAO_Test
	{
		[Fact]
		public void Test_INSERT_SELECT_UPDATE_DELETE_001()
		{
			var productDAO = new ProductDAO();
			var product = new ProductDTO()
			{
				Name = "product_001"
			};
			int count = (int)productDAO.Insert(product);

			Assert.Equal(1, count);

			product = new ProductDTO()
			{
				Name = "product_002"
			};
			count = (int)productDAO.Insert(product);

			count = 0;
			var version = new TestVersionDTO()
			{
				VersionCode = "1.0.0.0",
				Product = product
			};
			var dao = new TestVersionsDAO();
			count += (int)dao.Insert(version);

			for (int index = 1; index < 10; index++)
			{
				var versionDto = new TestVersionDTO()
				{
					VersionCode = $"1.0.0.{index}",
					Product = product,
					PreviousVersion = new TestVersionDTO()
					{
						VersionCode = $"1.0.0.{index - 1}",
					}
				};
				count += (int)dao.Insert(versionDto);
			}

			Assert.Equal(10, count);

			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Equal(10, records.Count());
			Assert.Equal("1.0.0.0", ((TestVersionDTO)records.ElementAt(0)).VersionCode);
			Assert.Equal("1.0.0.1", ((TestVersionDTO)records.ElementAt(1)).VersionCode);
			Assert.Equal("1.0.0.2", ((TestVersionDTO)records.ElementAt(2)).VersionCode);
			Assert.Equal("1.0.0.3", ((TestVersionDTO)records.ElementAt(3)).VersionCode);
			Assert.Equal("1.0.0.4", ((TestVersionDTO)records.ElementAt(4)).VersionCode);
			Assert.Equal("1.0.0.5", ((TestVersionDTO)records.ElementAt(5)).VersionCode);
			Assert.Equal("1.0.0.6", ((TestVersionDTO)records.ElementAt(6)).VersionCode);
			Assert.Equal("1.0.0.7", ((TestVersionDTO)records.ElementAt(7)).VersionCode);
			Assert.Equal("1.0.0.8", ((TestVersionDTO)records.ElementAt(8)).VersionCode);
			Assert.Equal("1.0.0.9", ((TestVersionDTO)records.ElementAt(9)).VersionCode);

			var dtos = new List<DTOBase>()
			{
				records.ElementAt(0),
				new TestVersionDTO()
				{
					VersionCode = "1.1.0.1",
					Product = product
				}
			};
			count = (int)dao.Update(dtos);

			Assert.Equal(1, count);

			dtos = new List<DTOBase>()
			{
				records.ElementAt(1),
				new TestVersionDTO()
				{
					VersionCode = "1.1.0.2",
					Product = new ProductDTO()
					{
						Name = "product_001"
					}
				}
			};
			count = (int)dao.Update(dtos);

			records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Equal(10, records.Count());
			Assert.Equal("1.1.0.1", ((TestVersionDTO)records.ElementAt(0)).VersionCode);
			Assert.Equal("1.1.0.2", ((TestVersionDTO)records.ElementAt(1)).VersionCode);
			Assert.Equal("1.0.0.2", ((TestVersionDTO)records.ElementAt(2)).VersionCode);
			Assert.Equal("1.0.0.3", ((TestVersionDTO)records.ElementAt(3)).VersionCode);
			Assert.Equal("1.0.0.4", ((TestVersionDTO)records.ElementAt(4)).VersionCode);
			Assert.Equal("1.0.0.5", ((TestVersionDTO)records.ElementAt(5)).VersionCode);
			Assert.Equal("1.0.0.6", ((TestVersionDTO)records.ElementAt(6)).VersionCode);
			Assert.Equal("1.0.0.7", ((TestVersionDTO)records.ElementAt(7)).VersionCode);
			Assert.Equal("1.0.0.8", ((TestVersionDTO)records.ElementAt(8)).VersionCode);
			Assert.Equal("1.0.0.9", ((TestVersionDTO)records.ElementAt(9)).VersionCode);

			count = 0;
			foreach (var record in records)
			{
				count += (int)dao.Delete(record);
			}
			Assert.Equal(10, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Empty(records);

			var productRecords = (IEnumerable<DTOBase>)productDAO.SelectAll();
			foreach (var productRecord in productRecords)
			{
				productDAO.Delete(productRecord);
			}
		}
	}
}