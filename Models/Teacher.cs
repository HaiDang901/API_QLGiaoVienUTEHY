using System;
using System.Collections.Generic;

namespace DB_DoAn5.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Teacher_Academic = new HashSet<Teacher_Academic>();
            Teacher_Contract = new HashSet<Teacher_Contract>();
            Teacher_DiscipRewards = new HashSet<Teacher_DiscipRewards>();
            Teacher_Scientist = new HashSet<Teacher_Scientist>();
            Teacher_SignUp = new HashSet<Teacher_SignUp>();
        }

        public string ID_Teacher { get; set; }
        public int? ID_Subject { get; set; }
        public int? ID_Position { get; set; }
        public int? ID_Ranks { get; set; }
        public int? ID_Wage { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Name_Teacher { get; set; }
        public string Image_Teacher { get; set; }
        public bool? Gende_Teacher { get; set; }
        public string Phone__Teacher { get; set; }
        public string Email_Teacher { get; set; }
        public DateTime? DateBirth_Teacher { get; set; }
        public string Address_Teacher { get; set; }
        public string CurrentAddress_Teacher { get; set; }
        public string Nation_Teacher { get; set; }
        public string Religion_Teacher { get; set; }
        public string Level_Teacher { get; set; }
        public string Experience_Teacher { get; set; }
        public string IdentityCard_Teacher { get; set; }
        public DateTime? DateRange_Teacher { get; set; }
        public string IssuedBy_Teacher { get; set; }
        public DateTime? DayAdim_Teacher { get; set; }
        public string AddressAdmin_Teacher { get; set; }
        public int? status { get; set; }
        public string DP1 { get; set; }
        public string DP2 { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher_Position ID_PositionNavigation { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher_RanksOfficer ID_RanksNavigation { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher_Subject ID_SubjectNavigation { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual Teacher_Wage ID_WageNavigation { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher_Academic> Teacher_Academic { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher_Contract> Teacher_Contract { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher_DiscipRewards> Teacher_DiscipRewards { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher_Scientist> Teacher_Scientist { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
        public virtual ICollection<Teacher_SignUp> Teacher_SignUp { get; set; }
    }
}
