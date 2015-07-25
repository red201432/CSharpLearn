/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.17929
 *机器名称：ANDY-PC
 *公司名称：Microsoft
 *命名空间：Delegate
 *文件名：  MathOperations
 *版本号：  V1.0.0.0
 *唯一标识：e80be4fe-807d-4272-9044-203c5cb17de1
 *当前的用户域：Andy-PC
 *创建人：  Andy
 *电子邮箱：
 *创建时间：2015/7/25 15:51:23
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2015/7/25 15:51:23
 *修改人： Andy
 *版本号： V1.0.0.0
 *描述：
 *
/************************************************************************************/
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Delegate
{
    class MathOperations
    {
        public  static double MultiplyByTwo(double value){
            return value * 2;
        }
        public static double Square(double value)
        {
            return value * value;
        }
    }
}
