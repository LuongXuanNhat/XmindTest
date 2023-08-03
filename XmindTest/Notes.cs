namespace XmindTest
{
    public class Notes
    {
        private Plain plain;

        public Plain GetPlain()
        {
            return plain;
        }

        private void SetPlain(Plain value)
        {
            plain = value;
        }

        public ReadHTML readHTML { get; set; }

        internal void Add_Notes(string content)
        {
            if (plain == null) plain = new Plain();
            plain.Add_Notes(content);
        }
    }
}