namespace Xmind_Test
{
    public class Xmind_Test
    {
        private RootNode CreateDefaultRoot()
        {
            var xmindService = new XmindService();
            var root = xmindService.GetRootNode();
            return root;
        }
        [Fact]
        public void Create_Default_Xmind_File()
        {
            var xmindService = new XmindService();
            var root = xmindService.CreateNewMap();

            Assert.NotNull(root);
            Assert.Equal(4, root.GetChildren().Count);
        }

        [Fact]
        public void Create_Topic()
        {
            var root = CreateDefaultRoot();

            root.CreateTopic("Main topic");

            Assert.Equal(5, root.GetChildren().Count);
        }

        [Fact]
        public void Create_SubTopic()
        {
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();
            var childOfFirstTopic = firstTopic.CreateTopic("Subtopic");

            Assert.NotNull(childOfFirstTopic);
            Assert.Single(firstTopic.GetChildren());
        }

        [Fact]
        public void Create_Detached_Topic()
        {
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");

            Assert.NotNull(detachedTopic);
            Assert.Single(root.GetDetachedChildren());
        }

        [Fact]
        public void Create_Multiple_Children_By_Id()
        {
            var xmindService = new XmindService();
            var root = xmindService.GetRootNode();
            var idSet = new List<Guid>();
            var firstTopic = root.GetChildren().First();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");
            var childOfFirstTopic = firstTopic.CreateTopic("Subtopic");

            idSet.Add(root.GetId());
            idSet.Add(firstTopic.GetId());
            idSet.Add(detachedTopic.GetId());
            idSet.Add(childOfFirstTopic.GetId());
            xmindService.CreateMultipleChildren(idSet);

            Assert.Equal(5, root.GetChildren().Count);
            Assert.Equal(2,firstTopic.GetChildren().Count);
            Assert.Single(detachedTopic.GetChildren());
            Assert.Single(childOfFirstTopic.GetChildren());
        }

        [Fact]
        public void Create_Relationship_From_Root_To_Attached_Topic()
        {
            var xmindService = new XmindService();
            var root = xmindService.GetRootNode();
            var firstTopic = root.GetChildren().First();
            var title = xmindService.GetDefaultTitleRelationship();
            var idTargetTopic = firstTopic.GetId();

            Assert.Empty(root.GetRelationship());

            var relationship = root.CreateRelationship(idTargetTopic, title);

            Assert.NotNull(relationship);
            Assert.Single(root.GetRelationship());
        }

        [Fact]
        public void Create_Relationship_From_Root_To_Subtopic_And_Detached_Topic()
        {
            var xmindService = new XmindService();
            var root = xmindService.GetRootNode();
            var detached = root.CreateDetachedTopic("Floating topic");
            var firstTopic = root.GetChildren().First();
            var childOfFirstTopic = firstTopic.CreateTopic("Subtopic");
            var title = xmindService.GetDefaultTitleRelationship();
            var idTargetTopic1 = childOfFirstTopic.GetId();
            var idTargetTopic2 = detached.GetId();

            Assert.Empty(root.GetRelationship());

            root.CreateRelationship(idTargetTopic1, title);
            root.CreateRelationship(idTargetTopic2, title);

            Assert.Equal(2,root.GetRelationship().Count);
        }


        [Fact]
        public void Create_Relationship_From_Attached_Topic_To_Root()
        {
            var xmindService = new XmindService();
            var root = xmindService.GetRootNode();
            var firstTopic = root.GetChildren().First();
            var title = xmindService.GetDefaultTitleRelationship();
            var idTargetTopic = root.GetId();

            Assert.Empty(firstTopic.GetRelationship());

            firstTopic.CreateRelationship(idTargetTopic, title);

            Assert.Single(firstTopic.GetRelationship());
        }

        [Fact]
        public void Create_Note_For_Topic()
        {
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();

            var note = firstTopic.CreateNote("hello");

            Assert.Equal("hello", note.GetContent());
        }

        [Fact]
        public void Move_Attached_Topic_To_Detached_Topic()
        {
            var parent = CreateDefaultRoot();
            var firstTopic = parent.GetChildren().First();

            parent.MoveChildrenTopicToDetachTopic(firstTopic, parent);

            Assert.Equal(3, parent.GetChildren().Count);
            Assert.Single(parent.GetDetachedChildren());
        }
        
