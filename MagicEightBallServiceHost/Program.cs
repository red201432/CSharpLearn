using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using MagicEightBallService;

namespace MagicEightBallServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Console Based WCF Host *****");
            using (ServiceHost sh = new ServiceHost(typeof(MagicEightBallService1)))//,new Uri[]{new Uri("http://localhost:8080/MagicEightBallService")}))
            {               
                sh.Open();
                //DisplayHostInfo(sh);
                Console.WriteLine("The Host is ready");
                Console.ReadLine();
            }            
        }
        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine();
            Console.WriteLine("***** Host Line *****");
            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine("Address: {0}", se.Address);
                Console.WriteLine("BInding :{0}", se.Binding.Name);
                Console.WriteLine("Contract:{0}", se.Contract.Name);
                Console.WriteLine();
            }
            Console.WriteLine("************************");
        }
    }
}
