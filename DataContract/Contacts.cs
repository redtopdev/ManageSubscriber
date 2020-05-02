using System.Collections.Generic;

namespace Subscriber.DataContract
{

    public class Contacts
    {
        public List<string> ContactList { get; set; }      
        public string RequestorCountryCode { get; set; }
    }
}