        [Fact]
        public void Move_Detached_Topic_To_Attached_Topic()
        {
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");

            root.MoveChildrenTopic(detachedTopic, root);

            Assert.Empty(root.GetDetachedChildren());
            Assert.Equal(5, root.GetChildren().Count);
        }

        [Fact]
        public void Move_Topic_To_Attached_SubTopic()
        {
            var parent = CreateDefaultRoot();
            var firstTopic = parent.GetChildren().First();
            var lastTopic = parent.GetChildren().Last();
            var childOfFirstTopic = firstTopic.CreateTopic("Subtopic 1");

            parent.MoveChildrenTopic(lastTopic, childOfFirstTopic);

            Assert.Equal(3, parent.GetChildren().Count());
            Assert.Single(childOfFirstTopic.GetChildren());
        }

        // do delete first 
        // Target children of attached topic
        [Fact]
        public void Move_Multiple_Grandchildren()
        {
            var root = CreateDefaultRoot();

            var parentSet = new List<BaseNode>();
            var idSet = new List<Guid>();

            // move topic 11
            var sub1 = root.CreateDetachedTopic("Topic 1");
            var sub11 = sub1.CreateTopic("11");
            parentSet.Add(sub11);
            idSet.Add(sub11.GetId());

            // move detached topic 2
            var sub2 = root.CreateDetachedTopic("Topic 2");
            parentSet.Add(sub2);
            idSet.Add(sub2.GetId());

            // move topic 3
            var sub3 = root.CreateTopic("Topic 3");
            parentSet.Add(sub3);
            idSet.Add(sub3.GetId());

            // move topic 41
            var sub4 = root.CreateTopic("Topic 4");
            var sub41 = sub4.CreateTopic("41");
            parentSet.Add(sub41);
            idSet.Add(sub41.GetId());

            //target attached topic 5
            var sub5 = root.CreateTopic("Topic 5");

            Assert.Equal(7, root.GetChildren().Count);
            Assert.Single( sub1.GetChildren());
            Assert.Single( sub4.GetChildren());

            sub5.MoveTopics(parentSet, idSet, root);

            //Assert.Empty(sub1.GetChildren());
            Assert.Equal(6, root.GetChildren().Count);
            Assert.Empty(sub11.GetChildren());
            Assert.Empty(sub11.GetChildren());
            Assert.Equal(4, sub5.GetChildren().Count);
        }

        // Target grandchildren of detached topic
        [Fact]
        public void Move_Multiple_Grandchildren_2()
        {
            var root = CreateDefaultRoot();

            var objectSet = new List<BaseNode>();
            var idtSet = new List<Guid>();

            // move topic 11
            var sub1 = root.CreateDetachedTopic("Topic 1");
            var sub11 = sub1.CreateTopic("11");
            objectSet.Add(sub11);
            idtSet.Add(sub11.GetId());

            // move detached topic 2
            var sub2 = root.CreateDetachedTopic("Topic 2");
            objectSet.Add(sub2);
            idtSet.Add(sub2.GetId());

            // move topic 3
            var sub3 = root.CreateTopic("Topic 3");
            objectSet.Add(sub3);
            idtSet.Add(sub3.GetId());

            // move topic 41
            var sub4 = root.CreateTopic("Topic 4");
            var sub41 = sub4.CreateTopic("41");
            objectSet.Add(sub41);
            idtSet.Add(sub41.GetId());

            //target detached topic 5
            var sub5 = root.CreateDetachedTopic("Topic 5");
            var childOfSub5 = sub5.CreateTopic("Subtopic 5.1");

            Assert.Equal(6, root.GetChildren().Count);
            Assert.Single(sub1.GetChildren());
            Assert.Single(sub4.GetChildren());

            childOfSub5.MoveTopics(objectSet, idtSet, root);

            //Assert.Empty(sub1.GetChildren());
            Assert.Equal(5, root.GetChildren().Count);
            Assert.Empty(sub11.GetChildren());
            Assert.Empty(sub11.GetChildren());
            Assert.Equal(4, childOfSub5.GetChildren().Count);
        }

        [Fact]
        public void Delete_All()
        {
            var xmindService = new XmindService();
            var root = xmindService.GetRootNode();
            xmindService.DeleteAll();

            Assert.NotNull(root);
            Assert.Empty(root.GetChildren());
        }

