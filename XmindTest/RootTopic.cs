namespace XmindTest
{
    public class RootTopic : Root
    {
        public RootTopic() { }
        public List<ChildrenTopic> rootChild { get; set; }

        public void CreateDetachedRootTopic()
        {
            title = "Floating Topic";
            id = 3;
            href = "";
            notes = new Notes();
            relationShip = new List<RelationShip>();
        }

        public void CreateChildTopic()
        {
            this.rootChild = new List<ChildrenTopic>()
            {
                new ChildrenTopic()
                {
                    id = 1,
                    title = "Subtopic 1",
                    href = href,
                    notes = new Notes(),
                    relationShip = new List<RelationShip>()
                    {
                        new RelationShip()
                        {
                            id = 10,
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
                    
                }
            };
        }

    }
}