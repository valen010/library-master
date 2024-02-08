﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Library.Entities.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
