using static XmindTest_Project.XmindTest;

namespace XmindTest_Project
{
    public partial class XmindTest
    {
        public class XmindService
        {
            RootNode _root;

            public XmindService(RootNode? root = null)
            {
                _root = root ?? CreateDefault(); //call open file and convert file to RootNode here
            }

            internal RootNode CreateDefault()
            {
                string defaultTitle = GetDefaultAttachedTitle();
                int width = GetDefaultWidthAttachedTopic();

                _root = new RootNode(defaultTitle, width);
                _root.CreateDefaultChildren(GetDefaultNumbers(), defaultTitle, width);

                return _root;
            }

            public int GetDefaultWidthAttachedTopic()
            {
                return 25;
            }
            internal int GetDefaultWidthDetachedTopic()
            {
                return 20;
            }
            public int GetDefaultNumbers()
            {
                return 4;
            }

            public string GetDefaultDetachedTitle()
            {
                return "Floating Topic";
            }

            public string GetDefaultAttachedTitle()
            {
                return "Main Topic ";
            }
            internal string GetDefaultSubTopicTitle()
            {
                return "Subtopic ";
            }

            internal int GetWidthSubTopic()
            {
                return 15;
            }

            internal string GetNotes()
            {
                return "Notes";
            }

            internal string GetLink()
            {
                return "example.com";
            }

            internal int GetDefaultWidthSubtopic()
            {
                return 15;
            }

            internal void CreateDetachedTopic(string title = "", int? width = null)
            {
                _root.CreateDetachedTopic(title ?? this.GetDefaultDetachedTitle(), width ?? this.GetDefaultWidthDetachedTopic());
            }

            internal RootNode GetRootNode()
            {
                return this._root;
            }

            internal void DeleteAll()
            {
                _root.DeleteAll();
            }
        }
    }
}