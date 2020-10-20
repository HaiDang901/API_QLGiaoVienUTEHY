using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_Faculty
    {
        public Teacher_Faculty()
        {
            Teacher_Position = new HashSet<Teacher_Position>();
            Teacher_Subject = new HashSet<Teacher_Subject>();
        }

        public int ID_Faculty { get; set; }
        public string Name_Faculty { get; set; }
        public string Address_Faculty { get; set; }
        public string Learder_Faculty { get; set; }
        public string Website_Facuty { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher_Position> Teacher_Position { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher_Subject> Teacher_Subject { get; set; }
    }
}
