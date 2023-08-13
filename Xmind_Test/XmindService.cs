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
            SetPositionForRightTopics();
            if (_root.GetChildren().Count < 2) return;
            SetPositionForLeftTopics();
        }

        private void SetPositionForRightTopics()
        {
            int numberTopic = (_root.GetChildren().Count + 1) / 2;
            var middleRightPositionOfRoot = GetMiddleRightPositionOfRoot(_positionRoot);
            var children = _root.GetChildren().Take(numberTopic);
            var positionTopic = new Position();
            var middlePosition = new Position();
            int multiplier = numberTopic/2;

            foreach (var topic in children)
            {
                if (multiplier == 0 && numberTopic % 2 == 0)
                {
                    multiplier--;
                }
                SetWidthHeight(topic);
                middlePosition = SetPositionRightTopic(middleRightPositionOfRoot, multiplier);
                positionTopic = SetPositionTopicFromMiddlePosition(middlePosition);
                topic.SetPosition(positionTopic);
                multiplier--;
            }
        }
        private void SetPositionForLeftTopics()
        {
            int subNumber = (_root.GetChildren().Count + 1) / 2;
            int numberTopic = _root.GetChildren().Count - subNumber;
            var middleLeftPositionOfRoot = GetMiddleLeftPositionOfRoot(_positionRoot);
            var children = _root.GetChildren().Skip(subNumber).Take(numberTopic);
            var positionTopic = new Position();
            var middlePosition = new Position();
            int multiplier = numberTopic / 2;

            multiplier = -multiplier;

            foreach (var topic in children)
            {
                if (multiplier == 0 && numberTopic % 2 == 0)
                {
                    multiplier++;
                }
                SetWidthHeight(topic);
                middlePosition = SetPositionLeftTopic(middleLeftPositionOfRoot, multiplier);
                positionTopic = SetPositionTopicFromMiddlePosition(middlePosition);
                topic.SetPosition(positionTopic);
                multiplier++;
            }
        }

        internal Position SetPositionRightTopic(Position topRightPosition, int multiplier)
        {
            var x = topRightPosition.GetX() + _defaultSpace;
            var y = topRightPosition.GetY() + _defaultSpace * multiplier;
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
        
        internal Position GetMiddleRightPositionOfRoot(Position positionRoot)
        {
            var x = positionRoot.GetX() + _defaultWidth;
            var y = positionRoot.GetY() - _defaultHeight/2 ;
            return new Position(x, y);
        }

        internal Position GetMiddleLeftPositionOfRoot(Position positionRoot)
        {
            var x = positionRoot.GetX();
            var y = positionRoot.GetY() - _defaultHeight/2 ;
            return new Position(x, y);
        }
    }
}