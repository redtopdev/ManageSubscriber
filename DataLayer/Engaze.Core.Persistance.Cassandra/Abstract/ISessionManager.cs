using Cassandra;

namespace Engaze.Core.Persistance.Cassandra.Abstract
{   
    public interface ISessionManager
    {
        public ISession GetSession(string keyspaceName);
    }
}
