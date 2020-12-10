namespace OctopusCore.Parser
{
    public interface IParser
    {
        QueryInfo ParseQuery(string query);
    }
}