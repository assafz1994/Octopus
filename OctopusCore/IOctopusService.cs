using System.Threading.Tasks;
using OctopusCore.Contract;

namespace OctopusCore
{
    public interface IOctopusService
    {
        Task<ExecutionResult> ExecuteQueryAsync(string query);
    }
}