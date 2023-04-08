namespace AntExperiments.Models
{
    public class MetaObjectTreeNode
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public Guid Uid { get; set; }
        public string IconClass { get; set; }
        public bool IsChecked { get; set; }
        public bool HasChildren => Children == null ? false : Children.Any();
        public List<MetaObjectTreeNode> Children { get; set; }
    }
}
