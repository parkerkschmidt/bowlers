﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BowlersApp.Models
{
    public class Bowler
    {

        [Key]
        [Required]
        public int BowlerID { get; set; }

        [Required]
        public string BowlerLastName { get; set; }

        [Required]
        public string BowlerFirstName { get; set; }

        public string BowlerMiddleInit { get; set; }

        [Required]
        public string BowlerAddress { get; set; }

        [Required]
        public string BowlerCity { get; set; }

        [Required]
        public string BowlerState { get; set; }

        [Required]
        public string BowlerZip { get; set; }

        public string BowlerPhoneNumber { get; set; }

        //FK
        public int TeamID { get; set; }
        public Team Team { get; set; }

    }
}
