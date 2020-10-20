using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_DiscipRewards
    {
        public int ID_DisRewards { get; set; }
        public string ID_Teacher { get; set; }
        public string Name_DisRewards { get; set; }
        public string Reason_DisRewards { get; set; }
        public DateTime? Day_DisRewards { get; set; }
        public string Form_DisRewards { get; set; }
        public string Note_DisRewards { get; set; }
        public int? status { get; set; }
        public string DP1 { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher ID_TeacherNavigation { get; set; }
    }
}
