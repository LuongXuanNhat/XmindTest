namespace Xmind_Test
{
    internal class XmindService
    {
        private RootNode _root;
        private int _defaultTopicNumber = 4;
        private int _defaultWidth = 145;
        private int _defaultHeightTopic = 40;
        private int _defaultHeightSubTopic = 30;
        private int _defaultSpaceTopic = 100;
        private int _defaultSpaceSubTopic = 60;

        private string _defaultTitleTopic = "Main topic";
        private string _defaultTitleRelationship = "Relationship";
        private Position _positionRoot = new Position(620, 385);



        public XmindService(RootNode? root = null)
        {
            _root = root ?? CreateNewMap();
 
        }

        internal RootNode CreateNewMap()
        {
            var title = GetDefaultTitleTopic();
            var numberDefaultTopic = GetNumberDefaultTopic();
            var positionRoot = GetDefaultPositionRoot();
            var height = GetDefaultHeightTopic();

            _root = new RootNode("Central Topic");
            _root.SetPosition(positionRoot);
            _root.CreateDefaultTopic(numberDefaultTopic, title, height);
            SetWidthHeight(_root);
            return _root;
        }

        private void SetWidthHeight(BaseNode baseNode)
        {
            baseNode.SetWidth(_defaultWidth);
            baseNode.SetHeight(_defaultHeightTopic);
        }

        private Position GetDefaultPositionRoot()
        {
            return _positionRoot;
        }

        private int GetNumberDefaultTopic()
        {
            return _defaultTopicNumber;
        }

        internal string GetDefaultTitleTopic()
        {
            return _defaultTitleTopic;
        }

        internal RootNode GetRootNode()
        {
            return _root;
        }

        internal void CreateMultipleChildren(List<Guid> idSet)
        {
            var titleTopic = GetDefaultTitleTopic();
            var topic = idSet.FirstOrDefault(x => x.Equals(_root.GetId()));
            if (topic != Guid.Empty)
            {
                _root.CreateTopic(titleTopic);
            }
            _root.CreateMultipleChildren(idSet, titleTopic);
        }

        internal string GetDefaultTitleRelationship()
        {
            return _defaultTitleRelationship;
        }

        internal void DeleteAll()
        {
            _root.DeleteAll();
        }

        internal int GetDefaultWidth()
        {
            // 145px
            return _defaultWidth;
        }

        internal int GetDefaultHeightTopic()
        {
            // 42px 
            return _defaultHeightTopic;
        }

        internal int GetDefaultHeightSubTopic()
        {
            // 30
            return _defaultHeightSubTopic;
        }

        internal int GetDefaultSpaceTopic()
        {
            // 100px
            return _defaultSpaceTopic;
        }

        internal int GetDefaultSpaceSubTopic()
        {
            // 60
            return _defaultSpaceSubTopic;
        }

        internal void SortNodes()
        {
            var childrenHeight = GetChildrenHeight();
            var topicsHeight = 0;
            var spaceChild = 0;

            foreach (var topic in _root.GetChildren())
            {
                topicsHeight += topic.GetTopicHeight(_defaultHeightTopic, _defaultHeightSubTopic);
                if (topicsHeight < childrenHeight / 2 || topic == _root.GetChildren().First())
                {
                    var topicHeight = ArrangeTopicNodes(_root, topic, childrenHeight);
                    spaceChild += topicHeight;
                }   
                else
                {
                    var topicHeight = ArrangeTopicNodes(_root, topic, childrenHeight);
                    spaceChild += topicHeight;
                }
                    
            }

        }

        private int ArrangeTopicNodes(BaseNode parentNode, BaseNode topic,int parentHeight, int? spaceNode = 0)
        {
            var childrenHeight = topic.GetTopicHeight(_defaultSpaceTopic, _defaultSpaceSubTopic);
            var parentPosition = parentNode.GetPosition();
            var spaceChild = 0;

            // Get Middle Position -> Get min,max position
            var positionMaxY = parentPosition.GetY() - _defaultHeightTopic / 2 + parentHeight / 2 - spaceNode.Value;
            var positionMinY = positionMaxY - childrenHeight;
            var topicMiddlePosition = SetMiddleTopicPosition(parentNode, positionMaxY, positionMinY);
            topic.SetPosition(topicMiddlePosition.GetX() + _defaultSpaceTopic, topicMiddlePosition.GetY() + topic.GetHeight()/2);
            

            if (topic.GetChildren().Any())
            {
                foreach (var child in topic.GetChildren())
                {
                    ArrangeChildrenNode(topic, child, childrenHeight, spaceChild);
                    spaceChild += child.GetChidrenHeight(_defaultSpaceSubTopic);
                }
            }

            return childrenHeight;
        }

        private void ArrangeChildrenNode(BaseNode parentNode, BaseNode topic, int parentHeight, int? spaceNode = 0)
        {
            var childrenHeight = topic.GetChidrenHeight(_defaultSpaceSubTopic);
            var parentPosition = parentNode.GetPosition();
            var spaceChild = 0;

            // Get Middle Position -> Get min,max position
            var positionMaxY = parentPosition.GetY() - _defaultHeightTopic / 2 + parentHeight / 2 - spaceNode.Value;
            var positionMinY = positionMaxY - childrenHeight;
            var topicMiddlePosition = SetMiddleTopicPosition(parentNode, positionMaxY, positionMinY);

            topic.SetPosition(topicMiddlePosition.GetX() + _defaultSpaceSubTopic, topicMiddlePosition.GetY() + topic.GetHeight() / 2);

            if (topic.GetChildren().Any())
            {
                foreach (var child in topic.GetChildren())
                {
                    ArrangeChildrenNode(topic, child, childrenHeight, spaceChild);
                    spaceChild += child.GetChidrenHeight(_defaultSpaceSubTopic);
                }
            }
        }

        private Position SetMiddleTopicPosition(BaseNode parentNode, int positionMaxY, int positionMinY)
        {
            var x = parentNode.GetPosition().GetX() + _defaultWidth;
            var y = (positionMaxY + positionMinY) / 2;
            return new Position(x,y);
        }

        private int GetChildrenHeight()
        {
            var childrenHeight = 0;
            foreach (var topic in _root.GetChildren())
            {
                childrenHeight += topic.GetTopicHeight(_defaultSpaceTopic, _defaultSpaceSubTopic);
            }
            return childrenHeight;
        }
    }
}