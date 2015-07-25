/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.17929
 *机器名称：ANDY-PC
 *公司名称：Microsoft
 *命名空间：Delegate
 *文件名：  BubbleSort
 *版本号：  V1.0.0.0
 *唯一标识：dce54b80-78ab-4cc5-b47d-e1569f4c1035
 *当前的用户域：Andy-PC
 *创建人：  Andy
 *电子邮箱：thehonest@163.com
 *创建时间：2015/7/25 16:18:18
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2015/7/25 16:18:18
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
    /// <summary>
    /// Func<T,T,bool> 是系统定义的委托类型
    /// 定义如下：
    /// public delegate TResult Func<in T1, in T2, out TResult>(
	/// T1 arg1,
	/// T2 arg2
    ///  )
    /// 封装一个具有两个参数并返回 TResult 参数指定的类型值的方法。
    /// </summary>
    class BubbleSort
    {
        static public void Sort<T>(IList<T> sortArray, Func<T, T, bool> comparison)
        {
            bool swapped = true;
            do{
                swapped=false;
                for(int i=0;i<sortArray.Count-1;i++)
                {
                    if(comparison(sortArray[i+1],sortArray[i]))
                    {
                        T temp=sortArray[i];
                        sortArray[i]=sortArray[i+1];
                        sortArray[i+1]=temp;
                        swapped=true;
                    }
                }
            }while(swapped);

        }
    }
}
