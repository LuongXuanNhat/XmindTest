namespace XmindTest_Project
{

    public partial class RootNode : BaseTopic
    {
        public RootNode(string title, int width) : base(title, width)
        {
        }
        internal void CreateDefaultChildren(int numberOfChilden, string defaultTitle, int width)
        {          
            for (int i = 0; i < numberOfChilden; i++)
            {
                AddTopic(defaultTitle, width);
            }
        }

    }

}