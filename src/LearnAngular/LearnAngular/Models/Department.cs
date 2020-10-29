using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnAngular.Models
{
    public class Department
    {
        //[JsonProperty("id")]
        public int DepartmentId { get; set; }

        //[JsonProperty("id")]
        public string DepartmentName { get; set; }
    }
}