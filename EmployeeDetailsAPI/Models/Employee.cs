//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeDetailsAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string skills { get; set; }
        public string address { get; set; }
        public string role { get; set; }
        public Nullable<decimal> salary { get; set; }
        public string statuses { get; set; }
    }
}
