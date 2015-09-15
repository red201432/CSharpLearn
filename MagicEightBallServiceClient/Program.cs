using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MagicEightBallServiceClient.ServiceReference1;

namespace MagicEightBallServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" ****** Ask the question you want ****");
          // MagicEightBallService1 ball = new MagicEightBallService1(); //引入类型来操作
            using (EightBallClient ball = new EightBallClient())//通过引入服务生成的代码来操作
            {
            while (true)
            {
                Console.WriteLine(" Your question");

                string question = Console.ReadLine();

                string answer = ball.ObtainAnswerToQuestion(question);

                Console.WriteLine(answer);
            }
        }
        }
    }
}
