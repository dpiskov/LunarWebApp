namespace LunarWebApp.Models
{
    public class Notebook
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public  required ICollection<Folder> Folders { get; set; }
        public  required ICollection<Note> Notes { get; set; }
    }
}
