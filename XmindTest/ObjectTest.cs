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
            var root = new Root()
            {
                id = 1,
                title = "Central Topic",
                rootTopic = new List<RootTopic>()
                {
                    new RootTopic()
                    {
                        id = 1,
                        title = "Main Topic1",
                        href = "abc.xyz",
                        Notes = new Notes()
                        {
                            plain = new Plain()
                            {
                                content = "content"
                            },
                            readHTML = new ReadHTML()
                            {
                                content = "content"
                            }
                        },
                        children = new List<ChildrenTopic>()
                        {
                            ///// 
                        }
                    },
                    new RootTopic()
                    {
                        id = 2,
                        title = "Main Topic2",
                        href = "abc.xyz",
                        Notes = new Notes()
                        {
                            plain = new Plain()
                            {
                                content = "content"
                            },
                            readHTML = new ReadHTML()
                            {
                                content = "content"
                            }
                        },
                        children = new List<ChildrenTopic>()
                        {
                            ///// 
                        }
                    },
                    new RootTopic()
                    {
                        id = 3,
                        title = "Main Topic3",
                        href = "abc.xyz",
                        Notes = new Notes()
                        {
                            plain = new Plain()
                            {
                                content = "content"
                            },
                            readHTML = new ReadHTML()
                            {
                                content = "content"
                            }
                        },
                        children = new List<ChildrenTopic>()
                        {
                            ///// 
                        }
                    },
                    new RootTopic()
                    {
                        id = 4,
                        title = "Main Topic4",
                        href = "abc.xyz",
                        Notes = new Notes()
                        {
                            plain = new Plain()
                            {
                                content = "content"
                            },
                            readHTML = new ReadHTML()
                            {
                                content = "content"
                            }
                        },
                        children = new List<ChildrenTopic>()
                        {
                            ///// 
                        }
                    }

                },

            };
            Assert.NotNull(root);
            Assert.Equal(root.rootTopic.Count, 4);
        }

        [Fact]
        public void Create_RootTopic_When_Double_Click()
        {
            var root = new RootTopic()
            {
              title = "title",
              id = 3,
              href = ""
            };

            Assert.NotNull(root);
            Assert.Equal(root.GetType(), new RootTopic().GetType());
        }

        [Theory, AutoData]
        public void Create_RelationShip(int startX, int startY, int endX, int endY)
        {
            var root1 = new RootTopic()
            {
                id = 1,
                title = "title",

            };
            var root2 = new RootTopic()
            {
                id = 2,
                title = "title",
            };

            var relationShip = new RelationShip()
            {
                id = 1,
                controlPoints = new ControlPoints()
                {
                    position = new Position()
                    {
                       
                    }
                },
                lineEndPoints = new LineEndPoints()
                {
                    position = new Position()
                    {
                       
                    }
                }
            };

            root1.relationShip = new List<RelationShip>(){ relationShip };
            relationShip.controlPoints.position.x = startX; relationShip.controlPoints.position.y = startY;

            root2.relationShip = new List<RelationShip> { relationShip };
            relationShip.lineEndPoints.position.x = endX; relationShip.lineEndPoints.position.y = endY;

            // Get relationShip of root1 & root2
            var relationships = root1.relationShip
            .Join(root2.relationShip,
                relationShip1 => relationShip1.id,
                relationShip2 => relationShip2.id,
                (relationShip1, relationShip2) => relationShip1)
            .FirstOrDefault();

            if (relationships == null) Assert.False(true);
            else
            {
                Assert.Equal(relationships.controlPoints.position.x, startX);
                Assert.Equal(relationships.controlPoints.position.y, startY);
                Assert.Equal(relationships.lineEndPoints.position.x, endX);
                Assert.Equal(relationships.lineEndPoints.position.y, endY);
            }

        }

        [Fact]
        public void Create_Child_Topic_When_Tab()
        {
            // Create New File
            var root = new Root()
            {
                id = 1,
                title = "Central Topic",
                rootTopic = new List<RootTopic>()
                {
                    new RootTopic()
                    {
                        id = 1,
                        title = "Main Topic1",
                        href = "abc.xyz",
                        Notes = new Notes()
                        {
                            plain = new Plain()
                            {
                                content = "content"
                            },
                            readHTML = new ReadHTML()
                            {
                                content = "content"
                            }
                        },
                        children = new List<ChildrenTopic>()
                        {
                            ///// 
                        }
                    },
                    new RootTopic()
                    {
                        id = 2,
                        title = "Main Topic2",
                        href = "abc.xyz",
                        Notes = new Notes()
                        {
                            plain = new Plain()
                            {
                                content = "content"
                            },
                            readHTML = new ReadHTML()
                            {
                                content = "content"
                            }
                        },
                        children = new List<ChildrenTopic>()
                        {
                            ///// 
                        }
                    },
                    new RootTopic()
                    {
                        id = 3,
                        title = "Main Topic3",
                        href = "abc.xyz",
                        Notes = new Notes()
                        {
                            plain = new Plain()
                            {
                                content = "content"
                            },
                            readHTML = new ReadHTML()
                            {
                                content = "content"
                            }
                        },
                        children = new List<ChildrenTopic>()
                        {
                            ///// 
                        }
                    },
                    new RootTopic()
                    {
                        id = 4,
                        title = "Main Topic4",
                        href = "abc.xyz",
                        Notes = new Notes()
                        {
                            plain = new Plain()
                            {
                                content = "content"
                            },
                            readHTML = new ReadHTML()
                            {
                                content = "content"
                            }
                        },
                        children = new List<ChildrenTopic>()
                        {
                            ///// 
                        }
                    }

                },

            };

            // ChildeTopic of RootTopic
            var rootTopic = root.rootTopic.FirstOrDefault();
            rootTopic.children.AddRange(new List<ChildrenTopic>()
            {
                new ChildrenTopic()
                {
                    id = 1,
                    title = "Subtopic 1",
                    childenTopic = new List<ChildrenTopic> { }
                },
                new ChildrenTopic()
                {
                    id = 2,
                    title = "Subtopic 2",
                    childenTopic = new List<ChildrenTopic> {  }
                }
            });

            // ChildeTopic of ChildeTopic
            var childTopic = rootTopic.children.Where(x=>x.id == 1).FirstOrDefault();
            childTopic.childenTopic.Add(new ChildrenTopic()
            {
                id = 10,
                title = "Subtopic Child 2",
                childenTopic = new List<ChildrenTopic> { }
            });
            var result = childTopic.childenTopic.Where(x => x.id == 10).FirstOrDefault();

            // Check Child_RootTopic
            Assert.Equal(2, rootTopic.children.Count);
            // Check Child of Chile_Topic
            Assert.Equal("Subtopic Child 2", result.title);

        }


    }
}
