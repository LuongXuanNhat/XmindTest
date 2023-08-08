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
        public void Add_Relationship()
        {
            var root = CreateDefaultRoot();

            BaseTopic firstTopic = root.GetChildren().First();
            var relationship = root.AddRelationship(firstTopic);

            Assert.NotNull(relationship);
            Assert.Single(root.GetRelationship());
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
            Assert.Equal(4,root.GetDetachedChildren().Count);
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
            Assert.Equal(2,root.GetDetachedChildren().Count);
        }

        [Fact]
        public void Convert_Detached_Topic_To_Attached_Topic()
        {
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("floating topic");

            root.MoveDetachedToAttachTopic( detachedTopic, root);

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
            root.MoveMultipleDetachedToAttachTopic( topics, root);

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
            Assert.Equal(4,detachedTopic.GetChildren().Count);
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
            Assert.Equal(2,lastTopic.GetChildren().Count);
        }

        //[Fact] 
        //public void Convert_Multiple_Different_Topic_To_Detached_Topic()
        //{
        //    var xmindService = new XmindService();
        //    var parent = CreateDefaultRoot();
        //    var detachedTopic = parent.GetDetachedChildren();
        //    var firstTopic = parent.GetChildren().First();
        //    var lastTopic = parent.GetChildren().Last();
        //    var subTopic = firstTopic.CreateTopic("Subtopic");
        //    var double = xmindService.CreateListPair();

        //    double.AddPair(subTopic, firstTopic);
        //    double.AddPair(lastTopic, parent);
        //    parent.MoveMultipleDifferentDetachedTopicToChildrenTopic(double, parent);

        //    Assert.Empty(parent.GetDetachedChildren());
        //    Assert.Equal(3,lastTopic.GetChildren().Count);
        //}

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

            Assert.Equal(3,root.GetChildren().Count);
        }

        [Fact]
        public void Delete_Detached_Topic_From_Id() { 
            var root = CreateDefaultRoot();
            var detachedTopic = root.CreateDetachedTopic("Floating topic");

            root.DeleteDetachedChildrenFromId(detachedTopic.GetId());
        }

        [Fact]
        public void Delete_Children_From_Id() { 
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
        public void Delete_Subtopic()
        {
            var root = CreateDefaultRoot();
            var attachedTopic = root.GetChildren().First();
            var subtopic = attachedTopic.CreateTopic("Subtopic");

            root.DeleteChildren(subtopic);

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
        public void Delete()
        {

        }

    }
}