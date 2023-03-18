namespace NaiveGraph.Commands
{
    public class Field
    {
        public string Name { get; set; }

        public FieldType Type { get; set; }

        /// <summary>
        /// In case <see cref="Type"/> is <see cref="FieldType.Node"/>.
        /// </summary>
        public string NodeType { get; set; }

        public IndexType Index { get; set; }

        public bool IsArray { get; set; }
    }
}