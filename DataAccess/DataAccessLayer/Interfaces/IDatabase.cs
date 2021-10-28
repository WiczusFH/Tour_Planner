using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace DataAccess
{
    public interface IDatabase
    {
        DbCommand CreateCommand(string genericCommandText);
        int DeclareParameter(DbCommand command, string name, DbType type);
        void DefineParameter(DbCommand command, string name, DbType type, object value);
        IDataReader ExecuteReader(DbCommand command);
        void ExecuteNonQuery(DbCommand command);
        void SetParameter(DbCommand parameter, string name, object value);


    }
}
