using OctopusCore.DbHandlers;

namespace OctopusCore.Configuration
{
    public interface IDbHandlersResolver
    {
        IDbHandler ResolveDbHandler(string databaseKey);
    }
}