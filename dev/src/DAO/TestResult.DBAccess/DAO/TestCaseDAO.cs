using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestResult.DBAccess.DTO;

namespace TestResult.DBAccess.DAO
{
	public class TestCaseDAO : DAOCommonBase<TestCaseDTO>
	{
		/// <summary>
		/// 
		/// </summary>
		public TestCaseDAO() : base("test_cases") { }

		protected override string GetDeleteQuery(object obj)
		{
			var dto = (TestCaseDTO)obj;
			string query =
				$"DELETE FROM {_tableName} " +
				$"WHERE " +
				$"test_name = \'{dto.TestName}\';";
			return query;
		}

		protected override string GetInsertQuery(object obj)
		{
			var dto = (TestCaseDTO)obj;
			string query =
				$"INSERT OR IGNORE INTO {_tableName} " +
				$"(test_name, summary, detail) " +
				$"VALUES " +
				$"(\'{dto.TestName}\', \'{dto.Summary}\', \'{dto.Detail}\');";
			return query;
		}

		protected override string GetSelectQuery(object obj)
		{
			var dto = (TestCaseDTO)obj;
			string query =
				$"SELECT * FROM {_tableName} " +
				$"WHERE test_name = \'{dto.TestName}\';";
			return query;
		}

		protected override string GetUpdateQuery(object obj)
		{
			var dto = (TestCaseDTO)obj;
			string query =
				$"UPDATE {_tableName} " +
				"SET " +
				$"test_name = \'{dto.TestName}\', " +
				$"summary = \'{dto.Summary}\', " +
				$"detail = \'{dto.Detail}\', " +
				"updated_at = CURRENT_TIMESTAMP " +
				$"WHERE id = {dto.ID};";
			return query;
		}

		protected override IEnumerable<DTOBase> ReaderToObject(IDataReader reader)
		{
			var list = new List<DTOBase>();
			while (reader.Read())
			{
				var item = new TestCaseDTO();
				item.ID = Convert.ToInt32(reader["id"]);
				item.TestName = reader["test_name"].ToString();
				item.Detail = reader["detail"].ToString();
				item.Summary = reader["summary"].ToString();
				item.TestCaseVersion = Convert.ToInt32(reader["test_case_version"]);
				list.Add(item);
			}
			return list;
		}
	}
}
