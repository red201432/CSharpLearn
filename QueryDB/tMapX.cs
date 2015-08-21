using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration.Assemblies;
using System.Configuration;
using System.Management;
using System.Management.Instrumentation;
using System.Resources;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Runtime;
using System.Reflection;
using System.CodeDom;
using System.Data.ProviderBase;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Mapping;
using System.Data.EntityModel;
using System.Data.Linq;
using System.ComponentModel.Design.Serialization;
using System.Data.Linq.Mapping;
namespace QueryDB
{
    [Table(Name="tMapx")]
    public class tMapX
    {
       /// <summary>
       /// 表对应的字段名
       /// </summary>
        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public int id { get; set; }
        
        [Column]
        public decimal lo{get;set;}


        [Column]
        public decimal la { get; set; } 

        [Column]
        public string Geo { get; set; }


    }
}
