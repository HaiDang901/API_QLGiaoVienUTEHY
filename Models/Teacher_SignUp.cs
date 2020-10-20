using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_SignUp
    {
        public int ID_SignUp { get; set; }
        public string ID_Teacher { get; set; }
        public int? ID_Sub { get; set; }
        public DateTime? Date_SignUp { get; set; }
        public string Note_SignUp { get; set; }
        public int? status { get; set; }
        public string DP1 { get; set; }
        public string DP2 { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher_SubLession ID_SubNavigation { get; set; }
        public virtual Teacher ID_TeacherNavigation { get; set; }
    }
}
