using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_RanksOfficer
    {
        public Teacher_RanksOfficer()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int ID_Ranks { get; set; }
        public string Code_Ranks { get; set; }
        public string Name_Ranks { get; set; }
        public string Descript_Ranks { get; set; }
        public int? status { get; set; }
        public string DP1 { get; set; }
        public string DP2 { get; set; }
        public string Note_Ranks { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
