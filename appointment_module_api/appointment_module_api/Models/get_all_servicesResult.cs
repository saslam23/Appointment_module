﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace appointment_module_api.Models
{
    public partial class get_all_servicesResult
    {
        public long service_id { get; set; }
        public string service_name { get; set; }
        public int business_id { get; set; }
        public int length_minutes { get; set; }
        public string service_category { get; set; }
    }
}
