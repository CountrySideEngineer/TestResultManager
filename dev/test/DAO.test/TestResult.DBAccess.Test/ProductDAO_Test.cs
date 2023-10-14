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
		public void Test_INSERT_SELECT_UPDATE_DELETE_001()
		{
			var functions = new List<DTOBase>();
			for (int index = 0; index < 7; index++)
			{
				var function = new ProductDTO()
				{
					Name = $"products_{(index + 1):D3}"
				};
				functions.Add(function);
			}

			int sum = 0;
			var dao = new ProductDAO();
			foreach (var function in functions)
			{
				sum += (int)dao.Insert(function);
			}

			Assert.Equal(7, sum);

			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Equal(7, records.Count());
			Assert.Equal("products_001", ((SimpleDTO)records.ElementAt(0)).Name);
			Assert.Equal("products_002", ((SimpleDTO)records.ElementAt(1)).Name);
			Assert.Equal("products_003", ((SimpleDTO)records.ElementAt(2)).Name);
			Assert.Equal("products_004", ((SimpleDTO)records.ElementAt(3)).Name);
			Assert.Equal("products_005", ((SimpleDTO)records.ElementAt(4)).Name);
			Assert.Equal("products_006", ((SimpleDTO)records.ElementAt(5)).Name);
			Assert.Equal("products_007", ((SimpleDTO)records.ElementAt(6)).Name);

			var dtos = new List<DTOBase>()
			{
				records.ElementAt(0),
				new FunctionDTO()
				{
					Name = "products_101"
				}
			};
			int count = (int)dao.Update(dtos);

			Assert.Equal(1, count);

			records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Equal(7, records.Count());
			Assert.Equal("products_101", ((SimpleDTO)records.ElementAt(0)).Name);
			Assert.Equal("products_002", ((SimpleDTO)records.ElementAt(1)).Name);
			Assert.Equal("products_003", ((SimpleDTO)records.ElementAt(2)).Name);
			Assert.Equal("products_004", ((SimpleDTO)records.ElementAt(3)).Name);
			Assert.Equal("products_005", ((SimpleDTO)records.ElementAt(4)).Name);
			Assert.Equal("products_006", ((SimpleDTO)records.ElementAt(5)).Name);
			Assert.Equal("products_007", ((SimpleDTO)records.ElementAt(6)).Name);

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