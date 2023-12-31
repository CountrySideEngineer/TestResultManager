﻿using DBConnector.DTO;
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
		where DTO : SimpleDTO, new()
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

		protected override string GetSelectQuery(object dto)
		{
			var concreteDto = (SimpleDTO)dto;
			string query =
				$"SELECT * FROM {_tableName} " +
				$"WHERE name = \'{concreteDto.Name}\';";
			return query;
		}

		protected override string GetDeleteQuery(object dto)
		{
			var concreteDto = (SimpleDTO)dto;
			string query =
				$"DELETE FROM {_tableName} " +
				$"WHERE name = \'{concreteDto.Name}\';";
			return query;
		}

		protected override string GetInsertQuery(object dto)
		{
			var concreteDto = (SimpleDTO)dto;
			string query =
				$"INSERT OR IGNORE INTO {_tableName} " +
				"(name) " +
				"VALUES " +
				$"(\'{concreteDto.Name}\');";
			return query;
		}

		protected override string GetUpdateQuery(object dto)
		{
			try
			{
				var dtos = (IEnumerable<DTOBase>)dto;
				SimpleDTO dtoBefore = (SimpleDTO)dtos.ElementAt(0);
				SimpleDTO dtoAfter = (SimpleDTO)dtos.ElementAt(1);
				string query =
					$"UPDATE {_tableName} " +
					$"SET name = \'{dtoAfter.Name}\', " +
					"updated_at = CURRENT_TIMESTAMP " +
					$"WHERE name = \'{dtoBefore.Name}\';";
				return query;
			}
			catch (NullReferenceException)
			{
				throw new ArgumentNullException();
			}
			catch (Exception ex)
			when ((ex is InvalidCastException) ||
				(ex is IndexOutOfRangeException))
			{
				throw new ArgumentException();
			}
		}

		protected override IEnumerable<DTOBase> ReaderToObject(IDataReader reader)
		{
			var list = new List<DTOBase>();
			while (reader.Read())
			{
				var item = new DTO();
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
