using System;
using System.Collections.Generic;
using System.Text;
using YesSql.Indexes;

namespace FuturifyModule.Indexes
{
    public class ApiLeaderIndex : MapIndex
    {
        public string FullName { get; set; }
    }
}
