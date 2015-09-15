using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using System.Data.Objects;


namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Fun with  ADO.NET EF ***");
            printAllUsers();
           // AddNewMapData();
           // UpdateMapData();
            CallProcedure();
        }
        static void printAllUsers()
        {
            using (UsersContext user = new UsersContext())
            {   
                //Console.WriteLine(user.Connection);
                // new {item.ID,item.Geo} 这是暴露出来的数据
                var mapdata = (from item in user.tMapx select new { item.ID, item.Geo }).Take(10);//使用LINQ对数据进行查询，如果要立即执行查询并得到一个副本时，需要使用ToList<T>() ToArray<T>() ToDictionary<K,V>
                foreach (var item in mapdata)
                {
                    Console.WriteLine(item.ID + "---" + item.Geo);
                }
            }
        }

        static void CallProcedure()
        {
             
            using (UsersContext user = new UsersContext())
            {
                ObjectParameter input = new ObjectParameter("ID", 748909);//输入参数
                ObjectParameter output = new ObjectParameter("Geo", typeof(string));
                user.ExecuteFunction("select_terminal", input, output);
                
                Console.WriteLine(output.Value);
            }
        
        }

        static void AddNewMapData()
        {
            using (UsersContext user = new UsersContext())
            {
                try
                {
                    user.tMapx.AddObject(new tMapx() {La=123.46544M,Lo=110.23564M,Geo="山东省青岛市高新区" });
                    user.SaveChanges();
                    Console.WriteLine("插入数据成功");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    throw;
                }
            }
        }
        /// <summary>
        /// 删除时，首先要查找到要删除的数据，传递给一个EntityKey对象
        /// </summary>
        static void DeleteMapData()
        {
            using (UsersContext user = new UsersContext())
            {

                EntityKey key = new EntityKey("TXGPS_2011Entities1.tMapx", "ID", 748910);//第一个参数是由实体容器名称限定的实体集名称
                    tMapx mapx = (tMapx)user.GetObjectByKey(key);
                    if (mapx != null)
                    {
                        user.tMapx.DeleteObject(mapx);
                        user.SaveChanges();
                        Console.WriteLine("删除数据成功");
                    }              
            }
        }

        static void UpdateMapData()
        {
            using (UsersContext user = new UsersContext())
            {

                EntityKey key = new EntityKey("TXGPS_2011Entities1.tMapx", "ID", 748909);//第一个参数是由实体容器名称限定的实体集名称
                tMapx mapx = (tMapx)user.GetObjectByKey(key);
                if (mapx != null)
                {
                    mapx.Geo = "青岛市高新区";
                    user.SaveChanges();
                    Console.WriteLine("更新数据成功");
                }
            }
        }
    }
}
