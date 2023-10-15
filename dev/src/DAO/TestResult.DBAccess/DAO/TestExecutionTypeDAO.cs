using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestResult.DBAccess.DTO;

namespace TestResult.DBAccess.DAO
{
	public class TestExecutionTypeDAO : DAOCommonBase<TestExecutionTypeDTO>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestExecutionTypeDAO() : base("test_execution_types") { }

		protected override string GetDeleteQuery(object obj)
		{
			TestExecutionTypeDTO dto = (TestExecutionTypeDTO)obj;
			string query =
				$"DELETE FROM {_tableName} " +
				$"WHERE type_text = \'{dto.TypeText}\'";
			return query;
		}

		protected override string GetInsertQuery(object obj)
		{
			TestExecutionTypeDTO dto = (TestExecutionTypeDTO)obj;
			int isRun = dto.IsRun == false ? 0 : 1;
			string query =
				$"INSERT OR IGNORE INTO {_tableName} " +
				"(type_text, is_run) " +
				"VALUES " +
				$"(\'{dto.TypeText}\', {isRun});";
			return query;
		}

		protected override string GetSelectQuery(object obj)
		{
			TestExecutionTypeDTO dto = (TestExecutionTypeDTO)obj;
			string query =
				$"SELECT * FROM {_tableName} " +
				$"WHERE type_text = \'{dto.TypeText}\';";
			return query;
		}

		protected override string GetUpdateQuery(object obj)
		{
			TestExecutionTypeDTO dto = (TestExecutionTypeDTO)obj;
			int isRun = dto.IsRun == false ? 0 : 1;
			string query =
				$"UPDATE {_tableName} " +
				"SET " +
				$"type_text = \'{dto.TypeText}\' " +
				$", is_run = {isRun} " +
				$", updated_at = CURRENT_TIMESTAMP " +
				$"WHERE type_text = \'{dto.TypeText}\';";
			return query;
		}

		protected override IEnumerable<DTOBase> ReaderToObject(IDataReader reader)
		{
			var list = new List<DTOBase>();
			while (reader.Read())
			{
				var item = new TestExecutionTypeDTO();
				item.ID = Convert.ToInt32(reader["id"]);
				item.TypeText = reader["type_text"].ToString();
				item.IsRun = Convert.ToInt32(reader["is_run"]) == 0 ? false : true;
				item.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
				item.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
				list.Add(item);
			}
			return list;
		}
	}
}
