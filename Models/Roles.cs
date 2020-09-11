using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lubes.Models
{
    public class Roles
    {
        [Key]
        public int ID { get; set; }
        public int Role_id { get; set; }
        public string Role_name { get; set; }
    }
}
