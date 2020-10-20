using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_Wage
    {
        public Teacher_Wage()
        {
            Teacher_Salary = new HashSet<Teacher_Salary>();
            Teacher_SalaryRaise = new HashSet<Teacher_SalaryRaise>();
            Teachers = new HashSet<Teacher>();
        }

        public int ID_Wage { get; set; }
        public string Name_Wage { get; set; }
        public double? Coeff_Wage { get; set; }
        public int? status { get; set; }
        public string Group_Wage { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher_Salary> Teacher_Salary { get; set; }
        public virtual ICollection<Teacher_SalaryRaise> Teacher_SalaryRaise { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
