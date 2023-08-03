namespace XmindTest
{
    public class Plain
    {
        public Plain()
        {
        }

        private string content;

        public string GetContent()
        {
            return content;
        }

        private void SetContent(string value)
        {
            content = value;
        }

        internal void Add_Notes(string content)
        {
            this.SetContent(content);
        }
    }
}