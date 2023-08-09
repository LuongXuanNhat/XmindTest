﻿namespace XmindTest_Project
{
    public class Notes
    {
        private Guid _id;
        private string _content;

        public Notes(string content)
        {
            _id = Guid.NewGuid();
            _content = content;
        }


        internal string GetContent()
        {
            return _content;
        }
    }
}