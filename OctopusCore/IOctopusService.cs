using System.Threading.Tasks;

namespace OctopusCore
{
    public interface IOctopusService
    {
        Task ExecuteQuery(string query);//todo change void to result
    }
}