using System.Collections.Generic;
using System.Linq;

namespace OctopusCore.Parser
{
    public class InsertQueryInfo : QueryInfo
    {
        public List<ParserEntity> ParserEntities { get; set; }
        public List<string> EntityReps { get; set; }

        public InsertQueryInfo()
        {
            ParserEntities = new List<ParserEntity>();
            EntityReps = new List<string>();
            SubQueries = new Dictionary<string, QueryInfo>();
        }

        public InsertQueryInfo(List<ParserEntity> parserEntities, List<string> entityReps)
        {
            SubQueries = new Dictionary<string, QueryInfo>();
            ParserEntities = parserEntities;
            EntityReps = entityReps;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (!(obj is InsertQueryInfo insertQueryInfo)) return false;
            return
                ParserEntities.SequenceEqual(insertQueryInfo.ParserEntities)
                && EntityReps.SequenceEqual(insertQueryInfo.EntityReps)
                && SubQueries.SequenceEqual(insertQueryInfo.SubQueries);

        }
    }
}