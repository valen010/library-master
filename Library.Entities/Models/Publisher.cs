using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Entities.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //[JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }
    }
}
