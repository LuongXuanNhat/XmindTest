using AutoFixture.Xunit2;
using Fare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmindTest
{
    public class ObjectTest
    {

        public ObjectTest() { }

        [Fact] 
        public void Create_File()
        {
            var root = new Root();
            root.CreateNewMap(1, "Central Topic");

            Assert.NotNull(root);
            Assert.Equal(root.rootTopic.Count, 4);
        }

        [Fact]
        public void Create_RootTopic_When_Double_Click()
        {
            var rootTopic = new RootTopic();
            rootTopic.CreateDetachedRootTopic(10, "Floating Topic");

            Assert.NotNull(rootTopic);
            Assert.Equal(rootTopic.GetType(), new RootTopic().GetType());
        }
        
        [Fact]
        public void Create_RootTopic_When_Press_Tab()
        {
            var root = new Root();
            root.CreateNewMap(1, "Central Topic");
            var rootTopic = root.CreateAttachedRootTopic(1, "Main Topic");

            Assert.NotNull(rootTopic);
            Assert.Equal(rootTopic.title, "Main Topic");
        }

        [Fact]
        public void Create_ChildTopic_When_Press_Tab()
        {
            var root = new Root();
            root.CreateNewMap(1, "Central Topic");
            var rootTopic = root.rootTopic.Last();
            rootTopic.CreateChildTopic(6, "Subtopic 1");

            Assert.NotNull(rootTopic.rootChild.First());
            Assert.Equal(rootTopic.rootChild.First().title, "Subtopic 1");
        }

        [Fact]
        public void Delete_RootTopic()
        {
            var root = new Root();
            root.CreateNewMap(1, "Central Topic");
            int idExpected = root.rootTopic.First().id;
            root.rootTopic.First().CreateChildTopic(6, "Subtopic 1");
            root.rootTopic.Remove(root.rootTopic.First());

            Assert.False(root.FindRootTopic(idExpected));
        }

        // rootTopic -> rootChild -> rootChild
        [Fact]
        public void Delete_ChildTopic()
        {
            // rootTopic
            var rootTopic = new RootTopic();
            rootTopic.CreateDetachedRootTopic(10, "Floating Topic");

            // rootTopic -> rootChild
            rootTopic.CreateChildTopic(6, "Subtopic 1");

            // rootTopic -> rootChild -> rootChild
            var childTopic = rootTopic.rootChild.First();
            int idExpected = childTopic.id;
            childTopic.CreateChildTopic(7, "Subtopic child 1");

            rootTopic.rootChild.Remove(childTopic);

            Assert.False(rootTopic.FindRootChild(idExpected));
        }

        [Fact]
        public void Pull_RootTopic_Out_Of_Branch()
        {
            var root = new Root();
            root.CreateNewMap(1, "Central Topic");

            var root_Topic = new RootTopic();
            root_Topic = root.rootTopic.First();
            root.rootTopic.Remove(root_Topic);

            Assert.Equal(root.rootTopic.Count,3);
            Assert.NotNull(root_Topic);

        }

    }
}
