using System.Threading.Tasks;

namespace OctopusCore.Parser
{
    public interface IParser
    {
        Task<QueryInfo> ParseQuery(string query);
    }
}