using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Npgsql;
using log4net;

namespace DataAccess
{
    public class Postgre_Database : IDatabase
    {
        string connString;
        public NpgsqlConnection conn;
        log4net.ILog log;
        public Postgre_Database() {
            connString = $"Host={Configuration.Host};Username={Configuration.Username};Password={Configuration.Password};Database={Configuration.Database}";
            log = LogManager.GetLogger(GetType());
            log.Debug(connString);
            log.Info("Instantiated. ");
        }

        private NpgsqlConnection openConn()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();
            log.Info("Connection Opened. ");

            return conn;
            throw new NpgsqlException("Couldn't connect to Database. ");
        }

        public DbCommand CreateCommand(string genericCommandText)
        {
            return new NpgsqlCommand(genericCommandText);
        }

        public int DeclareParameter(DbCommand command, string name, DbType type)
        {
            if (!command.Parameters.Contains(name))
            {
                int index = command.Parameters.Add(new NpgsqlParameter(name,type));
                return index;
            }
            log.Error($"Parameter {name} already exists. ");
            throw new ArgumentException($"Parameter {name} already exists. ");
        }

        public void DefineParameter(DbCommand command, string name, DbType type, object value) {
            int index = DeclareParameter(command, name, type);
            command.Parameters[index].Value = value;
        }

        public IDataReader ExecuteReader(DbCommand command)
        {
            conn = openConn();
            command.Connection = conn;
            return command.ExecuteReader();
            throw new NpgsqlException("Incorrect Command. ");
        }
        public void ExecuteNonQuery(DbCommand command)
        {
            using(NpgsqlConnection conn = openConn())
            {
                command.Connection = conn;
                command.ExecuteNonQuery();
                return;
            }
            throw new NpgsqlException("Incorrect Command. ");
        } 

        public void SetParameter(DbCommand command, string name, object value)
        {
            if (command.Parameters.Contains(name))
            {
                command.Parameters[name].Value = value;
            }
            throw new ArgumentException($"Parameter {name} doesn't exist. ");
        }

        public void CloseConn() {
            if (conn != null)
            {
                conn.Close();
            }
        }
        ~Postgre_Database()
        {
            log.Info("Closed. ");
        }
    }
}