        [Fact]
        public void Remove_Detached_Topic()
        {
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");

            root.RemoveDetachedTopic(detachedTopic);

            Assert.Empty(root.GetDetachedChildren());
        }

        [Fact]
        public void Remove_Attached_Topic()
        {
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();

            root.RemoveTopic(firstTopic);

            Assert.Equal(3, root.GetChildren().Count);
        }

        [Fact]
        public void Remove_Subtopic()
        {
            var root = CreateDefaultRoot();
            var attachedTopic = root.GetChildren().First();
            var subtopic = attachedTopic.CreateTopic("Subtopic");

            attachedTopic.RemoveTopic(subtopic);

            Assert.Empty(attachedTopic.GetChildren());
        }

        [Fact]
        public void Remove_Detached_Topic_By_Id()
        {
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");

            root.RemoveDetachedChildrenFromId(detachedTopic.GetId());
        }

        [Fact]
        public void Remove_Children_By_Id()
        {
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();
            var secondTopic = root.GetChildren().Last();
            var childTopic = firstTopic.CreateTopic("Subtopic");

            firstTopic.AddTopic(childTopic);
            root.RemoveChildrenById(secondTopic.GetId());
            firstTopic.RemoveChildrenById(childTopic.GetId());

            Assert.Empty(firstTopic.GetChildren());
            Assert.Equal(3, root.GetChildren().Count);
        }

        [Fact]
        public void Remove_Subtopic_By_Id()
        {
            var root = CreateDefaultRoot();
            var attachedTopic = root.GetChildren().First();
            var subtopic = attachedTopic.CreateTopic("Subtopic");

            attachedTopic.RemoveChildrenById(subtopic.GetId());

            Assert.Empty(attachedTopic.GetChildren());
        }

        [Fact]
        public void Remove_Multiple_Topics_By_Id()
        {
            var root = CreateDefaultRoot();
            var idSet = new List<Guid>();
            var sub1 = root.CreateTopic("1");
            idSet.Add(sub1.GetId());
            var sub2 = root.CreateTopic("2");
            idSet.Add(sub2.GetId());
            var sub3 = root.CreateTopic("3");
            idSet.Add(sub3.GetId());

            Assert.Equal(7, root.GetChildren().Count);

            root.RemoveChildrenTopics(idSet);

            Assert.Equal(4, root.GetChildren().Count);
        }

        [Fact]
        public void Remove_Multiple_Floating_Topics_By_Id()
        {
            var root = CreateDefaultRoot();

            var idSet = new List<Guid>();
            var sub1 = root.CreateDetachedTopic("1");
            idSet.Add(sub1.GetId());
            var sub2 = root.CreateDetachedTopic("2");
            idSet.Add(sub2.GetId());
            var sub3 = root.CreateDetachedTopic("3");
            idSet.Add(sub3.GetId());

            Assert.Equal(3, root.GetDetachedChildren().Count);

            root.RemoveDetachedTopics(idSet);

            Assert.Empty(root.GetDetachedChildren());
        }

        [Fact]
        public void Delete_Multiple_Grand_Children_By_Id()
        {
            var root = CreateDefaultRoot();

            var idSet = new List<Guid>();
            var sub1 = root.CreateDetachedTopic("1");

            var sub11 = sub1.CreateTopic("11");
            sub1.AddTopic(sub11);
            idSet.Add(sub11.GetId());
            root.RemoveTopics(idSet);

            Assert.Equal(4, root.GetChildren().Count);
            Assert.Empty(sub11.GetChildren());
        }

        [Fact]
        public void Set_Width_For_Topic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var firstChild = root.GetChildren().First();
            var width = xmindService.GetDefaultWidth();

            firstChild.SetWidth(width);

            Assert.Equal(145, firstChild.GetWidth());
        }

        [Fact]
        public void Set_Default_Height_Topic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var firstChild = root.GetChildren().First();
            var height = xmindService.GetDefaultHeight();

            firstChild.SetHeight(height);

            Assert.Equal(42, firstChild.GetHeight());
        }

        [Fact]
        public void Set_Position_Default_Topic()
        {
            var xmindService = new XmindService();

            CreateDefaultRoot();
            xmindService.PositionArrangementOfNodes();
            var root = xmindService.GetRootNode();
            var positionRoot = root.GetPosition();

            Assert.NotEqual(0,positionRoot.GetX());
            Assert.NotEqual(0, positionRoot.GetY());
        }
    }
}