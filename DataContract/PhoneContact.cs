
using System;

namespace Register.DataContract
{
    public class PhoneContact
    {
        public Guid UserId { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string MobileNumberStoredInRequestorPhone { get; set; }
        public string GCMClientId { get; set; }
    }
}
