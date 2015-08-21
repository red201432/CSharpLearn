using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
namespace QueryDB
{
    [Table(Name="tMapxData")]
    class tMapxData
    {
        [Column(IsPrimaryKey=true,CanBeNull=false)]
        public int id{get;set;}

         [Column]
        public string TableName{get;set;}
         [Column]
        public int  IDForTable{get;set;}
         [Column]
        public decimal Lo {get;set;}
          [Column]
        public decimal La{get;set;}
          [Column]
          public bool IsExcute { get; set; }
    }
}
