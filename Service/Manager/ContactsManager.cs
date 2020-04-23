using PhoneNumbers;
using Register.DataContract;
using Register.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Register.Service
{
    public class ContactsManager : IContactsManager
    {
        private IRepository repo;
        public ContactsManager(IRepository repo)
        {
            this.repo = repo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<RegisteredContact> GetRegisteredContacts(ContactsRequest request)
        {
            //this will be probalematic when the number of users grow
            List<PhoneContact> registeredList = repo.GetRegisteredUsers();
            List<PhoneContact> phoneContactList = new List<PhoneContact>();

            request.ContactList.ForEach(phoneNumber => phoneContactList.Add(ParseNumber(phoneNumber, request.RequestorCountryCode)));          
           
            return  from pc in phoneContactList
                       join rc in registeredList
                       on new { pc.MobileNumber, pc.CountryCode }  equals new { rc.MobileNumber, rc.CountryCode }
                       select new RegisteredContact() { UserId = rc.UserId, MobileNumberStoredInRequestorPhone= pc.MobileNumberStoredInRequestorPhone };          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private PhoneContact ParseNumber(string number, string requestorCountryCode)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            int countryCode = phoneNumberUtil.MaybeExtractCountryCode(number, null, new StringBuilder(number), true, new PhoneNumber.Builder());
           
            if (countryCode == 0)
            {
                countryCode = int.Parse(requestorCountryCode.Split("+", StringSplitOptions.None)[1]);
            }
            string region = phoneNumberUtil.GetRegionCodeForCountryCode(countryCode);
            var phoneNumber = phoneNumberUtil.Parse(number, region);
            return new PhoneContact()
            {
                CountryCode = "+" + phoneNumber.CountryCode.ToString(),
                MobileNumber = phoneNumber.NationalNumber,
                MobileNumberStoredInRequestorPhone = number
            };           
        }
    }
}
