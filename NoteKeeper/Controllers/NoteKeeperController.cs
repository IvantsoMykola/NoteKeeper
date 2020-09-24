using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using NoteKeeper.Models;

namespace NoteKeeper.Controllers
{
    [ApiController]
    [Route("notes")]
    public class NoteKeeperController : ControllerBase
    {
        private readonly ILogger<NoteKeeperController> _logger;

        public NoteKeeperController(ILogger<NoteKeeperController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Note> Get()
        {
            if (TestNoteData.Notes != null)
            {
                var sdf = TestNoteData.Notes;
                return TestNoteData.Notes.ToArray();
            }
            else
            {
                return new Note[] { };
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            if (TestNoteData.Notes != null)
            {
                var result = TestNoteData.Notes.Find(n => n.Id == id);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Note> Post(Note note)
        {
            if (note == null)
            {
                return BadRequest();
            }

            var maxId = TestNoteData.Notes.Max(item => item.Id);
            note.Id = maxId + 1;
            TestNoteData.Notes.Add(note);
            return Ok(note);
        }

        
        [HttpPut]
        public  ActionResult<Note> Put(Note note)
        {
            if (TestNoteData.Notes != null && note != null)
            {
                Note currentNote = TestNoteData.Notes.Find(item => item.Id == note.Id);
                if (currentNote != null)
                {
                    TestNoteData.Notes.Remove(currentNote);
                    TestNoteData.Notes.Add(note);
                    return Ok(currentNote);
                }
                else
                {
                    return NotFound(note);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpDelete("{id}")]
        public  ActionResult<Note> Delete(int id)
        {
            if (TestNoteData.Notes != null )
            {
                Note currentNote = TestNoteData.Notes.Find(item => item.Id == id);
                if (currentNote != null)
                {
                    TestNoteData.Notes.Remove(currentNote);
                    return Ok(currentNote);
                }
                else
                {
                    return NotFound(id);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
