using System.Collections.Generic;

namespace OctopusCore.Parser
{
    public class InsertQueryInfo : QueryInfo
    {
        public List<ParserEntity> ParserEntities { get; set; }
        public List<string> EntityReps { get; set; }
        

        public InsertQueryInfo(List<ParserEntity> parserEntities, List<string> entityReps)
        {
            SubQueries = new Dictionary<string, QueryInfo>();
            ParserEntities = parserEntities;
            EntityReps = entityReps;
        }
    }
}