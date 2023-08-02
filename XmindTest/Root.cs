namespace XmindTest
{
    public class Root 
    {

        public int id { get; set; }
        public string title { get; set; }
        public string href { get; set; }
        public Notes notes { get; set; }
        public List<RootTopic> rootTopic { get; set; }
        public List<RelationShip> relationShip { get; set; }

        public void CreateAttachedRootTopic()
        {
            this.rootTopic.Add(new RootTopic
            {
                title = "Main Topic 5",
                id = 5,
                href = "",
                notes = new Notes(),
                relationShip = new List<RelationShip>()
                {
                    new RelationShip()
                    {
                        id = 5,
                        end1Id = 1,
                        end2Id = 5,
                        controlPoints = new ControlPoints()
                        {
                            position = new Position()
                            {
                                x = 0, y = 0
                            }
                        },
                        lineEndPoints = new LineEndPoints()
                        {
                            position = new Position()
                            {
                                x = 1, y = 0
                            }
                        }
                    }
                }
            });
            
        }

        public void CreateNewMap()
        {
            id = 1;
            title = "Central Topic";
            rootTopic = new List<RootTopic>()
            {
                new RootTopic()
                {
                    id = 1,
                    title = "Main Topic 1",
                    href = "",
                    notes = new Notes()
                    {
                        plain = new Plain()
                        {
                            content = ""
                        },
                        readHTML = new ReadHTML()
                        {
                            content = ""
                        }
                    },
                    rootChild = new List<ChildrenTopic>()
                    {
                        ///// 
                    },
                    relationShip = new List<RelationShip>()
                    {
                        new RelationShip()
                        {
                            id =1,
                            end1Id = this.id,
                            end2Id = 1,
                            controlPoints = new ControlPoints()
                            {
                                position = new Position()
                                {
                                    x = 0, y = 0
                                }
                            },
                            lineEndPoints = new LineEndPoints()
                            {
                                position = new Position()
                                {
                                    x = 1, y = 1
                                }
                            }
                        }
                    }
                },
                new RootTopic()
                {
                    id = 2,
                    title = "Main Topic 2",
                    href = "",
                    notes = new Notes()
                    {
                        plain = new Plain()
                        {
                            content = ""
                        },
                        readHTML = new ReadHTML()
                        {
                            content = ""
                        }
                    },
                    rootChild = new List<ChildrenTopic>()
                    {
                        ///// 
                    },
                    relationShip = new List<RelationShip>()
                    {
                        new RelationShip()
                        {
                            id =2,
                            end1Id = this.id,
                            end2Id = 2,
                            controlPoints = new ControlPoints()
                            {
                                position = new Position()
                                {
                                    x = 0, y = 0
                                }
                            },
                            lineEndPoints = new LineEndPoints()
                            {
                                position = new Position()
                                {
                                    x = 1, y = 2
                                }
                            }
                        }
                    }
                },
                new RootTopic()
                {
                    id = 3,
                    title = "Main Topic 3",
                    href = "",
                    notes = new Notes()
                    {
                        plain = new Plain()
                        {
                            content = ""
                        },
                        readHTML = new ReadHTML()
                        {
                            content = ""
                        }
                    },
                    rootChild = new List<ChildrenTopic>()
                    {
                        ///// 
                    },
                    relationShip = new List<RelationShip>()
                    {
                        new RelationShip()
                        {
                            id = 3,
                            end1Id = this.id,
                            end2Id = 3,
                            controlPoints = new ControlPoints()
                            {
                                position = new Position()
                                {
                                    x = 0, y = 0
                                }
                            },
                            lineEndPoints = new LineEndPoints()
                            {
                                position = new Position()
                                {
                                    x = 2, y = 1
                                }
                            }
                        }
                    }
                },
                new RootTopic()
                {
                    id = 4, 
                    title = "Main Topic 4",
                    href = "",
                    notes = new Notes()
                    {
                        plain = new Plain()
                        {
                            content = ""
                        },
                        readHTML = new ReadHTML()
                        {
                            content = ""
                        }
                    },
                    rootChild = new List<ChildrenTopic>()
                    {
                        ///// 
                    },
                    relationShip = new List<RelationShip>()
                    {
                        new RelationShip()
                        {
                            id = 4,
                            end1Id = this.id,
                            end2Id = 4,
                            controlPoints = new ControlPoints()
                            {
                                position = new Position()
                                {
                                    x = 0, y = 0
                                }
                            },
                            lineEndPoints = new LineEndPoints()
                            {
                                position = new Position()
                                {
                                    x = 1, y = 1
                                }
                            }
                        }
                    }
                }

            };

         }
    }
}