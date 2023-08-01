namespace Xmind.Models
{
    public class Notes
    {
        public Plain plain { get; set; }
        public RealHTML realHTML { get; set; }

        public void AddNote(Notes notes, string content)
        {
            this.plain.AddNote(plain, content);
        }
    }
}