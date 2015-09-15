using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace MagicEightBallService
{
    [ServiceContract]//使接口成为WCF所提供的服务 定义契约
    interface IEightBall
    {   
        [OperationContract]//WCF中使用的方法必须用它进行修饰
        string ObtainAnswerToQuestion(string userQuestion);
    }
}
