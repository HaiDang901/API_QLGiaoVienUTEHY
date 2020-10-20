using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher_SubLession
    {
        public Teacher_SubLession()
        {
            Teacher_SignUp = new HashSet<Teacher_SignUp>();
        }

        public int ID_Sub { get; set; }
        public string Name_Sub { get; set; }
        public string Type_Sub { get; set; }
        public int? Number_credits_Sub { get; set; }
        public int? status { get; set; }
        public string DP1 { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]

        public virtual ICollection<Teacher_SignUp> Teacher_SignUp { get; set; }
    }
}
