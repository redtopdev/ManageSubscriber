using Register.DataContract;
using System.Collections.Generic;

namespace Register.Service
{
    public interface IContactsManager
    {
        /// <summary>
        /// Gets registered contacts
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IEnumerable<RegisteredContact> GetRegisteredContacts(ContactsRequest request);
    }
}
