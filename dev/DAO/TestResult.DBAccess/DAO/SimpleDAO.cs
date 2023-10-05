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
	public class SimpleDAO<DTO> : DAOCommonBase<DTO>
		where DTO : DTOBase, new()
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <remarks>
		/// To avoid <para>_tableName</para> field from not setting, access level of this method private.
		/// </remarks>
		private SimpleDAO() : base() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="tableName">Table name.</param>
		public SimpleDAO(string tableName) : base(tableName) { }

		protected override string GetSelectAllQuery()
		{
			string query = $"SELECT * FROM {_tableName};";
			return query;
		}

		protected override string GetSelectQuery(object dto)
		{
			var concreteDto = (SimpleDTO)dto;
			string query =
				$"SELECT * FROM {_tableName} " +
				$"WHERE name = {concreteDto.Name};";
			return query;
		}

		protected override string GetDeleteQuery(object dto)
		{
			var concreteDto = (SimpleDTO)dto;
			string query =
				$"DELETE FROM {_tableName} " +
				$"WHERE name = {concreteDto.Name};";
			return query;
		}

		protected override string GetInsertQuery(object dto)
		{
			var concreteDto = (SimpleDTO)dto;
			string query =
				$"INSERT OR IGNORE INTO {_tableName} " +
				"(name) " +
				"VALUES " +
				$"({concreteDto.Name});";
			return query;
		}

		protected override string GetUpdateQuery(object dto)
		{
			var concreteDto = (SimpleDTO)dto;
			string query =
				$"UPDATE {_tableName} " +
				$"name = {concreteDto.Name}, " +
				"updated_at = CURRENT_TIMESTMAP " +
				$"WHERE name = {_tableName};";
			return query;
		}

		protected override IEnumerable<DTOBase> ReaderToObject(IDataReader reader)
		{
			var list = new List<DTOBase>();
			while (reader.Read())
			{
				var item = new SimpleDTO();
				item.ID = Convert.ToInt32(reader["id"]);
				item.Name = reader["name"].ToString();
				item.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
				item.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
				list.Add(item);
			}
			return list;
		}
	}
}
