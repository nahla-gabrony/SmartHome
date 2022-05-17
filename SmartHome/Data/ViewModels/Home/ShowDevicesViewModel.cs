﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.ViewModels.Home
{
    public class ShowDevicesViewModel
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int DeviceId { get; set; }

        public string DeviceName { get; set; }
        public string DeviceNameId { get; set; }

    }
}
