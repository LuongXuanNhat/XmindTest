namespace Xmind_Test
{
    internal class XmindService
    {
        RootNode? _root;

        public XmindService(RootNode? root = null)
        {
            _root = root ?? CreateNewMap();
        }

        internal RootNode CreateNewMap()
        {
            var title = GetDefaultTitleTopic();
            var numberDefaultTopic = GetNumberDefaultTopic();

            _root = new RootNode("Central Topic");
            _root.CreateDefaultTopic(numberDefaultTopic ,title);

            return _root;
        }

        private int GetNumberDefaultTopic()
        {
            return 4;
        }

        internal string GetDefaultTitleTopic()
        {
            return "Main topic ";
        }

        internal RootNode GetRootNode()
        {
            return _root;
        }

        internal void CreateMultipleChildren(List<Guid> idSet)
        {
            var titleTopic = GetDefaultTitleTopic();
            var topic = idSet.Where(x => x.Equals(_root.GetId())).FirstOrDefault();
            if (topic != Guid.Empty)
            {
                _root.CreateTopic(titleTopic);
            }
            _root.CreateMultipleChildren(idSet, titleTopic);
        }

        internal string GetDefaultTitleRelationship()
        {
            return "Relationship";
        }

        internal void DeleteAll()
        {
            _root.DeleteAll();
        }

        internal int GetDefaultWidth()
        {
            // 145px
            return 145;
        }

        internal int GetDefaultHeight()
        {
            // 42px 
            return 42;
        }

        internal void SetDefaultPositionTopic(RootNode root)
        {
            var width = GetDefaultWidth();  //      145
            var height = GetDefaultHeight();  //    42
            var spaceX = GetDefaultSpace();  //     50
            var spaceY = GetDefaultSpace();  //     50
            var position = new Position(0, 0);
            var topics = root.GetChildren();

            root.SetWidth(width); root.SetHeight(height);
            root.SetPosition(620, 385);
            for (int i = 0; i < topics.Count; i++)
            {
                int x = root.GetPosition().GetX() + width + spaceX;
                int y = root.GetPosition().GetY() + height + spaceY;
                position = new Position(x, y);
                topics[i].SetPosition(position);
                topics[i].SetWidth(GetDefaultWidth());
                topics[i].SetHeight(GetDefaultHeight());

                if (width > 0 && height > 0)
                {
                    height = -height;
                    spaceY = -spaceY;
                }
                else
                if (width > 0 && height < 0)
                {
                    width = -width;
                    spaceX = -spaceX;
                }
                else
                if (width < 0 && height < 0)
                {
                    height = -height;
                    spaceY = -spaceY;
                }
                else
                if (width < 0 && height > 0)
                {
                    width = -width;
                    spaceX = -spaceX;
                }
            }
        }

        internal int GetDefaultSpace()
        {
            // 50px
            return 50;
        }

        internal Position SetPositionTopic(BaseNode topicParent, BaseNode topicChild)
        {
            var position = GetPositionTopic(topicParent);
            topicChild.SetPosition(position);
            return position;
        }

        private Position GetPositionTopic(BaseNode topicParent)
        {
            int x, y;
            if (topicParent.GetPosition().GetX() < _root.GetPosition().GetX())
            {
                x = topicParent.GetPosition().GetX() - GetDefaultSpace() - GetDefaultWidth();
                y = topicParent.GetPosition().GetY();
            }
            else
            {
                x = topicParent.GetPosition().GetX() + GetDefaultSpace() + GetDefaultWidth();
                y = topicParent.GetPosition().GetY();
            }
            return new Position(x, y);
        }
    }
}