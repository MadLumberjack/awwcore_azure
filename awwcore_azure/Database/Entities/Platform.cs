﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace awwcore_azure.Database.Entities
{
    [Table("platforms")]
    public class Platform
    {
        [Column("id")]
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        [Column("name")]
        [MaxLength(25)]
        [Required]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<GamePlatform> GamePlatforms { get; set; }
    }
}
