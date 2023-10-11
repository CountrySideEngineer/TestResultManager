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
	public class TestResultDAO : DAOCommonBase<TestResultDTO>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestResultDAO() : base("test_results") { }


		protected override string GetDeleteQuery(object obj)
		{
			throw new NotImplementedException();
		}

		protected override string GetInsertQuery(object obj)
		{
			throw new NotImplementedException();
		}

		protected override string GetSelectQuery(object obj)
		{
			throw new NotImplementedException();
		}

		protected override string GetUpdateQuery(object obj)
		{
			throw new NotImplementedException();
		}

		protected override IEnumerable<DTOBase> ReaderToObject(IDataReader reader)
		{
			var list = new List<DTOBase>();
			while (reader.Read())
			{
				var item = new TestResultDTO();
				item.ID = Convert.ToInt32(reader["ID"]);
				item.Product = reader["product"].ToString();
				item.Function = reader["function"].ToString();
				item.TestLevel = reader["test_level"].ToString();
				item.TestCase = reader["test_case"].ToString();
				item.Version = reader["tested_version"].ToString();
				item.ExecutionType = reader["test_execution_type"].ToString();
				item.TestResultCode = reader["test_resulr_code"].ToString();
				item.TesterCompany = reader["company"].ToString();
				item.TesterSection = reader["section"].ToString();
				item.TesterName = reader["name"].ToString();
				list.Add(item);
			}
			return list;
		}
	}
}
