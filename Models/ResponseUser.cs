using API_Journal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Journal.Models
{
    public class ResponseUser
    {
        public ResponseUser(users responseUser)
        {
            //id_user = responseUser.id_user;
            //Surname = responseUser.Surname;
            //Name = responseUser.Name;
            //Patronymic = responseUser.Patronymic;
            Email = responseUser.Email;
            Pass = responseUser.Pass;
            //is_staff = responseUser.is_staff;
            //id_group = (int)responseUser.id_group;
        }

        //public int id_user { get; set; }
        //public string Surname { get; set; }
        //public string Name { get; set; }
        //public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        //public string is_staff { get; set; }
        //public int id_group { get; set; }

    }
}