using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Adapter
{
    public class OracleDatabase
    {
        public string GetDatabaseName()
        {
            return "Oracle";
        }
    }
    public class SqlServerDatabase
    {
        public string DbName()
        {
            return "SqlServer";
        }
    }

    public interface IDatabaseAdapter
    {
        string ProviderName { get; }
    }

    public class OracleAdapter : IDatabaseAdapter
    {
        private OracleDatabase adaptee = new OracleDatabase();
        public string ProviderName => adaptee.GetDatabaseName();
    }

    public class SqlServerAdapter : IDatabaseAdapter
    {
        private SqlServerDatabase adaptee = new SqlServerDatabase();
        public string ProviderName => adaptee.DbName();
    }
}
