using API_Journal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Journal.Models
{
    public class ResponseMark
    {
        public ResponseMark(mark responsMark)
        {
            Mark = responsMark.Mark;
            Date_mark = responsMark.Date_mark;
            id_discipline = (int)responsMark.id_discipline;
            id_student = (int)responsMark.id_student;
        }

        public int id_mark { get; set; }
        public string Mark { get; set; }
        public string Date_mark { get; set; }
        public int id_discipline { get; set; }
        public int id_student { get; set; }
    }
}
