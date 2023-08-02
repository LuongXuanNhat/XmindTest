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

        internal void CreateNewMap()
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
                    }
                }

            };

         }
    }
}