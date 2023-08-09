using static XmindTest_Project.RootNode;

namespace XmindTest_Project
{
    public class BaseTopic
    {
        protected Guid _id;
        private string? _title;
        private double? _width;
        private List<Relationship> _relationship;
        private Notes _notes;
        private string _href;
        private Position _position;
        private double _height;

        private List<BaseTopic> _children { get; set; }
        //   private List<BaseTopic> _detachedChildren { get; set; }

        public BaseTopic(string title, int? width)
        {
            _id = Guid.NewGuid();
            _title = title;
            _width = width;
            _children = new List<BaseTopic>();
            //       _detachedChildren ??= new List<BaseTopic>();
            _relationship = new List<Relationship>();
            _position = new Position();
        }

        public void AddTopic(string title, int? width = null)
        {
            _children.Add(new BaseTopic(title, width));
        }

        public void AddTopic(BaseTopic topic)
        {
            _children.Add(topic);
        }
        //internal void AddDetachTopic(BaseTopic srcTopic)
        //{
        //    _detachedChildren.Add(srcTopic);
        //}
        public BaseTopic CreateTopic(string title, int? width = null)
        {
            var topic = new BaseTopic(title, width);
            _children.Add(topic);
            return topic;
        }

        public List<BaseTopic> GetChildren()
        {
            return _children;
        }

        internal Guid GetId()
        {
            return _id;
        }

        internal string? GetTitle()
        {
            return _title;
        }

        internal double? GetWidth()
        {
            return _width;
        }


        //internal void CreateDetachedTopic(string title, int width)
        //{
        //    _detachedChildren.Add(CreateTopic(title, width));
        //}
        //internal BaseTopic CreateDetachedTopic(string title)
        //{
        //    var topic = CreateTopic(title);
        //    _detachedChildren.Add(topic);
        //    return topic;
        //}

        //internal List<BaseTopic> GetDetachedChildren()
        //{
        //    return _detachedChildren;
        //}

        internal void DeleteChildren(BaseTopic topic)
        {
            _children = _children.Where(e => !e.Equals(topic)).ToList();
        }

        internal void DeleteChildren(List<Guid> idSet)
        {
            if (_children == null) return;

            _children = _children.Where(e => !idSet.Contains(e.GetId())).ToList();
            
            foreach (BaseTopic topic in _children) 
            { 
                topic.DeleteChildren(idSet); 
            }
        }

        internal void DeleteTopic(BaseTopic topic, List<string> topicId)
        {
            _children = _children.Where(e => !e.Equals(topic)).ToList();
        }

        internal void DeleteChildrenFromId(Guid id)
        {
            _children = _children.Where(e => !e._id.Equals(id)).ToList();
        }
        //internal void DeleteDetachedChildren(BaseTopic srcTopic)
        //{
        //    _detachedChildren = _detachedChildren.Where(e => !e.Equals(srcTopic)).ToList();
        //}

        //internal void DeleteDetachedChildrenFromId(Guid id)
        //{
        //    _detachedChildren = _detachedChildren.Where(e => !e._id.Equals(id)).ToList();
        //}
        internal Relationship AddRelationship(Guid idTarget , string title)
        {
            var relationship = new Relationship(this._id, idTarget, title);
            var relationships = GetRelationship();
            relationships.Add(relationship);
            return relationship;
        }

        internal List<Relationship> GetRelationship()
        {
            return _relationship;
        }
        internal void AddNotes(string content)
        {
            _notes = new Notes(content);
        }

        internal Notes GetNotes()
        {
            return _notes;
        }

        internal void AddLink(string content)
        {
            _href = content;
        }

        internal string GetHref()
        {
            return _href;
        }

        internal void MoveAttachedToChildrenTopic(BaseTopic srcTopic, BaseTopic targetTopic)
        {
            targetTopic.AddTopic(srcTopic);
            this.RemoveTopic(srcTopic);
        }

