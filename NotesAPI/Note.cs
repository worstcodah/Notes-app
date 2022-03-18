﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPI
{
    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }

        public Guid Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
    }
}
