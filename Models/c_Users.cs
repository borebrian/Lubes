﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lubes.Models
{
    public class c_Users
    {
       
        
        [Required]
        [Display(Name = "Full names", Prompt = "Full names")]

        public string Full_name { get; set; }

       

     
        [Required]
        [Display(Name = "Phone number", Prompt = "Phone number")]

        [DataType(DataType.PhoneNumber)]

        public string strPhone { get; set; }
        [Required]
        [Display(Name = "Password", Prompt = "Password")]

        [DataType(DataType.Password)]
        public string strPassword { get; set; }
        [Key]

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        [Display(Name = "National id", Prompt = "Natianal id")]

        public string strUserId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Select role", Prompt = "")]

        
        public string strRole { get; set; }

   
    }
   
}
