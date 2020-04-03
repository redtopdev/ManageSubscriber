﻿using Cassandra;
using Engaze.Core.Persistance.Cassandra.Abstract;
using System;
using System.Collections.Concurrent;

namespace Engaze.Core.Persistance.Cassandra
{
    public class CassandraSessionCacheManager: ISessionManager
    {
        private Cluster cassandraCluster;
        private ConcurrentDictionary<string, Lazy<ISession>> sessions = new ConcurrentDictionary<string, Lazy<ISession>>();

        public  CassandraSessionCacheManager(Cluster cassandraCluster)
        {
            this.cassandraCluster = cassandraCluster;
        }

        public ISession GetSession(string keyspaceName)
        {
            if (!sessions.ContainsKey(keyspaceName))
                sessions.GetOrAdd(keyspaceName, key => new Lazy<ISession>(() =>
            cassandraCluster.Connect(key)));

            var result = sessions[keyspaceName];

            return result.Value;
        }
    }
}
