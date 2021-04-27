using API_Journal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Journal.Models
{
    public class ResponseDiscipline
    {
        public ResponseDiscipline(discipline responsdiscipline)
        {
            id_discipline = responsdiscipline.id_discipline;
            Name_discipline = responsdiscipline.Name_discipline;
            id_group = (int)responsdiscipline.id_group;
            id_teacher = (int)responsdiscipline.id_teacher;
        }

        public int id_discipline { get; set; }
        public string Name_discipline { get; set; }
        public int id_group { get; set; }
        public int id_teacher { get; set; }
    }
}