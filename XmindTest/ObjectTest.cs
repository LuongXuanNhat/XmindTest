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
            root.CreateNewMap();

            Assert.NotNull(root);
            Assert.Equal(root.rootTopic.Count, 4);
        }

        [Fact]
        public void Create_RootTopic_When_Double_Click()
        {
            var rootTopic = new RootTopic();
            rootTopic.CreateDetachedRootTopic();

            Assert.NotNull(rootTopic);
            Assert.Equal(rootTopic.GetType(), new RootTopic().GetType());
        }
        
        [Fact]
        public void Create_RootTopic_When_Press_Tab()
        {
            var root = new Root();
            root.CreateNewMap();
            root.CreateAttachedRootTopic();

            Assert.NotNull(root.rootTopic.Last());
            Assert.Equal(root.rootTopic.Last().title, "Main Topic 5");
        }

        [Fact]
        public void Create_ChildTopic_When_Press_Tab()
        {
            var root = new Root();
            root.CreateNewMap();
            root.rootTopic.First().CreateChildTopic();

            Assert.NotNull(root.rootTopic.First().rootChild.First());
            Assert.Equal(root.rootTopic.First().rootChild.First().title, "Subtopic 1");
        }



        [Fact]
        public void Delete_RootTopic()
        {
            var root = new Root();
            root.CreateNewMap();
            root.rootTopic.First().CreateChildTopic();
            root.DeleteRootTopic(1);

            Assert.True(root.FindRootTopic(1));
        }


    }
}
