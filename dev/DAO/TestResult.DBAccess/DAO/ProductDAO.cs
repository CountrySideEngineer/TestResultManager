using DBConnector.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
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

		protected override string GetSelectQuery(object dto)
		{
			ProductDTO productDto = (ProductDTO)dto;
			string query = 
				$"SELECT * FROM {_tableName} " +
				$"WHERE name = {productDto.Name};";
			return query;
		}

		protected override string GetDeleteQuery(object dto)
		{
			ProductDTO productDto = (ProductDTO)dto;
			string query = 
				$"DELETE FROM {_tableName} " +
				$"WHERE name = {productDto.Name};";
			return query;
		}

		protected override string GetInsertQuery(object dto)
		{
			ProductDTO productDto = (ProductDTO)dto;
			string query =
				$"INSERT OR IGNORE INTO {_tableName} " +
				"(name) " +
				"VALUES " +
				$"({productDto.Name});";
			return query;
		}

		protected override string GetUpdateQuery(object dto)
		{
			ProductDTO productDto = (ProductDTO)dto;
			string query = 
				$"UPDATE {_tableName} " +
				$"name = {productDto.Name}, " +
				"updated_at = CURRENT_TIMESTMAP " +
				$"WHERE name = {_tableName};";
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
