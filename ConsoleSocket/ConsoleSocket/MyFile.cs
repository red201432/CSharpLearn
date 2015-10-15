using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace ConsoleSocket
{
    /// <summary>
    /// 从文件中获取坐标列表
    /// </summary>
    class MyFile
    {
        private string path;
        public string Path { get; set; }
        Position position = new Position();
        List<Position> positions = new List<Position>();

        /// <summary>
        /// 从文件中获取坐标列表
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>坐标列表</returns>
        public static  List<Position> getPositions(string path){
            if(path!=null){
                try{
                    using(StreamReader sr=new StreamReader(path)){
                        while(!sr.EndOfStream){
                            string readline=sr.ReadLine();
                            string[] points = readline.Split(',').ToArray();
                            position.La = points[0];
                            position.Lo = points[1];
                            positions.Add(position);
                        }
                    }
                }catch(Exception e){
                    Console.WriteLine("无法找到文件："+e.Message);
                }
            }
            return positions;
        }
    }
}
