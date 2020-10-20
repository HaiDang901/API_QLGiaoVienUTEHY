using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_Subject
    {
        public Teacher_Subject()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int ID_Subject { get; set; }
        public int? ID_Faculty { get; set; }
        public string Name_Subject { get; set; }
        public string Address_Subject { get; set; }
        public string Phone_Subject { get; set; }
        public string Leader { get; set; }
        public string Leader_Assis { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher_Faculty ID_FacultyNavigation { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
