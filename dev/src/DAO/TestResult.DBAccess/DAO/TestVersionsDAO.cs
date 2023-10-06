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
	public class TestVersionsDAO : DAOCommonBase<TestVersionDTO>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestVersionsDAO() : base("test_versions") { }

		/// <summary>
		/// Returns SQL query to delete 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		protected override string GetDeleteQuery(object obj)
		{
			TestVersionDTO concreteDto = (TestVersionDTO)obj;
			string query = 
				$"DELETE FROM {_tableName} " +
				$"WHERE version_code = \'{concreteDto.VersionCode}\';";
			return query;
		}

		protected override string GetInsertQuery(object obj)
		{
			TestVersionDTO versionDto = (TestVersionDTO)obj;
			string query =
				$"INSERT OR IGNORE INTO {_tableName} ";
			if ((null != versionDto.PreviousVersion) &&
				(!string.IsNullOrEmpty(versionDto.PreviousVersion.VersionCode)) &&
				(!string.IsNullOrWhiteSpace(versionDto.PreviousVersion.VersionCode)))
			{
				query +=
					"(version_code, previous_tested_version_id) " +
					"VALUES " +
					$"(\'{versionDto.VersionCode}\', " +
					$"(SELECT id FROM {_tableName} " +
					$"WHERE version_code = \'{versionDto.PreviousVersion.VersionCode}\'));";
			}
			else
			{
				query +=
					"(version_code) " +
					"VALUES " +
					$"(\'{versionDto.VersionCode}\');";
			}
			return query;
		}

		protected override string GetSelectQuery(object obj)
		{
			TestVersionDTO versionDto = (TestVersionDTO)obj;
			string query =
				$"SELECT " +
					"T1.id as id" +
					", T1.version_code AS version_code" +
					", T2.version_code AS pre_version_code" +
					", T1.created_at AS created_at" +
					", T1.updated_at AS updated_at" +
					$", products.name AS {_tableName}" +
				$"FROM {_tableName} AS T1 " +
				$"LEFT JOIN {_tableName} AS T2 " +
				"ON (T1.pre_version_code_id = T2.id) " +
				"INNER JOIN products ON products.id = T2.products.id" +
				";";
			return query;
		}

		protected override string GetUpdateQuery(object obj)
		{
			TestVersionDTO versionDto = (TestVersionDTO)obj;
			string query =
				$"UPDATE ({_tableName}) " +
				$"version_code = \'{versionDto.VersionCode}\' " +
				$"WHERE id = {versionDto.ID};";
			return query;
		}

		protected override IEnumerable<DTOBase> ReaderToObject(IDataReader reader)
		{
			var list = new List<DTOBase>();
			while (reader.Read())
			{
				var item = new TestVersionDTO();
				item.ID = Convert.ToInt32(reader["id"]);
				item.VersionCode = reader["version_code"].ToString();
				if (DBNull.Value != reader["pre_version_code"])
				{
					item.PreviousVersion = new TestVersionDTO()
					{
						VersionCode = reader["pre_version_code"].ToString()
					};
				}
				item.CreatedAt = DateTime.Parse(reader["created_at"].ToString());
				item.UpdatedAt = DateTime.Parse(reader["updated_at"].ToString());
				list.Add(item);
			}
			return list;
		}
	}
}
