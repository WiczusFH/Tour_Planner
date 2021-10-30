using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Npgsql;
using System.Data.Common;
using System.Data;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;


namespace DataAccess
{
    public class DataManager : IDataManager
    {
        public void insertTour(ITour NewTour)
        {
            #region String Building
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into tours (");
            sb.Append(TOUR_TABLE_COLUMNS.name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.distance.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_x.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_y.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_x.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_y.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.description.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.information.ToString());
            sb.Append(") VALUES (");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.name.ToString());
            sb.Append(", ");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.distance.ToString());
            sb.Append(", ");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_name.ToString());
            sb.Append(", ");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_x.ToString());
            sb.Append(", ");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_y.ToString());
            sb.Append(", ");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_name.ToString());
            sb.Append(", ");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_x.ToString());
            sb.Append(", ");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_y.ToString());
            sb.Append(", ");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.description.ToString());
            sb.Append(", ");
            sb.Append("@");
            sb.Append(TOUR_TABLE_COLUMNS.information.ToString());
            sb.Append(")");
            #endregion

            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.name.ToString(), DbType.String,NewTour.name);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.distance.ToString(), DbType.Decimal,NewTour.distance);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.sl_location_name.ToString(), DbType.String, NewTour.sl_name);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.sl_location_x.ToString(), DbType.Decimal, NewTour.sl_x);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.sl_location_y.ToString(), DbType.Decimal, NewTour.sl_y);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.el_location_name.ToString(), DbType.String, NewTour.el_name);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.el_location_x.ToString(), DbType.Decimal, NewTour.el_x);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.el_location_y.ToString(), DbType.Decimal, NewTour.el_y);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.description.ToString(), DbType.String,NewTour.routeDescription);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.information.ToString(), DbType.String,NewTour.routeInformation);

            database.ExecuteNonQuery(command);
            database.CloseConn();
        }

        public List<ITour> GetTours()
        {
            #region String Builder
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append(TOUR_TABLE_COLUMNS.tour_id.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.distance.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_x.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_y.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_x.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_y.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.description.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.information.ToString());
            sb.Append(" FROM tours");
            #endregion

            List<ITour> tourList = new List<ITour>();
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            IDataReader reader = database.ExecuteReader(command);
            while (reader.Read())
            {
                tourList.Add(new Tour(reader.GetString(1),
                    reader.GetFloat(2),
                    reader.GetString(3),
                    reader.GetFloat(4),
                    reader.GetFloat(5),
                    reader.GetString(6),
                    reader.GetFloat(7),
                    reader.GetFloat(8),
                    reader.GetInt32(0),
                    reader.GetString(9),
                    reader.GetString(10)));
            }
            database.CloseConn();
            return tourList;
        }

        public ITour GetTour(int id)
        {
            #region String Builder
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append(TOUR_TABLE_COLUMNS.tour_id.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.distance.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_x.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_y.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_x.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_y.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.description.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.information.ToString());
            sb.Append(" FROM tours WHERE tour_id=@tour_id");
            #endregion
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, "tour_id", DbType.Int32, id);

            IDataReader reader = database.ExecuteReader(command);
            reader.Read();
            ITour tour =new Tour(reader.GetString(1),
                reader.GetFloat(2),
                reader.GetString(3),
                reader.GetFloat(4),
                reader.GetFloat(5),
                reader.GetString(6),
                reader.GetFloat(7),
                reader.GetFloat(8),
                reader.GetInt32(0),
                reader.GetString(9),
                reader.GetString(10));
            database.CloseConn();
            return tour;
        }

        public void deleteTour(int id)
        {
            #region String Builder
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM tours WHERE tour_id=@tour_id");
            #endregion
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, "tour_id", DbType.Int32, id);
            database.ExecuteNonQuery(command);
        }

        public void modifyTour(ITour NewTour)
        {
            if (NewTour.id == -1)
            {
                return;
            }
            #region String Builder
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE tours SET ");
            sb.Append(TOUR_TABLE_COLUMNS.name.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.distance.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.distance.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_name.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_x.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_x.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_y.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.sl_location_y.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_name.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_name.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_x.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_x.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_y.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.el_location_y.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.description.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.description.ToString());
            sb.Append(", ");
            sb.Append(TOUR_TABLE_COLUMNS.information.ToString());
            sb.Append("=@");
            sb.Append(TOUR_TABLE_COLUMNS.information.ToString());
            sb.Append(" WHERE tour_id=@tour_id");
            #endregion
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.name.ToString(), DbType.String, NewTour.name);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.distance.ToString(), DbType.Decimal, NewTour.distance);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.sl_location_name.ToString(), DbType.String, NewTour.sl_name);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.sl_location_x.ToString(), DbType.Decimal, NewTour.sl_x);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.sl_location_y.ToString(), DbType.Decimal, NewTour.sl_y);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.el_location_name.ToString(), DbType.String, NewTour.el_name);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.el_location_x.ToString(), DbType.Decimal, NewTour.el_x);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.el_location_y.ToString(), DbType.Decimal, NewTour.el_y);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.description.ToString(), DbType.String, NewTour.routeDescription);
            database.DefineParameter(command, TOUR_TABLE_COLUMNS.information.ToString(), DbType.String, NewTour.routeInformation);
            database.DefineParameter(command, "tour_id", DbType.Int32, NewTour.id);
            database.ExecuteNonQuery(command);
        }

        public int getTourId(string name)
        {
            #region String Builder
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append(TOUR_TABLE_COLUMNS.tour_id.ToString());
            sb.Append(" FROM tours WHERE name=@name");
            #endregion
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, "name", DbType.String, name);

            IDataReader reader = database.ExecuteReader(command);
            reader.Read();
            int id = reader.GetInt32(0);
            database.CloseConn();
            return id;
        }


        public List<DataAccess.ILog> GetLogs()
        {
            #region String Builder
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append(LOGS_TABLE_COLUMNS.log_id.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.name.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.route_id.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.date.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.report.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.duration.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.averageSpeed.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.topSpeed.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.calories.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.rating.ToString());
            sb.Append(" FROM logs");
            #endregion

            List<ILog> logList = new List<ILog>();
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            IDataReader reader = database.ExecuteReader(command);
            while (reader.Read())
            {
                string date;
                if (reader.IsDBNull(3))
                {
                    date = null;
                } else
                {
                    date = reader.GetDateTime(3).ToString();
                }
                logList.Add(new Log(reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetString(4),
                    reader.GetFloat(5),
                    reader.GetInt32(9),
                    reader.GetInt32(6),
                    reader.GetInt32(7),
                    reader.GetInt32(8),
                    date));
            }
            database.CloseConn();
            return logList;
        }

        public void insertLog(Log NewLog)
        {
            #region String Building
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into logs (");
            sb.Append(LOGS_TABLE_COLUMNS.name.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.route_id.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.date.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.report.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.duration.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.averageSpeed.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.topSpeed.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.calories.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.rating.ToString());
            sb.Append(") VALUES (");
            sb.Append("@");
            sb.Append(LOGS_TABLE_COLUMNS.name.ToString());
            sb.Append(", @");
            sb.Append(LOGS_TABLE_COLUMNS.route_id.ToString());
            sb.Append(", @");
            sb.Append(LOGS_TABLE_COLUMNS.date.ToString());
            sb.Append(", @");
            sb.Append(LOGS_TABLE_COLUMNS.report.ToString());
            sb.Append(", @");
            sb.Append(LOGS_TABLE_COLUMNS.duration.ToString());
            sb.Append(", @");
            sb.Append(LOGS_TABLE_COLUMNS.averageSpeed.ToString());
            sb.Append(", @");
            sb.Append(LOGS_TABLE_COLUMNS.topSpeed.ToString());
            sb.Append(", @");
            sb.Append(LOGS_TABLE_COLUMNS.calories.ToString());
            sb.Append(", @");
            sb.Append(LOGS_TABLE_COLUMNS.rating.ToString());
            sb.Append(")");
            #endregion

            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.name.ToString(), DbType.String, NewLog.logTitle);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.route_id.ToString(), DbType.Int32, NewLog.route_id);
            if (string.IsNullOrEmpty(NewLog.date))
            {
                database.DefineParameter(command, LOGS_TABLE_COLUMNS.date.ToString(), DbType.DateTime, DBNull.Value);
            } else
            {
                database.DefineParameter(command, LOGS_TABLE_COLUMNS.date.ToString(), DbType.DateTime, DateTime.Parse(NewLog.date, new CultureInfo("en-GB")));
            }
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.report.ToString(), DbType.String, NewLog.report);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.duration.ToString(), DbType.Decimal, NewLog.duration);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.averageSpeed.ToString(), DbType.Decimal, NewLog.averageSpeed);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.topSpeed.ToString(), DbType.Decimal, NewLog.topSpeed);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.calories.ToString(), DbType.Decimal, NewLog.calories);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.rating.ToString(), DbType.Int32, NewLog.rating);
            database.ExecuteNonQuery(command);
            database.CloseConn();
        }

        public ILog getLog(int id)
        {
            #region String Builder
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append(LOGS_TABLE_COLUMNS.log_id.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.name.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.route_id.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.date.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.report.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.duration.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.averageSpeed.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.topSpeed.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.calories.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.rating.ToString());
            sb.Append(" FROM logs WHERE log_id=@log_id");
            #endregion

            List<ILog> logList = new List<ILog>();
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, "log_id", DbType.Int32, id);

            IDataReader reader = database.ExecuteReader(command);
            reader.Read();
            ILog newLog = new Log(reader.GetInt32(0),
                reader.GetString(1),
                reader.GetInt32(2),
                reader.GetString(4),
                reader.GetFloat(5),
                reader.GetInt32(9),
                reader.GetInt32(6),
                reader.GetInt32(7),
                reader.GetInt32(8),
                reader.GetDateTime(3).ToString());
            database.CloseConn();
            return newLog;
        }

        public void deleteLog(int id)
        {
            #region String Builder
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM logs WHERE log_id=@log_id");
            #endregion
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, "log_id", DbType.Int32, id);
            database.ExecuteNonQuery(command);
            database.CloseConn();
        }

        public void modifyLog(ILog NewLog)
        {
            #region String BUilder
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE logs SET ");

            sb.Append(LOGS_TABLE_COLUMNS.name.ToString());
            sb.Append("=@");
            sb.Append(LOGS_TABLE_COLUMNS.name.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.route_id.ToString());
            sb.Append("=@");
            sb.Append(LOGS_TABLE_COLUMNS.route_id.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.date.ToString());
            sb.Append("=@");
            sb.Append(LOGS_TABLE_COLUMNS.date.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.report.ToString());
            sb.Append("=@");
            sb.Append(LOGS_TABLE_COLUMNS.report.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.duration.ToString());
            sb.Append("=@");
            sb.Append(LOGS_TABLE_COLUMNS.duration.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.averageSpeed.ToString());
            sb.Append("=@");
            sb.Append(LOGS_TABLE_COLUMNS.averageSpeed.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.topSpeed.ToString());
            sb.Append("=@");
            sb.Append(LOGS_TABLE_COLUMNS.topSpeed.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.calories.ToString());
            sb.Append("=@");
            sb.Append(LOGS_TABLE_COLUMNS.calories.ToString());
            sb.Append(", ");
            sb.Append(LOGS_TABLE_COLUMNS.rating.ToString());
            sb.Append("=@");
            sb.Append(LOGS_TABLE_COLUMNS.rating.ToString());
            sb.Append(" WHERE log_id=@log_id");
            #endregion
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.name.ToString(), DbType.String, NewLog.logTitle);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.route_id.ToString(), DbType.Int32, NewLog.route_id);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.date.ToString(), DbType.Date, DateTime.Parse(NewLog.date, new CultureInfo("en-GB")));
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.report.ToString(), DbType.String, NewLog.report);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.duration.ToString(), DbType.Decimal, NewLog.duration);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.averageSpeed.ToString(), DbType.Decimal, NewLog.averageSpeed);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.topSpeed.ToString(), DbType.Decimal, NewLog.topSpeed);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.calories.ToString(), DbType.Decimal, NewLog.calories);
            database.DefineParameter(command, LOGS_TABLE_COLUMNS.rating.ToString(), DbType.Int32, (int)NewLog.rating);
            database.DefineParameter(command, "log_id", DbType.Int32, NewLog.id);
            database.ExecuteNonQuery(command);
        }

        public int getLogId(string name)
        {
            #region String Builder
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT log_id ");
            sb.Append(TOUR_TABLE_COLUMNS.tour_id.ToString());
            sb.Append(" FROM logs WHERE name=@name");
            #endregion
            Postgre_Database database = new Postgre_Database();
            DbCommand command = database.CreateCommand(sb.ToString());
            database.DefineParameter(command, "name", DbType.String, name);

            IDataReader reader = database.ExecuteReader(command);
            reader.Read();
            int id = reader.GetInt32(0);
            database.CloseConn();
            return id;
        }

        public void exportTour(DataAccess.ITour tour, string path)
        {
            string[] pathlist = path.Split("/");
            string pathDir = path.Remove(path.Length - pathlist[pathlist.Length - 1].Length);
            if (!Directory.Exists(pathDir))
            {
                pathlist = path.Split("\\");
                pathDir = path.Remove(path.Length - pathlist[pathlist.Length - 1].Length);
                if (!Directory.Exists(pathDir))
                {
                    throw new WrongFilePathException();
                }
            }


            string serialized = JsonConvert.SerializeObject(tour);
            File.WriteAllText(path, serialized);
        }
        public DataAccess.ITour importTour(string path) {

            string[] pathlist = path.Split("/");
            string pathDir = path.Remove(path.Length - pathlist[pathlist.Length - 1].Length);
            Console.WriteLine(pathDir);
            if (!Directory.Exists(pathDir))
            {
                pathlist = path.Split("\\");
                pathDir = path.Remove(path.Length - pathlist[pathlist.Length - 1].Length);
                Console.WriteLine(pathDir);

                if (!Directory.Exists(pathDir))
                {
                    throw new WrongFilePathException();
                }
            }
            Console.WriteLine(pathDir);

            string serialized = File.ReadAllText(path);
            Console.WriteLine(serialized);
            Tour tour = JsonConvert.DeserializeObject<Tour>(serialized);
            return tour;
        }
    }
    public class WrongFilePathException : Exception
    {
        public WrongFilePathException() { }
        public WrongFilePathException(string message)
            : base(message)
        { }
    }
}
