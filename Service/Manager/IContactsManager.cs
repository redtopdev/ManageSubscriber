using Subscriber.DataContract;
using System.Collections.Generic;

namespace Subscriber.Service
{
    public interface IContactsManager
    {
        /// <summary>
        /// Gets registered contacts
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IEnumerable<RegisteredContact> GetRegisteredContacts(Contacts request);
    }
}
