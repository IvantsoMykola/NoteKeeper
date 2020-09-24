using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteKeeper.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string NoteText { get; set; }

        public DateTime CreationDateTime { get; set; }  
    }
}
