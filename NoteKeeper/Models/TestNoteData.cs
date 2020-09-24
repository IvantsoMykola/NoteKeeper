using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteKeeper.Models
{
    public class TestNoteData
    {
        public static List<Note> Notes
        {
            get
            {
                if (notes != null)
                {
                    return notes;
                }
                else
                {
                    GenerateData();
                    return notes;
                }
            }
            private set
            {
                notes = value;
            }
        }

        private static string textTemplate = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
            "Nulla blandit ultricies finibus.Sed hendrerit ipsum non dui iaculis posuere. " +
            "Vivamus neque quam, ultrices a justo tincidunt, ullamcorper ornare metus. " +
            "Aenean euismod in odio eget hendrerit.Fusce hendrerit purus eget ultrices consectetur.";

        private static List<Note> notes = null;

        private static void GenerateData()
        {
            
            List<Note> result = new List<Note>();
            for(int i = 0; i < 10; i++)
            {
                result.Add( new Note() { Id = i, Title = "Note " + i, NoteText = textTemplate, CreationDateTime = DateTime.UtcNow.AddDays(i) } );
            }
            Notes = result;
        }

    }
}
