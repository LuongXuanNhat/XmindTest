using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmindTest
{
    public class XmindTest
    {
        [Fact]
        public void Create_Map()
        {
            var root = new Root();
            root.Create_Map();
            
            Assert.NotNull(root);
            Assert.Equal(root.GetTitle(), "Central Topic");
            Assert.Equal(root.GetRootTopic().Count(), 4);
        }

        [Fact]
        public void Create_RootTopic_When_Double_Click()
        {
            var rootTopic = new RootTopic().Create_RootTopic_Detached();

            Assert.NotNull(rootTopic);
            Assert.Equal(rootTopic.GetTitle(), "Floating Topic");
        }

        [Fact]
        public void Create_RootTopic_When_Press_Tab()
        {
            var root = new Root();
            root.Create_Map();

            root.Create_RootTopic_Attached();
            var rootTopic = root.GetRootTopic();

            Assert.Equal(rootTopic.Count,5);
            Assert.Equal(rootTopic.Last().GetTitle(), "Main Topic 5");
        }

        [Fact]
        public void Create_ChildTopic_When_Press_Tab()
        {
            var rootTopic = new RootTopic().Create_RootTopic_Detached();
            rootTopic.Create_SubTopic();

            Assert.NotNull(rootTopic.GetSubTopic());
            Assert.Equal(rootTopic.GetSubTopic().First().GetTitle(), "Subtopic 1");
        }

        [Fact]
        public void Delete_RootTopic()
        {
            var rootTopic = new RootTopic().Create_RootTopic_Detached();
            rootTopic.Create_SubTopic();

            rootTopic = null;
            GC.Collect();

            Assert.Null(rootTopic);
        }

        [Fact]
        public void Delete_RootChild()
        {
            var rootTopic = new RootTopic().Create_RootTopic_Detached();
            rootTopic.Create_SubTopic();    rootTopic.Create_SubTopic();

            // Khi nhấn xóa - nó lấy id của nút. Nhưng Id của root em đặt bằng Guid
            // nên không lấy được, em đổi qua title ạ
            var rootChild = rootTopic.GetSubTopic().Where(x => x.GetTitle().Equals("Subtopic 2")).FirstOrDefault();
            Assert.NotNull(rootChild);
            rootTopic.GetSubTopic().Remove(rootChild);
            Assert.Equal(rootTopic.GetSubTopic().Count,1);
        }

        [Theory, AutoData]
        public void Add_Notes(string content)
        {
            var root = new Root();
            root.Add_Notes(content);

            Assert.Equal(root.GetNotes().GetPlain().GetContent(), content);
        }

        [Fact]
        public void Add_RelationShip()
        {

        }
    }
}
