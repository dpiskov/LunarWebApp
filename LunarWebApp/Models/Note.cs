namespace LunarWebApp.Models
{
    public class Note
    {
        public Note()
        {
            DateCreated = DateTime.Now;
        }

        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Body { get; set; }
        public Guid NotebookId { get; set; }
        public Notebook Notebook { get; set; }
        public Guid FolderId { get; set; }
        public Folder Folder { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastOpened { get; set; }


    }
}
