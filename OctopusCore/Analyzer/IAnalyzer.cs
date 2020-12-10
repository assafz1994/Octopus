using OctopusCore.Parser;

namespace OctopusCore.Analyzer
{
    public interface IAnalyzer
    {
        WorkPlan AnalyzeQuery(QueryInfo queryInfo);
    }
}