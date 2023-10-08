using DBConnector.DTO;
using DBConnector.SQLite;
using System.Data.SQLite;
using System.Reflection.Metadata;
using TestResult.DBAccess.DAO;
using TestResult.DBAccess.DTO;

namespace TestResult.DBAccess.Test
{
	[Collection("TEST DAO")]
	public class FunctionDAO_Test
	{
#if false
		public FunctionDAO_Test()
		{
			//Create table used in the test.
			string queryDrop = "DROP TABLE \"functions\"";
			string queryCreate = "CREATE TABLE \"functions\" " +
				"(" +
				"\"id\" INTEGER, " +
				"\"name\" TEXT NOT NULL UNIQUE, " +
				"\"created_at\" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP, " +
				"\"updated_at\" TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP, " +
				"PRIMARY KEY(\"id\"))";

			using (var connectionDrop = new Connector())
			{
				try
				{
					connectionDrop.BeginTransaction();
					connectionDrop.ExecuteNonQuery(queryDrop);
					connectionDrop.Commit();
				}
				catch (SQLiteException ex)
				{
					Console.WriteLine(ex.Message);
					connectionDrop.Commit();
				}
			}

			using (var connectionCreate = new Connector())
			{
				try
				{
					while (connectionCreate.IsDbLocked())
					{
						Thread.Sleep(100);
					}
					connectionCreate.BeginTransaction();
					connectionCreate.ExecuteNonQuery(queryCreate);
					connectionCreate.Commit();
				}
				catch (SQLiteException ex)
				{
					Console.WriteLine(ex.Message);
					connectionCreate.Commit();
				}
			}
		}
#endif

		[Fact]
		public void Test_SelectAll_001()
		{
			FunctionDAO dao = new FunctionDAO();
			IEnumerable<DTOBase> records = (IEnumerable<DTOBase>)dao.SelectAll();

			Assert.Equal(7, records.Count());
			Assert.Equal("functions_001", ((FunctionDTO)records.ElementAt(0)).Name);
			Assert.Equal("functions_002", ((SimpleDTO)records.ElementAt(1)).Name);
			Assert.Equal("functions_003", ((SimpleDTO)records.ElementAt(2)).Name);
			Assert.Equal("functions_004", ((SimpleDTO)records.ElementAt(3)).Name);
			Assert.Equal("functions_005", ((SimpleDTO)records.ElementAt(4)).Name);
			Assert.Equal("functions_006", ((SimpleDTO)records.ElementAt(5)).Name);
			Assert.Equal("functions_007", ((SimpleDTO)records.ElementAt(6)).Name);
		}
	}
}