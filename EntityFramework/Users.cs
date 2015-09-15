using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.EntityModel;
using System.Data.Mapping;
using System.Data.Common;
using System.Data.Objects;

namespace EntityFramework
{
    class UsersContext : ObjectContext
    {
        private ObjectSet<tMapx> _tMapx;
        public UsersContext()
            : base("name=TXGPS_2011Entities1", "TXGPS_2011Entities1")//名字竟然相同！！！
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
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
    }
}
