using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Review.Web.Models
{
    public class AdminModel
    {
        public string Organization { get; set; }

        public string Address { get; set; }

        public int Rate { get; set; }

        public int Id { get; set; }

        public ReviewInfoModel ReviewInfo { get; set; }
    }
}