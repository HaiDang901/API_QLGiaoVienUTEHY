using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_Salary
    {
        public Teacher_Salary()
        {
            Teacher_SalaryRaise = new HashSet<Teacher_SalaryRaise>();
        }

        public int ID_Salary { get; set; }
        public int? ID_Wage { get; set; }
        public int? Wage_Salary { get; set; }
        public int? Basic_Salary { get; set; }
        public int? Sub_Salary { get; set; }
        public string Date_Salary { get; set; }
        public DateTime? DateIcre_Salary { get; set; }
        public int? status { get; set; }
        public string DP1 { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher_Wage ID_WageNavigation { get; set; }
        public virtual ICollection<Teacher_SalaryRaise> Teacher_SalaryRaise { get; set; }
    }
}
