using System.Threading.Tasks;
using Octopus.Common;
using OctopusCore.Contract;

namespace OctopusCore
{
    public interface IOctopusService
    {
        Task<OctopusResponse> ExecuteQueryAsync(string query);
    }
}