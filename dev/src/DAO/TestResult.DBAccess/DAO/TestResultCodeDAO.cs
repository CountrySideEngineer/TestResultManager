using DBConnector.DTO;
using System;
using System.Collections.Generic;
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
	public class TestResultCodeDAO : DAOCommonBase<TestResultCodeDTO>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestResultCodeDAO() : base("test_result_codes") { }

		protected override string GetDeleteQuery(object obj)
		{
			var dto = (TestResultCodeDTO)obj;
			string query =
				$"DELETE FROM {_tableName} " +
				$"WHERE " +
					$"result_text = \'{dto.ResultText}\'" +
					" AND " +
					$"output_text = \'{dto.OutputText}\'" +
					";";
			return query;
		}

		protected override string GetInsertQuery(object obj)
		{
			var dto = (TestResultCodeDTO)obj;
			string query =
				$"INSERT OR IGNORE INTO {_tableName} " +
				"(result_text, output_text) " +
				"VALUES " +
				"(" +
					$"\'{dto.ResultText}\', " +
					$"\'{dto.OutputText}\'" +
				$");";
			return query;	
		}

		protected override string GetSelectQuery(object obj)
		{
			var dto = (TestResultCodeDTO)obj;
			string query =
				$"SELECT * FROM {_tableName} " +
				"WHERE " +
				$"reuslt_text = \'{dto.ResultText}\'" +
				" AND " +
				$"output_text = \'{dto.OutputText}\'" +
				";";
			return query;
		}

		protected override string GetUpdateQuery(object obj)
		{
			var dtos = (IEnumerable<DTOBase>)obj;
			var dtoBefore = (TestResultCodeDTO)dtos.ElementAt(0);
			var dtoAfter = (TestResultCodeDTO)dtos.ElementAt(1);
			string query =
				$"UPDATE {_tableName} " +
				"SET " +
					$"result_text = \'{dtoAfter.ResultText}\'" +
					$", output_text = \'{dtoAfter.OutputText}\'" +
					$", updated_at = CURRENT_TIMESTAMP " +
				"WHERE " +
					$"result_text = \'{dtoBefore.ResultText}\'" +
					" AND " +
					$"output_text = \'{dtoBefore.OutputText}\'" +
					";";
			return query;
		}

		protected override IEnumerable<DTOBase> ReaderToObject(IDataReader reader)
		{
			var list = new List<DTOBase>();
			while (reader.Read())
			{
				var item = new TestResultCodeDTO();
				item.ID = Convert.ToInt32(reader["id"]);
				item.ResultText = reader["result_text"].ToString();
				item.OutputText = reader["output_text"].ToString();
				item.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
				item.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
				list.Add(item);
			}
			return list;
		}
	}
}
