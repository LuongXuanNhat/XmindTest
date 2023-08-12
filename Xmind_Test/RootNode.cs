namespace Xmind_Test
{
    internal class RootNode : BaseNode
    {
        private List<BaseNode> _detachedChildren;

        public RootNode(string title) : base(title)
        {
            _detachedChildren = new List<BaseNode>();
        }

        public RootNode()
        {
            _detachedChildren = new List<BaseNode>();
        }

        internal void CreateDefaultTopic(int numberDefaultTopic, string title)
        {
            for (int i = 0; i < numberDefaultTopic; i++)
            {
                string titleDefault = string.Format("{0} {1}", title, i+1);
                var topic = new BaseNode(titleDefault);
                AddTopic(topic);
            }
        }

        internal BaseNode CreateDetachedTopic(string title)
        {
            var detachedTopic = new BaseNode(title);
            AddDetachedTopic(detachedTopic);
            return detachedTopic;
        }

        private void AddDetachedTopic(BaseNode detachedTopic)
        {
            _detachedChildren.Add(detachedTopic);
        }

        internal List<BaseNode> GetDetachedChildren()
        {
            return _detachedChildren;
        }

        internal void CreateMultipleChildren(List<Guid> idSet, string titleTopic)
        {
            idSet = CreateTopics(idSet, titleTopic);
            base.CreateTopics(idSet, titleTopic);
        }

        internal new List<Guid> CreateTopics(List<Guid> idSet, string titleTopic)
        {
            if (_detachedChildren != null)
            {
                foreach (var topic in _detachedChildren)
                {
                    if (idSet.Any(x => x == topic.GetId()))
                    {
                        topic.CreateTopic(titleTopic);
                        idSet.Remove(topic.GetId());
                    }
                    if(GetChildren().Count > 1)
                        base.CreateTopics(idSet, titleTopic);
                }
            }
            return idSet;
        }
        internal void MoveChildrenTopicToDetachTopic(BaseNode srcTopic, RootNode targetTopic)
        {
            targetTopic.AddDetachedTopic(srcTopic);
            RemoveTopic(srcTopic);
        }

        internal void MoveChildrenTopic(BaseNode detachedTopic, RootNode targetTopic)
        {
            targetTopic.AddTopic(detachedTopic);
            RemoveDetachedTopic(detachedTopic);
        }

        internal void RemoveDetachedTopic(BaseNode detachedTopic)
        {
            _detachedChildren = _detachedChildren.Where(e => !e.Equals(detachedTopic)).ToList();
        }

        internal void DeleteAll()
        {
            DeleteAllChildren();
            _detachedChildren.Clear();
        }

        internal void RemoveDetachedChildrenFromId(Guid idGuid)
        {
            _detachedChildren = _detachedChildren.Where(e => !e.GetId().Equals(idGuid)).ToList();
        }

        internal void RemoveDetachedTopics(List<Guid> idSet)
        {
            foreach (var topic in idSet)
            {
                this.RemoveDetachedChildrenFromId(topic);
            }
        }

        internal void RemoveTopics(List<Guid> idSet)
        {
            RemoveChildrenTopics(idSet);
            RemoveDetachedTopics(idSet);
        }


    }
}