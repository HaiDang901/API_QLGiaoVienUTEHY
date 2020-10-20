using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_SalaryRaise
    {
        public int ID_Raise { get; set; }
        public int? ID_Salary { get; set; }
        public int? ID_Wage { get; set; }
        public double? CoeffOld_Raise { get; set; }
        public double? CoeffNew_Raise { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher_Salary ID_SalaryNavigation { get; set; }
        public virtual Teacher_Wage ID_WageNavigation { get; set; }
    }
}
