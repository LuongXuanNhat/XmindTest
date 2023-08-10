﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Xmind_Test
{
    public class BaseNode
    {
        private Guid _id;
        private string _title;
        private List<BaseNode> _children;
        private List<Relationship> _relationship;
        private Note _note;
        private int _width;
        private int _height;
        private Position _position;

        public BaseNode()
        {
            _children = new List<BaseNode>();
            _relationship = new List<Relationship>();
            _note = new Note();
            _position = new Position();
        }
        public BaseNode(string title ) {
            _id = Guid.NewGuid();
            _title = title;
            _children = new List<BaseNode>();
            _relationship = new List<Relationship>();
            _note = new Note();
            _position = new Position();
        }

        internal void AddTopic(BaseNode children)
        {
            _children.Add(children);
        }

        internal List<BaseNode> GetChildren()
        {
            return _children;
        }

        internal BaseNode CreateTopic(string title)
        {
            var topic = new BaseNode(title);
            AddTopic(topic);
            return topic;
        }

        internal Guid GetId()
        {
            return _id;
        }

        internal void CreateTopics(List<Guid> idSet, string titleTopic)
        {
            if (_children == null) return;
            foreach (var child in _children)
            {
                if (idSet.Any(x => x == child.GetId()))
                {
                    child.CreateTopic(titleTopic);
                    idSet.Remove(child.GetId());
                    if (GetChildren().Count > 1)
                        child.CreateTopics(idSet, titleTopic);
                } else
                {
                    if (GetChildren().Count > 0)
                        child.CreateTopics(idSet, titleTopic);
                }
            }
        }

        internal Relationship CreateRelationship(Guid idTargetTopic, string title)
        {
            var relationship = new Relationship(this._id, idTargetTopic, title);
            AddRelationship(relationship);
            return relationship;
        }

        private void AddRelationship(Relationship relationship)
        {
            _relationship.Add(relationship);
        }

        internal List<Relationship> GetRelationship()
        {
            return _relationship;
        }

        internal Note CreateNote(string content)
        {
            _note = new Note(content);
            return _note;
        }

        internal Note GetNote()
        {
            return _note;
        }

        internal void RemoveTopic(BaseNode srcTopic)
        {
            _children = _children.Where(e => !e.Equals(srcTopic)).ToList();
        }

        internal void MoveChildrenTopic(BaseNode srcTopic, BaseNode targetTopic)
        {
            targetTopic.AddTopic(srcTopic);
            RemoveTopic(srcTopic);
        }

        internal void DeleteAllChildren()
        {
            _children.Clear();
        }

        internal void RemoveChildrenById(Guid idGuid)
        {
            _children = _children.Where(e => !e._id.Equals(idGuid)).ToList();
        }

        internal void RemoveChildrenTopics(List<Guid> idSet)
        {
            foreach (var topic in idSet)
            {
                this.RemoveChildrenById(topic);
            }
        }

        internal void MoveTopics(List<BaseNode> parentSet, List<Guid> idSet, RootNode root)
        {
            root.RemoveDetachedTopics(idSet);
            root.RemoveChildrenTopics(idSet);
            foreach (var topic in parentSet)
            {
                this.AddTopic(topic);
            }
        }

        internal void SetWidth(int width)
        {
            _width = width;
        }

        internal int GetWidth()
        {
            return _width;
        }

        internal void SetHeight(int height)
        {
            _height = height;
        }

        internal int GetHeight()
        {
            return _height;
        }

        internal Position GetPosition()
        {
            return _position;
        }
        internal void SetPosition(int x, int y)
        {
            _position = new Position(x, y);
        }

        internal void SetPosition(Position position)
        {
            _position = position;
        }
    }
}
