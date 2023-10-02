using DBConnector.IF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnector.SQLite;
using System.Data;
using System.Collections;
using DBConnector.DTO;
using System.Reflection.Metadata;

namespace TestResult.DBAccess.DAO
{
	public abstract class DAOCommonBase<DTO> : IDAO
		where DTO : DTOBase
	{
		protected string _tableName = string.Empty;

		/// <summary>
		/// Default constructor
		/// </summary>
		protected DAOCommonBase() { }

		/// <summary>
		/// Constructor with argument.
		/// </summary>
		/// <param name="tableName">Table name to access in the DAO.</param>
		public DAOCommonBase(string tableName)
		{
			_tableName = tableName;
		}

		/// <summary>
		/// SELECT all record in a table.
		/// </summary>
		/// <returns>Collection of record object read from a table.</returns>
		public virtual object SelectAll()
		{
			string query = GetSelectAllQuery();
			var parameters = new Dictionary<string, object>();

			IEnumerable<DTO> records = ExecuteQuery(query, parameters);

			return records;
		}

		/// <summary>
		/// SELECT a table specified by a DTO.
		/// </summary>
		/// <param name="dto">Object to specifiy records to read from the table.</param>
		/// <returns></returns>
		public virtual object Select(object dto)
		{
			string query = GetSelectQuery();
			var parameters = GetParameters(dto);

			IEnumerable<DTO> records = ExecuteQuery(query, parameters);

			return records;
		}

		/// <summary>
		/// INSERT record into a table.
		/// </summary>
		/// <param name="dto">DTO object to insert.</param>
		/// <returns></returns>
		public virtual object Insert(object dto)
		{
			string query = GetInsertQuery();
			var parameters = GetParameters(dto);
			int count = ExecuteNonQuery(query, parameters);

			return count;
		}

		/// <summary>
		/// DELETE record from a table.
		/// </summary>
		/// <param name="dto">DTO object to delete from table.</param>
		/// <returns>The number of record deleted from a table.</returns>
		public virtual object Delete(object dto)
		{
			string query = GetDeleteQuery();
			var parameters = GetParameters(dto);
			using var connection = new Connector();
			connection.BeginTransaction();
			int count = connection.ExecuteNonQuery(query, parameters);
			connection.Commit();

			return count;
		}

		/// <summary>
		/// UPDATE record of a table.
		/// </summary>
		/// <param name="dto">DTO object to update.</param>
		/// <returns>The number of record updated.</returns>
		public virtual object Update(object dto)
		{
			string query = GetUpdateQuery();
			var parameters = GetParameters(dto);
			int count = ExecuteNonQuery(query, parameters);

			return count;
		}

		/// <summary>
		/// Execute query.
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		protected IEnumerable<DTO> ExecuteQuery(string query, Dictionary<string, object> parameters)
		{
			using var connection = new Connector();
			using IDataReader reader = connection.ExecuteQuery(query, parameters);
			var records = (IEnumerable<DTO>)ReaderToObject(reader);
			return records;
		}

		/// <summary>
		/// Execute query.
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		protected int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
		{
			using var connection = new Connector();
			connection.BeginTransaction();
			int count = connection.ExecuteNonQuery(query, parameters);
			connection.Commit();

			return count;
		}

		protected abstract IEnumerable<DTOBase> ReaderToObject(IDataReader reader);

		protected abstract string GetSelectAllQuery();
		protected abstract string GetSelectQuery();
		protected abstract string GetInsertQuery();
		protected abstract string GetDeleteQuery();
		protected abstract string GetUpdateQuery();

		protected abstract Dictionary<string, object> GetParameters(object dto);
	}
}
