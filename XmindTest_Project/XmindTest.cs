namespace XmindTest_Project
{
    public partial class XmindTest
    {
        static RootNode CreateDefaultRoot()
        {
            var xmindService = new XmindService();
            var root = xmindService.GetRootNode();
            return root;
        }

        [Fact]
        public void Create_Default_Xmind_File()
        {
            var root = new XmindService().CreateDefault();

            Assert.NotNull(root);

            Assert.NotNull(root.GetTitle());
            Assert.Equal(4, root.GetChildren().Count);

        }

        [Fact]
        public void Create_Detached_Topic()
        {
            var xmindService = new XmindService();
            var root = xmindService.GetRootNode();

            xmindService.CreateDetachedTopic();
            Assert.NotNull(root);

            Assert.Single(root.GetDetachedChildren());
        }

        [Fact]
        public void Create_Attached_Topic()
        {
            // create default topics
            var xmindService = new XmindService();
            var root = xmindService.GetRootNode();
            root.AddTopic("main topic 1");

            Assert.NotNull(root);
            Assert.Equal(5, root.GetChildren().Count);
        }

        [Fact]
        public void Create_SubTopic()
        {
            RootNode root = CreateDefaultRoot();

            BaseTopic? firstTopic = root.GetChildren().First();
            firstTopic!.AddTopic("Sub topic 1");

            Assert.Single(firstTopic.GetChildren());


        }

        [Fact]
        public void Add_Relationship_From_Root_To_Attached_Topic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();
            var relationship = root.AddRelationship(firstTopic.GetId(), xmindService.GetDefaultTitleRelationship());

            Assert.NotNull(relationship);
            Assert.Single(root.GetRelationship());
        }

        [Fact]
        public void Add_Relationship_From_Root_To_Detached_Topic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");
            var relationship = root.AddRelationship(detachedTopic.GetId(), xmindService.GetDefaultTitleRelationship());

            Assert.Single(root.GetRelationship());
        }

        [Fact]
        public void Add_Relationship_From_Root_To_Subtopic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();
            var subTopic = firstTopic.CreateTopic("Subtopic", 15);

            firstTopic.AddTopic(subTopic);
            root.AddRelationship(firstTopic.GetId(), xmindService.GetDefaultTitleRelationship());

            Assert.Single(root.GetRelationship());
        }

        [Fact]
        public void Add_Relationship_From_Attached_Topic_To_Subtopic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();
            var subTopic = firstTopic.CreateTopic("Subtopic", 15);

            firstTopic.AddTopic(subTopic);
            firstTopic.AddRelationship(firstTopic.GetId(), xmindService.GetDefaultTitleRelationship());

            Assert.Single(firstTopic.GetRelationship());
        }

        [Fact]
        public void Add_Relationship_From_Detached_Topic_To_Attached_Topic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");
            var firstTopic = root.GetChildren().First();

            detachedTopic.AddRelationship(firstTopic.GetId(), xmindService.GetDefaultTitleRelationship());

            Assert.Single(detachedTopic.GetRelationship());
        }

        [Fact]
        public void Add_Relationship_From_Detached_Topic_To_Detached_Topic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");
            var detachedTopic2 = root.CreateDetachedTopic("Floating topic");

            detachedTopic.AddRelationship(detachedTopic2.GetId(), xmindService.GetDefaultTitleRelationship());

            Assert.Single(detachedTopic.GetRelationship());
        }

        [Fact]
        public void Add_Note()
        {
            var xmindService = new XmindService();
            var root = xmindService.CreateDefault();
            root.AddNotes(xmindService.GetNotes());

            Assert.Equal(xmindService.GetNotes(), root.GetNotes().GetContent());
        }

        [Fact]
        public void Convert_Attached_Topic_To_Detached_Topic()
        {
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();

            root.MoveChildrenTopicToDetachTopic(firstTopic, root);

            Assert.Equal(3, root.GetChildren().Count);
            Assert.Single(root.GetDetachedChildren());
        }

        [Fact]
        public void Convert_Multiple_Attached_Topic_To_Detached_Topic()
        {
            var root = CreateDefaultRoot();
            var topics = root.GetChildren();

            root.MoveMultipleChildrenTopicToDetachTopic(topics, root);

            Assert.Empty(root.GetChildren());
            Assert.Equal(4, root.GetDetachedChildren().Count);
        }

        [Fact]
        public void Convert_Subtopic_To_Detached_Topic()
        {
            var root = CreateDefaultRoot();
            var parent = root.GetChildren().First();
            var child = parent.CreateTopic("Subtopic", 4);

            parent.MoveChildrenTopicToDetachTopic(child, root);

            Assert.Equal(4, root.GetChildren().Count);
            Assert.Single(root.GetDetachedChildren());
        }

        [Fact]
        public void Convert_Multiple_Subtopic_To_Detached_Topic()
        {
            var root = CreateDefaultRoot();
            var parent = root.GetChildren().First();
            var children = parent.GetChildren();

            parent.AddTopic("Subtopic");
            parent.AddTopic("Subtopic");
            parent.MoveMultipleChildrenTopicToDetachTopic(children, root);

            Assert.Empty(parent.GetChildren());
            Assert.Equal(2, root.GetDetachedChildren().Count);
        }

        [Fact]
        public void Convert_Detached_Topic_To_Attached_Topic()
        {
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("floating topic");

            root.MoveDetachedToAttachTopic(detachedTopic, root);

            Assert.Equal(5, root.GetChildren().Count);
            Assert.Empty(root.GetDetachedChildren());
        }

        [Fact]
        public void Convert_Multiple_Detached_Topic_To_Attached_Topic()
        {
            var root = CreateDefaultRoot();
            var topics = root.GetDetachedChildren();

            root.CreateDetachedTopic("floating topic");
            root.CreateDetachedTopic("floating topic");
            root.MoveMultipleDetachedToAttachTopic(topics, root);

            Assert.Empty(root.GetDetachedChildren());
            Assert.Equal(6, root.GetChildren().Count);
        }

        [Fact]
        public void Convert_Attached_Topic_To_Subtopic()
        {
            var parent = CreateDefaultRoot();
            var firstTopic = parent.GetChildren().First();
            var secondTopic = parent.GetChildren().Last();

            parent.MoveAttachedToChildrenTopic(firstTopic, secondTopic);

            Assert.Equal(3, parent.GetChildren().Count);
            Assert.Single(secondTopic.GetChildren());
        }

        [Fact]
        public void Convert_Multiple_Attached_Topic_To_Subtopic()
        {
            var root = CreateDefaultRoot();
            var children = root.GetChildren();
            var detachedTopic = root.CreateDetachedTopic("Floating Topic");

            root.MoveMultipleAttachedToChildrenTopic(children, detachedTopic);

            Assert.Empty(root.GetChildren());
            Assert.Equal(4, detachedTopic.GetChildren().Count);
        }

        [Fact]
        public void Convert_Detached_Topic_To_Subtopic()
        {
            var parent = CreateDefaultRoot();
            var detachedTopic = parent.CreateDetachedTopic("Floating topic");
            var lastTopic = parent.GetChildren().Last();

            parent.MoveDetachedTopicToChildrenTopic(detachedTopic, lastTopic);

            Assert.Empty(parent.GetDetachedChildren());
            Assert.Single(lastTopic.GetChildren());
        }

        [Fact]
        public void Convert_Multiple_Detached_Topic_To_Subtopic()
        {
            var parent = CreateDefaultRoot();
            var detachedTopic = parent.GetDetachedChildren();
            var lastTopic = parent.GetChildren().Last();

            parent.CreateDetachedTopic("Floating topic");
            parent.CreateDetachedTopic("Floating topic");
            parent.MoveMultipleDetachedTopicToChildrenTopic(detachedTopic, lastTopic);

            Assert.Empty(parent.GetDetachedChildren());
            Assert.Equal(2, lastTopic.GetChildren().Count);
        }

        [Fact]
        public void Delete_All()
        {
            var xmindService = new XmindService();
            var root = xmindService.CreateDefault();
            xmindService.DeleteAll();

            Assert.NotNull(root);
            Assert.Empty(root.GetChildren());
        }

        [Fact]
        public void Delete_Detached_Topic()
        {
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");

            root.DeleteDetachedChildren(detachedTopic);
        }

        [Fact]
        public void Delete_Attached_Topic()
        {
            var root = CreateDefaultRoot();
            var attachedTopic = root.GetChildren().First();

            root.DeleteChildren(attachedTopic);

            Assert.Equal(3, root.GetChildren().Count);
        }

        [Fact]
        public void Delete_Subtopic()
        {
            var root = CreateDefaultRoot();
            var attachedTopic = root.GetChildren().First();
            var subtopic = attachedTopic.CreateTopic("Subtopic");

            attachedTopic.DeleteChildren(subtopic);

            Assert.Empty(attachedTopic.GetChildren());
        }

        [Fact]
        public void Delete_Multiple_Children()
        {
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();
            var detachedTopic = root.CreateTopic("Floating topic");
            var subtopic = firstTopic.CreateTopic("Subtopic");

            root.DeleteDetachedChildren(detachedTopic);
            firstTopic.DeleteChildren(subtopic);

            Assert.Empty(firstTopic.GetChildren());
            Assert.Empty(root.GetDetachedChildren());
        }

        [Fact]
        public void Delete_Detached_Topic_From_Id()
        {
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");

            root.DeleteDetachedChildrenFromId(detachedTopic.GetId());
        }

        [Fact]
        public void Delete_Children_From_Id()
        {
            var root = CreateDefaultRoot();
            var firstTopic = root.GetChildren().First();
            var secondTopic = root.GetChildren().Last();
            var childTopic = firstTopic.CreateTopic("Subtopic");

            firstTopic.AddTopic(childTopic);
            root.DeleteChildrenFromId(secondTopic.GetId());
            firstTopic.DeleteChildrenFromId(childTopic.GetId());

            Assert.Empty(firstTopic.GetChildren());
            Assert.Equal(3, root.GetChildren().Count);
        }

        [Fact]
        public void Delete_Multiple_Topics_By_Id()
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

            root.DeleteChildrenTopics(idSet);

            Assert.Equal(4, root.GetChildren().Count);

        }

        [Fact]
        public void Delete_Multiple_Floating_Topics_By_Id()
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

            root.DeleteDetachedTopics(idSet);

            Assert.Empty(root.GetDetachedChildren());
        }


        [Fact]
        public void Delete_Multiple_Different_Topics_By_Id()
        {
            var root = CreateDefaultRoot();

            var idSet = new List<Guid>();
            var sub1 = root.CreateDetachedTopic("1");
            idSet.Add(sub1.GetId());
            var sub2 = root.CreateDetachedTopic("2");
            idSet.Add(sub2.GetId());
            var sub3 = root.CreateDetachedTopic("3");
            var sub4 = root.CreateTopic("4");

            idSet.Add(sub3.GetId());
            idSet.Add(sub4.GetId());

            Assert.Equal(3, root.GetDetachedChildren().Count);
            Assert.Equal(5, root.GetChildren().Count);

            root.DeleteTopics(idSet);

            Assert.Empty(root.GetDetachedChildren());
            Assert.Equal(4, root.GetChildren().Count);
        }

        [Fact]
        public void Delete_Multiple_Grand_Child_By_Id()
        {
            var root = CreateDefaultRoot();

            var idSet = new List<Guid>();
            var sub1 = root.CreateDetachedTopic("1");

            var sub11 = sub1.CreateTopic("11");
            //delete topic 11
            idSet.Add(sub11.GetId());

            var sub2 = root.CreateDetachedTopic("2");
            //delete detached topic 2
            idSet.Add(sub2.GetId());
            var sub3 = root.CreateTopic("3");

            //delete topic 3
            idSet.Add(sub3.GetId());

            var sub4 = root.CreateTopic("4");

            var sub41 = sub4.CreateTopic("41");
            //delete topic 41
            idSet.Add(sub41.GetId());


            Assert.Single(sub1.GetChildren());
            Assert.Single(sub4.GetChildren());
            Assert.Equal(6, root.GetChildren().Count);
            Assert.Equal(2, root.GetDetachedChildren().Count);

            root.DeleteTopics(idSet);

            Assert.Empty(sub1.GetChildren());
            Assert.Empty(sub4.GetChildren());
            Assert.Equal(5, root.GetChildren().Count);
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

            root.DeleteTopics(idSet);
            //Assert.Empty(sub1.GetChildren());
            Assert.Equal(4, root.GetChildren().Count);
            Assert.Empty(sub11.GetChildren());
        }

        // Target children of attached topic
        [Fact]
        public void Move_Multiple_Grandchildren_1()
        {
            var root = CreateDefaultRoot();

            var objectSet = new List<BaseTopic>();
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

            //target attached topic 5
            var sub5 = root.CreateTopic("Topic 5");

            Assert.Equal(7, root.GetChildren().Count);
            Assert.Equal(1, sub1.GetChildren().Count);
            Assert.Equal(1, sub4.GetChildren().Count);

            sub5.MoveTopics(objectSet,idtSet, root);

            //Assert.Empty(sub1.GetChildren());
            Assert.Equal(6, root.GetChildren().Count);
            Assert.Empty(sub11.GetChildren());
            Assert.Empty(sub11.GetChildren());
            Assert.Equal(4,sub5.GetChildren().Count);
        }

        // Target grandchildren of detached topic
        [Fact]
        public void Move_Multiple_Grandchildren_2()
        {
            var root = CreateDefaultRoot();

            var objectSet = new List<BaseTopic>();
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
            Assert.Equal(1, sub1.GetChildren().Count);
            Assert.Equal(1, sub4.GetChildren().Count);

            childOfSub5.MoveTopics(objectSet,idtSet, root);

            //Assert.Empty(sub1.GetChildren());
            Assert.Equal(5, root.GetChildren().Count);
            Assert.Empty(sub11.GetChildren());
            Assert.Empty(sub11.GetChildren());
            Assert.Equal(4, childOfSub5.GetChildren().Count);
        }

        [Fact]
        public void Set_Width_For_Topic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var firstChild = root.GetChildren().First();

            firstChild.SetWidth(xmindService.GetDefaultWidth());

            Assert.Equal(30, firstChild.GetWidth());
        }

        [Fact]
        public void Set_Default_Height_Topic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();
            var firstChild = root.GetChildren().First();

            firstChild.SetHeight(xmindService.GetDefaultHeight());

            Assert.Equal(10 , firstChild.GetHeight());
        }

        [Fact]
        public void Set_Position_Topic()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();

            xmindService.SetDefaultPositionTopic(root);
            var firstTopic = root.GetChildren().First();
            var positionFirstTopic = firstTopic.GetPosition();
            var x = root.GetPosition().GetX() + xmindService.GetDefaultWidth() + xmindService.GetDefaultSpace();
            var y = root.GetPosition().GetY() + xmindService.GetDefaultHeight() + xmindService.GetDefaultSpace();
            var positionExpected = new Position(x,y);

            Assert.Equal(620, root.GetPosition().GetX());
            Assert.Equal(385, root.GetPosition().GetY());
            Assert.Equal(positionExpected.GetX(), positionFirstTopic.GetX());
            Assert.Equal(positionExpected.GetY(), positionFirstTopic.GetY());
        }
        
        [Fact]
        public void Check_Child_Is_In_The_Correct_Position()
        {
            var xmindService = new XmindService();
            var root = CreateDefaultRoot();

            xmindService.SetDefaultPositionTopic(root);
            var firstTopic = root.GetChildren().First();
            var lastTopic = root.GetChildren().Last();
            var childOfFirstTopic = firstTopic.CreateTopic("Subtopic 1");
            var childOfLastTopic = lastTopic.CreateTopic("Subtopic 2");
            var positionExpected1 = xmindService.SetPositionTopic(firstTopic,childOfFirstTopic);
            var positionExpected2 = xmindService.SetPositionTopic(lastTopic,childOfLastTopic);

            Assert.Equal(positionExpected1.GetX(), childOfFirstTopic.GetPosition().GetX());
            Assert.Equal(positionExpected1.GetY(), childOfFirstTopic.GetPosition().GetY());
            Assert.Equal(positionExpected2.GetX(), childOfLastTopic.GetPosition().GetX());
            Assert.Equal(positionExpected2.GetY(), childOfLastTopic.GetPosition().GetY());
        }
    }
}