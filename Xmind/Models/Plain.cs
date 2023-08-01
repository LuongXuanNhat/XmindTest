namespace Xmind.Models
{
    public class Plain
    {
        public string content { get; set; }

        public void AddNote(Plain plain, string content)
        {
            plain.content = content;
        }

        public void AddNote(string content)
        {
            content = content;
        }
    }
}