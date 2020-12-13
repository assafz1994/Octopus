using System.Threading.Tasks;
using OctopusCore.Contract;
using OctopusCore.Parser;

namespace OctopusCore.Analyzer
{
    public interface IAnalyzer
    {
        Task<WorkPlan> AnalyzeQuery(QueryInfo queryInfo);
    }
}