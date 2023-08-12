namespace Xmind_Test
{
    internal class Note
    {
        private string _content;

        public Note()
        {
            _content = string.Empty;
        }

        public Note(string content)
        {
            this._content = content;
        }

        internal string GetContent()
        {
            return _content;
        }
    }
}