namespace OctopusCore.Parser
{
    public abstract class Filter
    {
        public string FieldName { get; set; }

        public string Expression { get; set; }
    }
}