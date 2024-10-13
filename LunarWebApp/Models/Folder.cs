namespace LunarWebApp.Models
{
    public class Folder
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid NotebookId { get; set; }
        public required Notebook Notebook { get; set; }
        public Guid ParentFolderId { get; set; }
        public required Folder ParentFolder { get; set; }
        public required ICollection<Folder> Folders { get; set; }
        public required ICollection<Note> Notes { get; set; }
    }
}
