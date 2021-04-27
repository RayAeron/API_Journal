using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API_Journal.Entities;

namespace API_Journal.Models
{
    public class ResponseGroup
    {
        public ResponseGroup(group responsGroup)
        {
            id_group = responsGroup.id_group;
            Branch_code = responsGroup.Branch_code;
            Name_group = responsGroup.Name_group;
        }

        public int id_group { get; set; }
        public string Name_group { get; set; }
        public string Branch_code { get; set; }
        public string Branch_name { get; set; }
    }
}