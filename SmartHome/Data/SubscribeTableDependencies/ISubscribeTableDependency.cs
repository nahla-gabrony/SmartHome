﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.SubscribeTableDependencies
{
    public interface ISubscribeTableDependency
    {
        void SubscribeTableDependency(string connectionString);
    }
}
