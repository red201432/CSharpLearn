using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicEightBallService
{
    public class MagicEightBallService1 : IEightBall
    {
        public MagicEightBallService1()
        {
            Console.WriteLine("The 8-Ball awaits your question.....");
        }
        public string ObtainAnswerToQuestion(string userQuestion)
        {
            string[] answers = { "Future Uncertain", "Yes" ,"NO","Hazy","Ask again later","Definitely"};
            Random r = new Random();
            return answers[r.Next(answers.Length)];
        }
    }
}
