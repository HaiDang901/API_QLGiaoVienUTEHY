﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB_DoAn5.Models
{
    public partial class user2
    {

        public user2()
        {
        }

        public string user_id { get; set; }
        public string hoten { get; set; }
        public DateTime? ngaysinh { get; set; }
        public string diachi { get; set; }
        public string gioitinh { get; set; }
        public string email { get; set; }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }
        public string role { get; set; }
        public string token { get; set; }
        public string image_url
        {
            get; set;
        }

        [Newtonsoft.Json.JsonIgnore]
        [System.Xml.Serialization.XmlIgnore]
    }
}
