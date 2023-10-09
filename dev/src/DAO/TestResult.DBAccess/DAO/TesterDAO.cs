using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestResult.DBAccess.DTO;

namespace TestResult.DBAccess.DAO
{
	public class TesterDAO : DAOCommonBase<TesterDTO>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TesterDAO() : base("testers") { }

		protected override string GetDeleteQuery(object obj)
		{
			var dto = (TesterDTO)obj;
			string query =
				$"DELETE FROM {_tableName} " +
				$"WHERE tester_code = \'{dto.TesterCode}\';";
			return query;
		}

		protected override string GetInsertQuery(object obj)
		{
			var dto = (TesterDTO)obj;
			string query =
				$"INSERT OR IGNORE INTO {_tableName} " +
				"(tester_code, company, section, name) " +
				"VALUES " +
				$"(\'{dto.TesterCode}\', \'{dto.Company}\', \'{dto.Section}\', \'{dto.Name}\')";
			return query;
		}

		protected override string GetSelectQuery(object obj)
		{
			var dto = (TesterDTO)obj;
			string query =
				$"SELECT * FROM {_tableName} " +
				$"WHERE tester_code = \'{dto.TesterCode}\';";
			return query;
		}

		protected override string GetUpdateQuery(object obj)
		{
			var dto = (TesterDTO)obj;
			string query =
				$"UPDATE {_tableName} " +
				"SET " +
				$"company = \'{dto.Company}\' " +
				$", section = \'{dto.Section}\' " +
				$", name = \'{dto.Name}\' " +
				", updated_at = CURRENT_TIMESTAMP " +
				$"WHERE tester_code = \'{dto.TesterCode}\';";
			return query;
		}

		protected override IEnumerable<DTOBase> ReaderToObject(IDataReader reader)
		{
			var list = new List<DTOBase>();
			while (reader.Read())
			{
				var item = new TesterDTO();
				item.ID = Convert.ToInt32(reader["id"]);
				item.TesterCode = reader["tester_code"].ToString();
				item.Company = reader["company"].ToString();
				item.Section = reader["section"].ToString();
				item.Name = reader["name"].ToString();
				item.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
				item.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
				list.Add(item);
			}
			return list;
		}
	}
}
