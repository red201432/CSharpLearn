﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace EntityFramework
{
    #region 上下文
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    public partial class TXGPS_2011Entities1 : ObjectContext
    {
        #region 构造函数
    
        /// <summary>
        /// 请使用应用程序配置文件的“TXGPS_2011Entities1”部分中的连接字符串初始化新 TXGPS_2011Entities1 对象。
        /// </summary>
        public TXGPS_2011Entities1() : base("name=TXGPS_2011Entities1", "TXGPS_2011Entities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 TXGPS_2011Entities1 对象。
        /// </summary>
        public TXGPS_2011Entities1(string connectionString) : base(connectionString, "TXGPS_2011Entities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 TXGPS_2011Entities1 对象。
        /// </summary>
        public TXGPS_2011Entities1(EntityConnection connection) : base(connection, "TXGPS_2011Entities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region 分部方法
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet 属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<tMapx> tMapx
        {
            get
            {
                if ((_tMapx == null))
                {
                    _tMapx = base.CreateObjectSet<tMapx>("tMapx");
                }
                return _tMapx;
            }
        }
        private ObjectSet<tMapx> _tMapx;

        #endregion

        #region AddTo 方法
    
        /// <summary>
        /// 用于向 tMapx EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddTotMapx(tMapx tMapx)
        {
            base.AddObject("tMapx", tMapx);
        }

        #endregion

    }

    #endregion

    #region 实体
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TXGPS_2011Model", Name="tMapx")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tMapx : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 tMapx 对象。
        /// </summary>
        /// <param name="id">ID 属性的初始值。</param>
        /// <param name="lo">Lo 属性的初始值。</param>
        /// <param name="la">La 属性的初始值。</param>
        /// <param name="geo">Geo 属性的初始值。</param>
        public static tMapx CreatetMapx(global::System.Int32 id, global::System.Decimal lo, global::System.Decimal la, global::System.String geo)
        {
            tMapx tMapx = new tMapx();
            tMapx.ID = id;
            tMapx.Lo = lo;
            tMapx.La = la;
            tMapx.Geo = geo;
            return tMapx;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal Lo
        {
            get
            {
                return _Lo;
            }
            set
            {
                OnLoChanging(value);
                ReportPropertyChanging("Lo");
                _Lo = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Lo");
                OnLoChanged();
            }
        }
        private global::System.Decimal _Lo;
        partial void OnLoChanging(global::System.Decimal value);
        partial void OnLoChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal La
        {
            get
            {
                return _La;
            }
            set
            {
                OnLaChanging(value);
                ReportPropertyChanging("La");
                _La = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("La");
                OnLaChanged();
            }
        }
        private global::System.Decimal _La;
        partial void OnLaChanging(global::System.Decimal value);
        partial void OnLaChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Geo
        {
            get
            {
                return _Geo;
            }
            set
            {
                OnGeoChanging(value);
                ReportPropertyChanging("Geo");
                _Geo = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Geo");
                OnGeoChanged();
            }
        }
        private global::System.String _Geo;
        partial void OnGeoChanging(global::System.String value);
        partial void OnGeoChanged();

        #endregion

    
    }

    #endregion

    
}
