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
            var rootTopic = new RootTopic();
            rootTopic.CreateDetachedRootTopic(10, "Floating Topic");

            rootTopic.CreateChildTopic(6, "Subtopic 1");
            var childTopic = rootTopic.rootChild.First();
            int idExpected = childTopic.id;
            childTopic.rootChild = new List<ChildrenTopic>();
            childTopic.rootChild.Add(childTopic.CreateChild(7, "Subtopic child 1"));

            Assert.False(rootTopic.FindRootChild(idExpected));
        }
    }
}
