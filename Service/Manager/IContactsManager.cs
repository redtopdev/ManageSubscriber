using Subscriber.DataContract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Subscriber.Service
{
    public interface IContactsManager
    {
        /// <summary>
        /// Gets registered contacts
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<RegisteredContact>> GetRegisteredContacts(Contacts request);
        Task<Dictionary<Guid,string>> GetGCMClientIds(IEnumerable<Guid> userIds);
    }
}
