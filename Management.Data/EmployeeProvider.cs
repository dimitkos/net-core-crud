using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Management.Data
{
    public class EmployeeProvider : IEmployeeProvider
    {
        private readonly string connectionString;

        public EmployeeProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public IEnumerable<Employee> Get()
        {
            IEnumerable<Employee> employees;

            using (var connection = new SqlConnection(connectionString))
            {
                employees = connection.Query<Employee>("select * from Data");
            }
            return employees;
        }
    }
}
