using System.Collections.Generic;

namespace Register.DataContract
{

    public class ContactsRequest
    {
        public List<string> ContactList { get; set; }      
        public string RequestorCountryCode { get; set; }
    }
}
