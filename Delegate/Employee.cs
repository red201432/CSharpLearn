/************************************************************************************
 * Copyright (c) 2015Microsoft All Rights Reserved.
 * CLR版本： 4.0.30319.17929
 *机器名称：ANDY-PC
 *公司名称：Microsoft
 *命名空间：Delegate
 *文件名：  Employee
 *版本号：  V1.0.0.0
 *唯一标识：a27b3038-fcbc-44f2-8845-d5f454c6a53e
 *当前的用户域：Andy-PC
 *创建人：  Andy
 *电子邮箱：thehonest@163.com
 *创建时间：2015/7/25 16:24:50
 *描述：
 *
 *=====================================================================
 *修改标记
 *修改时间：2015/7/25 16:24:50
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
    class Employee
    {
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
        public string Name;
        public decimal Salary;

        public override string ToString()
        {
            return string.Format("{0},{1:C}",Name,Salary);

        }

        public static bool CompareSalary(Employee e1, Employee e2)
        {
            return e1.Salary < e2.Salary;
        }
    }
}
