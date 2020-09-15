using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebApp.Models
{
    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int ClassId { get; set; }
    }
}