        internal void MoveMultipleAttachedToChildrenTopic(List<BaseTopic> children, BaseTopic targetTopic)
        {
            foreach (var topic in children)
            {
                MoveAttachedToChildrenTopic(topic, targetTopic);
            }
        }

        //internal void MoveDetachedTopicToChildrenTopic(BaseTopic detachedTopic, BaseTopic targetTopic)
        //{
        //    targetTopic.AddTopic(detachedTopic);
        //    this.RemoveDetachTopic(detachedTopic);
        //}

        //internal void MoveMultipleDetachedTopicToChildrenTopic(List<BaseTopic> detachedTopic, BaseTopic targetTopic)
        //{
        //    foreach (var topic in detachedTopic)
        //    {
        //        MoveDetachedTopicToChildrenTopic(topic, targetTopic);
        //    }
        //}

        //internal void MoveDetachedToAttachTopic(BaseTopic srcTopic, RootNode targetTopic)
        //{
        //    targetTopic.AddTopic(srcTopic);
        //    RemoveDetachTopic(srcTopic);
        //}
        //internal void MoveMultipleDetachedToAttachTopic(List<BaseTopic> topics, RootNode root)
        //{
        //    foreach (BaseTopic topic in topics)
        //    {
        //        this.MoveDetachedToAttachTopic(topic, root);
        //    }
        //}
        internal void MoveChildrenTopicToDetachTopic(BaseTopic srcTopic, RootNode targetTopic)
        {
            targetTopic.AddDetachTopic(srcTopic);
            RemoveTopic(srcTopic);
        }


        internal void MoveMultipleChildrenTopicToDetachTopic(List<BaseTopic> topics, RootNode root)
        {
            foreach (var topic in topics)
            {
                this.MoveChildrenTopicToDetachTopic(topic, root);
            }
        }

        //private void RemoveDetachTopic(BaseTopic srcTopic)
        //{
        //    _detachedChildren = _detachedChildren.Where(e => !e.Equals(srcTopic)).ToList();
        //}

        private void RemoveTopic(BaseTopic srcTopic)
        {
            _children = _children.Where(e => !e.Equals(srcTopic)).ToList();
        }

        internal void ConvertToTopic(BaseTopic topicFather, List<BaseTopic> topicAddChild, int widthAttachedTopic)
        {
            topicFather.RemoveTopic(this);
            topicAddChild.Add(this);
        }

        internal void DeleteAll()
        {
            _children.Clear();
            //  _detachedChildren.Clear();
        }
        internal void DeleteChildrenTopics(List<Guid> idSet)
        {
            foreach (var topic in idSet)
            {
                this.DeleteChildrenFromId(topic);
            }
        }
        internal void DeleteTopics(List<Guid> idSet)
        {
            foreach (var topic in idSet)
            {
                this.DeleteChildrenFromId(topic);
                //this.DeleteDetachedChildrenFromId(topic);
            }
        }

        internal void MoveTopics(List<BaseTopic> objectSet, List<Guid> idSet, RootNode root)
        {
            root.DeleteDetachedChildren(idSet);
            root.DeleteChildren(idSet);
            foreach (var topic in objectSet)
            {
                this.AddTopic(topic);
            }
        }

        internal void SetWidth(double width)
        {
            _width = width;
        }

        internal void SetHeight(double height)
        {
            _height = height;
        }

        internal double GetHeight()
        {
            return _height;
        }

        internal void SetPosition(Position position)
        {
            _position = position;
        }
        internal void SetPosition(int x, int y)
        {
            _position = new Position(x, y);
        }

        internal Position GetPosition()
        {
            return _position;
        }
        //internal void DeleteDetachedTopics(List<Guid> idSet)
        //{
        //    foreach (var topic in idSet)
        //    {
        //        this.DeleteDetachedChildrenFromId(topic);
        //    }
        //}
    }
}