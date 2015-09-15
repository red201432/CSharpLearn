using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SimpleSerialize
{
    [Serializable]
    class StringData:ISerializable
    {
        private string dataItemOne = "first data block";
        private string dataItemTwo = "second data block";
        public StringData() { }
        protected StringData(SerializationInfo si, StreamingContext ctx)
        {
            //从流中得到合并的成员变量
            dataItemOne = si.GetString("First_Item").ToLower();
            dataItemTwo = si.GetString("Second_Item").ToLower();

        }

        void ISerializable.GetObjectData(SerializationInfo si, StreamingContext sc)
        {
            //用格式化数据填充 SerializationInfo 对象
            si.AddValue("First_Item", dataItemOne.ToUpper());
            si.AddValue("Second_Item", dataItemTwo.ToUpper());
        }
    }
}
