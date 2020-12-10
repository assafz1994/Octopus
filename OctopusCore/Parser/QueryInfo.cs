namespace OctopusCore.Parser
{
    public class QueryInfo
    {
        public string Entity { get; set; }

        public Filter[] Filters { get; set; }

        public Field[] Projection { get; set; }
    }
}