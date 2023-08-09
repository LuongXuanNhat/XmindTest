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

            public RootNode CreateDefault()
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
            public int GetDefaultWidthDetachedTopic()
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
            public string GetDefaultSubTopicTitle()
            {
                return "Subtopic ";
            }

            public int GetWidthSubTopic()
            {
                return 15;
            }

            public string GetNotes()
            {
                return "Notes";
            }

            public string GetLink()
            {
                return "example.com";
            }

            public int GetDefaultWidthSubtopic()
            {
                return 15;
            }

            public void CreateDetachedTopic(string title = "", int? width = null)
            {
                _root.CreateDetachedTopic(title ?? this.GetDefaultDetachedTitle(), width ?? this.GetDefaultWidthDetachedTopic());
            }

            public RootNode GetRootNode()
            {
                return this._root;
            }

            public void DeleteAll()
            {
                _root.DeleteAll();
            }

            public string GetDefaultTitleRelationship()
            {
                return "Relationship";
            }

            internal double GetDefaultHeight()
            {
                // 42px 
                return 42;
            }

            internal double GetDefaultWidth()
            {
                // 145px
                return 145;
            }
            internal double GetDefaultSpace()
            {
                // 50px
                return 50;
            }

            internal void SetDefaultPositionTopic(RootNode root)
            {
                var width = GetDefaultWidth();  //      145
                var height = GetDefaultHeight();  //    42
                var spaceX = GetDefaultSpace();  //     50
                var spaceY = GetDefaultSpace();  //     50
                var position = new Position(0,0);
                var topics = root.GetChildren();

                root.SetWidth(width); root.SetHeight(height);
                root.SetPosition(620,385);
                for (int i = 0; i < topics.Count; i++)
                {
                    double x = root.GetPosition().GetX() + width + spaceX;
                    double y = root.GetPosition().GetY() + height + spaceY;
                    position = new Position(x, y);
                    topics[i].SetPosition(position);
                    topics[i].SetWidth(GetDefaultWidth());
                    topics[i].SetHeight(GetDefaultHeight());

                    if (width > 0 && height > 0)
                    {
                        height = -height;
                        spaceY = -spaceY;
                    } else
                    if (width > 0 && height < 0)
                    {
                        width = -width;
                        spaceX = -spaceX;
                    } else
                    if (width < 0 && height < 0)
                    {
                        height = -height;
                        spaceY = -spaceY;
                    } else
                    if (width < 0 && height > 0)
                    {
                        width = -width;
                        spaceX = -spaceX;
                    }
                }
            }

            internal Position SetPositionTopic(BaseTopic topicParent, BaseTopic topicChild)
            {
                var position = GetPositionTopic(topicParent);
                topicChild.SetPosition(position);
                return position;
            }

            private Position GetPositionTopic(BaseTopic topicParent)
            {
                double x, y;
                if (topicParent.GetPosition().GetX() < _root.GetPosition().GetX()) 
                {
                    x = topicParent.GetPosition().GetX() - GetDefaultSpace() - GetDefaultWidth();
                    y = topicParent.GetPosition().GetY();
                } else
                {
                    x = topicParent.GetPosition().GetX() + GetDefaultSpace() + GetDefaultWidth();
                    y = topicParent.GetPosition().GetY();
                }
                return new Position(x, y);
            }
        }
    }
}