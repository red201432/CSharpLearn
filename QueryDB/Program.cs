using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Linq;

namespace QueryDB
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dataConnection = new SqlConnection();
            try
            {
                SqlConnectionStringBuilder SQLConnString = new SqlConnectionStringBuilder();
                SQLConnString.DataSource = ".\\";//连接本地数据库
                SQLConnString.InitialCatalog = "TXGPS_2011";
                SQLConnString.IntegratedSecurity = true;
                dataConnection.ConnectionString = SQLConnString.ConnectionString;
                dataConnection.Open();

                SqlCommand dataCommand = new SqlCommand();
                dataCommand.Connection = dataConnection;
                dataCommand.CommandType = CommandType.Text;
                dataCommand.CommandText = "select * from tUser";

                DataContext db = new DataContext(SQLConnString.ConnectionString);
                Table<tMapX> tMapxs = db.GetTable<tMapX>();            //已经获取数据集
               // var tm = (from t in tMapxs select t).Take(10);// from in select 都是C#关键字，必须小写
                IEnumerable<tMapX> tm = tMapxs.OrderByDescending(ad => ad.id).Take(1);         //降序排列
                Table<tMapxData> tmd=db.GetTable<tMapxData>();
               // Console.WriteLine(tm);
                //tMapX tmapx = tm.Single(t => t.id == 4); //查询单个数据
                //Console.WriteLine(tmapx.Geo);
                foreach (var p in tm)
                {
                    Console.WriteLine(p.id + "--" + p.la + "--" + p.lo + "--" + p.Geo);
                }
                #region LINQ连接表
                var Mapx = from p in tmd join s in tm on p.Lo.ToString() equals (s.lo.ToString()+"00") select new { s.Geo, s.id };
                
                foreach (var p in Mapx)
                {
                    Console.WriteLine(p.id + "--" + p.Geo);
                }
                #endregion
                #region 常规的数据库读取
                //SqlDataReader dataReader = dataCommand.ExecuteReader();
                //while (dataReader.Read())
                //{
                //    int orderid = dataReader.GetInt32(0);
                //    string name = dataReader.GetString(3);
                //    DateTime orderDate = dataReader.GetDateTime(19);
                //    Console.WriteLine(orderid + "--" + name + "--" + orderDate);
                //}
                //dataReader.Close();
                #endregion
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error accessing the database: " + e.Message);
            }
            finally
            {
                dataConnection.Close();
            }

        }
    }
}
