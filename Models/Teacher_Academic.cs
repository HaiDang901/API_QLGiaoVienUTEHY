using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_Academic
    {
        public int ID_Academic { get; set; }
        public string ID_Teacher { get; set; }
        public string Name_Academic { get; set; }
        public DateTime? YearGredu_Academic { get; set; }
        public string Certificate_Academic { get; set; }
        public string Specialy__Academic { get; set; }
        public string UnitWork_Academic { get; set; }
        public string LevelIT_Academic { get; set; }
        public string LevelLag_Academic { get; set; }
        public string YeasTeaching_Academic { get; set; }
        public int? status { get; set; }
        public string DP1 { get; set; }
        public string DP2 { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher ID_TeacherNavigation { get; set; }
    }
}
