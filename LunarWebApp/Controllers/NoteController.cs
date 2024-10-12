using Microsoft.AspNetCore.Mvc;

using LunarWebApp.Models; // Include the Note model

namespace LunarWebApp.Controllers
{
    public class NoteController : Controller
    {
        //In-memory list for now (will replace with database later)
        private static List<Note> notes = new List<Note>();

        //Action to show all notes
        public IActionResult Index()
        {
            return View(notes); //Pass the list of notes to the view
        }

        //GET: Action to display form for creating a new note
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            //Assign a unique id to the note
            note.Id = Guid.NewGuid();

            //Add the note to the list
            notes.Add(note);

            return RedirectToAction(nameof(Index));
        }

        //Action to show details of a specific note
        public IActionResult Details(Guid id)
        {
            //Find the note with the given id
            Note note = notes.Find(n => n.Id == id);

            if (note == null)
            {
                return NotFound(); // Return 404 Not Found
            }

            return View(note);
        }
    }
}
