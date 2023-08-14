namespace Xmind_Test
{
    internal class XmindService
    {
        private RootNode _root;
        private int _defaultTopicNumber = 4;
        private int _defaultWidth = 145;
        private int _defaultHeight = 42;
        private int _defaultSpace = 100;
        private string _defaultTitleTopic = "Main topic";
        private string _defaultTitleRelationship = "Relationship";
        private Position _positionRoot = new Position(620, 385) ;

        private List<Position> _leftPositions;
        private List<Position> _rightPositions;
        private List<List<Position>> _leftRightPositionOfRoot;


        public XmindService(RootNode? root = null)
        {
            _root = root ?? CreateNewMap();
            _leftRightPositionOfRoot = new List<List<Position>>();
            _leftPositions = new List<Position>();
            _rightPositions = new List<Position>();
            _leftRightPositionOfRoot.Add(_leftPositions);
            _leftRightPositionOfRoot.Add(_rightPositions);
        }

        internal RootNode CreateNewMap()
        {
            var title = GetDefaultTitleTopic();
            var numberDefaultTopic = GetNumberDefaultTopic();
            var positionRoot = GetDefaultPositionRoot();

            _root = new RootNode("Central Topic");
            _root.SetPosition(positionRoot);
            _root.CreateDefaultTopic(numberDefaultTopic ,title);
            SetWidthHeight(_root);
            PositionArrangementOfNodes();
            return _root;
        }

        private void SetWidthHeight(BaseNode baseNode)
        {
            baseNode.SetWidth(_defaultWidth);
            baseNode.SetHeight(_defaultHeight);
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

        internal int GetDefaultHeight()
        {
            // 42px 
            return _defaultHeight;
        }

        internal int GetDefaultSpace()
        {
            // 50px
            return _defaultSpace;
        }

        internal void PositionArrangementOfNodes()
        {
            int topicNumber = (_root.GetChildren().Count + 1) / 2;
            SetPositionForRightTopics(_root, _positionRoot, topicNumber);
            if (_root.GetChildren().Count < 2) return;
            SetPositionForLeftTopics(_root, _positionRoot, topicNumber);
        }
        internal void PositionArrangementOfTopics()
        {
            foreach (var topic in _root.GetChildren())
            {
                SetLocation(topic);
            }
        }

        private void SetLocation(BaseNode topic)
        {
            throw new NotImplementedException();
        }

        internal void SetPositionForRightTopics(BaseNode baseNode ,Position positionParent ,int topicNumber )
        {
            var children = baseNode.GetChildren().Take(topicNumber);
            int multiplier = topicNumber / 2;
            var middleRightPositionOfRoot = GetMiddleRightPositionOfParent(positionParent);
            var lastPosition = new Position();

            foreach (var topic in children)
            {
                if (multiplier == 0 && topicNumber % 2 == 0)
                {
                    multiplier--;
                }
                SetWidthHeight(topic);
                var middlePosition = SetPositionRightTopic(middleRightPositionOfRoot, multiplier, lastPosition.GetY());
                var positionTopic = SetPositionTopicFromMiddlePosition(middlePosition);
                topic.SetPosition(positionTopic);
                multiplier--;
                if (topic.GetChildren().Count != 0)
                {
                    lastPosition = SetPositionForRightSubTopics(topic, positionTopic);
                }
            }
        }

        private Position SetPositionForRightSubTopics(BaseNode topic, Position positionTopic)
        {
            var children = topic.GetChildren();
            var childrenNumber = children.Count;
            int multiplier = childrenNumber / 2;
            var middleRightPositionOfParent = GetMiddleRightPositionOfParent(positionTopic);
            var positionSubtopic = new Position();
            var lastPosition = new Position();

            foreach (var subtopic in children)
            {
                if (multiplier == 0 && childrenNumber % 2 == 0)
                {
                    multiplier--;
                }
                SetWidthHeight(subtopic);
                var middlePosition = SetPositionRightTopic(middleRightPositionOfParent, multiplier);
                positionSubtopic = SetPositionTopicFromMiddlePosition(middlePosition);
                subtopic.SetPosition(positionSubtopic);
                multiplier--;
                if (subtopic.GetChildren().Count != 0) { 
                    lastPosition = SetPositionForRightSubTopics(subtopic, positionSubtopic);
                } 
            }
            return positionSubtopic;
        }

        private void SetPositionForLeftTopics(BaseNode baseNode, Position positionParent, int topicNumber)
        {
            int subNumber = (baseNode.GetChildren().Count + 1) / 2;
            var middleLeftPositionOfRoot = GetMiddleLeftPositionOfParent(positionParent);
            var children = baseNode.GetChildren().Skip(subNumber).Take(topicNumber);
            int multiplier = topicNumber / 2;

            multiplier = -multiplier;

            foreach (var topic in children)
            {
                if (multiplier == 0 && topicNumber % 2 == 0)
                {
                    multiplier++;
                }
                SetWidthHeight(topic);
                var middlePosition = SetPositionLeftTopic(middleLeftPositionOfRoot, multiplier);
                var positionSubtopic = SetPositionTopicFromMiddlePosition(middlePosition);
                topic.SetPosition(positionSubtopic);
                multiplier++;
                if (topic.GetChildren().Count != 0) SetPositionForLeftSubTopics(topic, positionSubtopic);

            }
        }
        private void SetPositionForLeftSubTopics(BaseNode topic, Position positionTopic)
        {
            var children = topic.GetChildren();
            var childrenNumber = children.Count;
            int multiplier = childrenNumber / 2;
            var middleLeftPositionOfParent = GetMiddleLeftPositionOfParent(positionTopic);
            multiplier = -multiplier;

            foreach (var subtopic in children)
            {
                if (multiplier == 0 && childrenNumber % 2 == 0)
                {
                    multiplier++;
                }
                SetWidthHeight(subtopic);
                var middlePosition = SetPositionLeftTopic(middleLeftPositionOfParent, multiplier);
                var positionSubtopic = SetPositionTopicFromMiddlePosition(middlePosition);
                subtopic.SetPosition(positionTopic);
                multiplier++;
                if (subtopic.GetChildren().Count != 0) SetPositionForLeftSubTopics(subtopic, positionTopic);
            }
        }


        internal Position SetPositionRightTopic(Position topRightPosition, int multiplier, int? lastPosition = 0)
        {
            var x = topRightPosition.GetX() + _defaultSpace;
            var y = 0;
            if (lastPosition != 0 && topRightPosition.GetY() > lastPosition.Value)
            {
                y = lastPosition.Value - _defaultSpace - _defaultHeight/2;
            } else
            {
                y = topRightPosition.GetY() + _defaultSpace * multiplier;
            }
            return new Position(x, y);
        }
        internal Position SetPositionLeftTopic(Position topRightPosition, int multiplier)
        {
            var x = topRightPosition.GetX() - _defaultSpace;
            var y = topRightPosition.GetY() + _defaultSpace * multiplier;
            return new Position(x, y);
        }

        internal Position SetPositionTopicFromMiddlePosition(Position middlePosition)
        {
            var x = middlePosition.GetX();
            var y = middlePosition.GetY() + _defaultHeight /2 ;

            return new Position(x, y);
        }
        
        internal Position GetMiddleRightPositionOfParent(Position positionRoot)
        {
            var x = positionRoot.GetX() + _defaultWidth;
            var y = positionRoot.GetY() - _defaultHeight/2 ;
            return new Position(x, y);
        }

        internal Position GetMiddleLeftPositionOfParent(Position positionRoot)
        {
            var x = positionRoot.GetX();
            var y = positionRoot.GetY() - _defaultHeight/2 ;
            return new Position(x, y);
        }

        internal BaseNode CreateTopic(BaseNode parent)
        {
            throw new NotImplementedException();
        }
    }
}