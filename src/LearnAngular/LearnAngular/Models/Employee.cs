﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnAngular.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string DateofJoining { get; set; }
        public string PhotoFileName { get; set; }
    }
}