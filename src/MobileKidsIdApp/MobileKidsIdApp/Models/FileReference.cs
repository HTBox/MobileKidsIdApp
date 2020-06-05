namespace MobileKidsIdApp.Models
{
    // TODO: Rework. "Files" don't mean much unless there's a way to share them into the app or download them. What is a "file"? How does the app obtain a "file"? 
    public class FileReference
    {
        public string ResourceType { get; set; }

        public string Description { get; set; }

        public string FileName { get; set; }
    }
}
