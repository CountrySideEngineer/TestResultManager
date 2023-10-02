using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestResult.DBAccess.DTO;

namespace TestResult.DBAccess.DAO
{
	public class ProductDAO : DAOCommonBase<ProductDTO>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public ProductDAO() : base("products") { }

		protected override string GetSelectAllQuery()
		{
			string query = $"SELECT * FROM {_tableName};";
			return query;
		}

		protected override string GetSelectQuery()
		{
			string query = $"SELECT * FROM {_tableName};";
			return query;
		}

		protected override string GetDeleteQuery()
		{
			string query = $"DELETE FROM {_tableName} WHERE name = @name;";
			return query;
		}

		protected override string GetInsertQuery()
		{
			string query =
				$"INSERT OR IGNORE INTO {_tableName} " +
				"(name) " +
				"VALUES " +
				"(@name);";
			return query;
		}

		protected override Dictionary<string, object> GetParameters(object dto)
		{
			var productDto = (ProductDTO)dto;
			var parameters = new Dictionary<string, object>();
			parameters.Add("@id", productDto.ID);
			parameters.Add("@name", productDto.Name);
			return parameters;
		}

		protected override string GetUpdateQuery()
		{
			string query = "UPDATE products " +
				"name = @name, " +
				"updated_at = CURRENT_TIMESTMAP " +
				"WHERE name = @name;";
			return query;
		}

		protected override IEnumerable<DTOBase> ReaderToObject(IDataReader reader)
		{
			var list = new List<DTOBase>();
			while (reader.Read())
			{
				var item = new ProductDTO();
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
