using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_Position
    {
        public Teacher_Position()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int ID_Position { get; set; }
        public int? ID_Faculty { get; set; }
        public string Name_Position { get; set; }
        public int? Cent_Position { get; set; }
        public string Note_Position { get; set; }
        public string Respon_Position { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher_Faculty ID_FacultyNavigation { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
