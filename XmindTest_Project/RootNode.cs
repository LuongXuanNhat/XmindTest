namespace XmindTest_Project
{

    public partial class RootNode : BaseTopic
    {
        private List<BaseTopic> _detachedChildren { get; set; }

        public RootNode(string title, int width) : base(title, width)
        {
            _detachedChildren = new List<BaseTopic>();
        }

        
        internal void CreateDefaultChildren(int numberOfChilden, string defaultTitle, int width)
        {          
            for (int i = 0; i < numberOfChilden; i++)
            {
                var title = defaultTitle + " " + i + 1;
                AddTopic(title, width);
            }
        }

        internal void AddDetachTopic(BaseTopic srcTopic)
        {
            _detachedChildren.Add(srcTopic);
        }

        internal void CreateDetachedTopic(string title, int width)
        {
            _detachedChildren.Add(CreateTopic(title, width));
        }
        internal BaseTopic CreateDetachedTopic(string title)
        {
            var topic = new BaseTopic(title, null);
            _detachedChildren.Add(topic);
            return topic;
        }

        internal List<BaseTopic> GetDetachedChildren()
        {
            return _detachedChildren;
        }

        internal void DeleteDetachedChildren(BaseTopic srcTopic)
        {
            _detachedChildren = _detachedChildren.Where(e => !e.Equals(srcTopic)).ToList();
        }
        //internal void DeleteDetachedChildren(List<Guid> idSet)
        //{
        //    _detachedChildren = _detachedChildren.Where(e => !idSet.Contains(e.GetId())).ToList();
        //}

        internal void DeleteDetachedChildrenFromId(Guid id)
        {
            _detachedChildren = _detachedChildren.Where(e => !e.GetId().Equals(id)).ToList();
       
        } 
        internal void DeleteDetachedChildren(List<Guid> idSet)
        {
            if (_detachedChildren == null) return;
            //Delete detached children
            _detachedChildren = _detachedChildren.Where(e => !idSet.Contains(e.GetId())).ToList();
            // delete children of detached topics
            foreach (BaseTopic topic in _detachedChildren)
            {
                topic.DeleteChildren(idSet);
            }
        }
        internal void DeleteTopics(List<Guid> idSet)
        {
            //foreach (var topicId in idSet)
            //{
            //    foreach (var topic in this._children)
            //    {
            //        topic.DeleteChildrenFromId(topicId);
            //    }
            //    this.DeleteDetachedChildrenFromId(topicId);
            //}
            // delete detached topics by id
            DeleteDetachedChildren(idSet);
            DeleteChildren(idSet);

        }

        private void RemoveDetachTopic(BaseTopic srcTopic)
        {
            _detachedChildren = _detachedChildren.Where(e => !e.Equals(srcTopic)).ToList();
        }

        internal void DeleteDetachedTopics(List<Guid> idSet)
        {
            foreach (var topic in idSet)
            {
                this.DeleteDetachedChildrenFromId(topic);
            }
        }

        internal void MoveDetachedTopicToChildrenTopic(BaseTopic detachedTopic, BaseTopic targetTopic)
        {
            targetTopic.AddTopic(detachedTopic);
            this.RemoveDetachTopic(detachedTopic);
        }

        internal void MoveMultipleDetachedTopicToChildrenTopic(List<BaseTopic> detachedTopic, BaseTopic targetTopic)
        {
            foreach (var topic in detachedTopic)
            {
                MoveDetachedTopicToChildrenTopic(topic, targetTopic);
            }
        }

        internal void MoveDetachedToAttachTopic(BaseTopic srcTopic, RootNode targetTopic)
        {
            targetTopic.AddTopic(srcTopic);
            RemoveDetachTopic(srcTopic);
        }

        internal void MoveMultipleDetachedToAttachTopic(List<BaseTopic> topics, RootNode root)
        {
            foreach (BaseTopic topic in topics)
            {
                this.MoveDetachedToAttachTopic(topic, root);
            }
        }

        internal void MoveTopics(List<BaseTopic> objectSet, List<Guid> idtSet)
        {
            foreach (var topic in objectSet)
            {
                
            }
        }
    }

}