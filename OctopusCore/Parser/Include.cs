using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using OctopusCore.Common;

namespace OctopusCore.Parser
{
    public class Include
    {
        public string Name { get; set; }
        public List<string> Fields { get; set; }
        public List<Include> Includes { get; set; }

        public Include()
        {
            Includes = new List<Include>();
        }

        public Include(OctopusQLParser.IncludeContext includeContext)
        {
            Name = includeContext.field().GetText();
            Fields = new List<string>();
            Includes = new List<Include>();
            if (includeContext.all() != null)
            {
                Fields.Add(StringConstants.All);
            }
            else if (includeContext.fields() != null)
            {
                Fields.AddRange(includeContext.fields()._fieldList.Select(fieldContext => fieldContext.GetText().ToLower()));
            }
            Includes.AddRange(includeContext.include().Select(x => new Include(x)));
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            return obj is Include include 
                   && Name.Equals(include.Name)
                   && Fields.SequenceEqual(include.Fields)
                   && Includes.SequenceEqual(include.Includes);
            
        }

        protected bool Equals(Include other)
        {
            return Name == other.Name && Equals(Fields, other.Fields) && Equals(Includes, other.Includes);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Fields != null ? Fields.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Includes != null ? Includes.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}