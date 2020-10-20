using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_Scientist
    {
        public int ID_Scientist { get; set; }
        public string ID_Teacher { get; set; }
        public string Name_Scientist { get; set; }
        public string Type_Scientist { get; set; }
        public string Link_Scientist { get; set; }
        public string Note_Scientist { get; set; }
        public int? status { get; set; }
        public string DP1 { get; set; }
        public string DP2 { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]

        public virtual Teacher ID_TeacherNavigation { get; set; }
    }
}
