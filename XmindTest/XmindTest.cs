using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmindTest
{
    public class XmindTest
    {
        [Theory, AutoData]
        public void Create_Map(Root root)
        {
            root.Create_Map();
            
            Assert.NotNull(root);
            Assert.Equal(root.GetTitle(), "Central Topic");
            Assert.Equal(root.GetRootTopic().Count(), 4);
        }

        [Fact]
        public void Create_RootTopic_Detached_When_Double_Click()
        {
            var rootTopic = new RootTopic().Create_RootTopic_Detached();

            Assert.NotNull(rootTopic);
            Assert.Equal(rootTopic.GetTitle(), "Floating Topic");
        }

        [Fact]
        public void Delete_RootTopic_Detached()
        {
            var rootTopic = new RootTopic().Create_RootTopic_Detached();
            rootTopic = null;
            // GC.Collect();

            Assert.Null(rootTopic);
        }

        [Theory, AutoData]
        public void Create_RootTopic_Attached_When_Press_Tab(Root root)
        {
            root.Create_Map();
            root.Create_RootTopic_Attached();

            Assert.Equal(root.GetRootTopic().Last().GetTitle(), "Main Topic 5");
        }


        [Theory, AutoData]
        public void Delete_RootTopic_Attached(Root root)
        {
            root.Create_RootTopic_Attached();
            root.Delete_RootTopic(root.GetRootTopic().First());

            Assert.Equal(root.GetRootTopic().Count, 0);
        }

        [Fact]
        public void Create_RootChild_When_Press_Tab()
        {
            var rootTopic = new RootTopic().Create_RootTopic_Detached();
            rootTopic.Create_SubTopic();

            Assert.NotNull(rootTopic.GetSubTopic());
            Assert.Equal(rootTopic.GetSubTopic().First().GetTitle(), "Subtopic 1");
        }

        [Theory, AutoData]
        public void Delete_RootChild(RootTopic rootTopic)
        {
            rootTopic.Create_RootTopic_Detached().Create_SubTopic();
            rootTopic.Delete_RootChild(rootTopic.GetSubTopic().First());

            Assert.Equal(rootTopic.GetSubTopic().Count, 0);
        }

        [Theory, AutoData]
        public void Add_Notes(Root root ,string content)
        {
            root.Add_Notes(content);

            Assert.Equal(root.GetNotes().GetPlain().GetContent(), content);
        }

        // root ------relationship------> root_Topic_Detached 
        // root ------relationship------> child of root_Topic_Detached
        [Theory, AutoData]
        public void Add_RelationShip_When_Know_2_Points(Root root, RootTopic root_Topic)
        {
            root_Topic.Create_RootTopic_Detached().Create_SubTopic(); ;
            root.Add_RelationShip(root_Topic);
            root.Add_RelationShip(root_Topic.GetSubTopic().First());

            Assert.Equal(root.GetRelationShip().Count,2);
            Assert.Equal(root.GetRelationShip().First().GetTitle(), "Relationship");
        }

        [Theory, AutoData]
        public void Add_RelationShip_When_Know_Starting_Points(Root root)
        {
            root.Add_RelationShip();

            Assert.Equal(root.GetRelationShip().First().GetTitle(), "Relationship");

        }

        [Theory, AutoData]
        public void Remove_RelationShip(Root root, RootTopic root_Topic)
        {
            root_Topic.Create_RootTopic_Detached();
            root.Add_RelationShip(root_Topic);
            root.Remove_RelationShip(root.GetRelationShip().First());

            Assert.Equal(root.GetRelationShip().Count(), 0);
        }

        [Theory, AutoData]
        public void Rename_Roots(Root root, RootTopic root_Topic, Children children, string rootName, string rootTopicName, string rootChildName)
        {
            root.GetRootTopic().Add(root_Topic.Create_RootTopic_Attached(1));
            root_Topic.GetSubTopic().Add(children.Create_SubTopic(1));

            root.Rename(rootName);
            root_Topic.Rename(rootTopicName);
            children.Rename(rootChildName);


            Assert.Equal(root.GetTitle(),rootName);
            Assert.Equal(root_Topic.GetTitle(), rootTopicName);
            Assert.Equal(children.GetTitle(), rootChildName);
        }

        [Theory, AutoData]
        public void Add_Link(string link, Root root)
        {
            root.Add_Link(link);

            Assert.Equal(root.GetHref(), link);
        }

        [Theory, AutoData]
        public void SetWidth(Root root, RootTopic rootTopic, Children children,float Width = 20)
        {
            root.SetWidth(Width);
            rootTopic.SetWidth(Width);
            children.SetWidth(Width);

            Assert.Equal(root.GetWidth(), Width);
            Assert.Equal(children.GetWidth(), Width);
            Assert.Equal(rootTopic.GetWidth(), Width);
        }

        [Theory, AutoData]
        public void Convert_RootChild_To_RootTopic_Attached(Root root, RootTopic rootTopic, Children children)
        {
            root.GetRootTopic().Add(rootTopic.Create_RootTopic_Attached(1));
            rootTopic.GetSubTopic().Add(children.Create_SubTopic(rootTopic.GetSubTopic().Count()+1));
            rootTopic.GetSubTopic().Remove(children);
            root.Convert_To_RootTopic_Attached(children);

            Assert.Equal(root.GetRootTopic().Last().GetTitle(), "Subtopic 1");
            Assert.Equal(root.GetRootTopic().Last().GetWidth(), 25);
        }

        [Theory, AutoData]
        public void Convert_RootTopic_Attached_To_RootChild(Root root, RootTopic rootTopic_Attached, RootTopic rootTopic_Detached)
        {
            root.GetRootTopic().Add(rootTopic_Attached.Create_RootTopic_Attached(root.GetRootTopic().Count+1));
            rootTopic_Detached.Create_RootTopic_Detached();
            rootTopic_Attached.Convert_To_RootChild(root, rootTopic_Detached);

            Assert.Equal(root.GetRootTopic().Count(),0);
            Assert.Equal(rootTopic_Detached.GetSubTopic().First().GetTitle(), "Main Topic 1");
            Assert.Equal(rootTopic_Detached.GetSubTopic().First().GetWidth(), 15);
        }

        [Theory, AutoData]
        public void Convert_RootChild_To_RootTopic_Detached(RootTopic rootTopic, Children children, RootTopic rootTopic_Detached)
        {
            rootTopic.Create_RootTopic_Detached().GetSubTopic().Add(children.Create_SubTopic(1));
            rootTopic_Detached = children.Convert_To_RootTopic_Detached(rootTopic);

            Assert.Equal(rootTopic.GetSubTopic().Count(),0);
            Assert.Equal(rootTopic_Detached.GetWidth(), 20);
        }

        [Theory, AutoData]
        public void Convert_RootTopic_Detached_To_RootChild(RootTopic rootTopic_Detached, RootTopic rootTopic_Detached_2)
        {
            rootTopic_Detached.Create_RootTopic_Detached();
            rootTopic_Detached_2.Create_RootTopic_Detached();

            rootTopic_Detached_2.Convert_To_RootChild(rootTopic_Detached);

            Assert.Equal(rootTopic_Detached.GetSubTopic().First().GetWidth(), 15);
        }

        [Theory, AutoData]
        public void Convert_RootTopic_Detached_To_RootTopic_Attached(Root root, RootTopic rootTopic_Attached)
        {
            root.GetRootTopic().Add(rootTopic_Attached.Create_RootTopic_Attached(1));
            rootTopic_Attached.Convert_To_Detached(root);

            Assert.Equal(rootTopic_Attached.GetWidth(), 20);
        }

        
        [Theory,AutoData]
        public void Convert_RootTopic_Attached_To_RootTopic_Detached(Root root, RootTopic rootTopic_Detached)
        {
            rootTopic_Detached.Create_RootTopic_Detached();
            rootTopic_Detached.Convert_To_Attached(root);

            Assert.Equal(root.GetRootTopic().First().GetWidth(), 25);
        }

        [Theory,AutoData]
        public void Move_RootChild(Children root_Child, RootTopic rootTopic_Detached_1, RootTopic rootTopic_Detached_2)
        {
            rootTopic_Detached_1.Create_RootTopic_Detached().GetSubTopic().Add(root_Child.Create_SubTopic(1));
            rootTopic_Detached_2.Create_RootTopic_Detached();
            root_Child.Move_RootChile(rootTopic_Detached_1 , rootTopic_Detached_2);


            Assert.Equal(rootTopic_Detached_1.GetSubTopic().Count, 0);
            Assert.Equal(rootTopic_Detached_2.GetSubTopic().First().GetTitle(), "Subtopic 1");
        }


    }
}
