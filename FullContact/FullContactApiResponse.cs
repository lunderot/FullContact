using System;
using System.Collections.Generic;
using System.Text;

namespace FullContactApi
{
    public class Website
    {
        public string url { get; set; }
    }

    public class ContactInfo
    {
        public List<Website> websites { get; set; }
        public string familyName { get; set; }
        public string fullName { get; set; }
        public string givenName { get; set; }
    }

    public class SocialProfile
    {
        public string type { get; set; }
        public string typeId { get; set; }
        public string typeName { get; set; }
        public string url { get; set; }
        public string bio { get; set; }
        public string username { get; set; }
        public int followers { get; set; }
        public int following { get; set; }
        public string id { get; set; }
    }

    public class FullContactPerson
    {
        public double likelihood { get; set; }
        public ContactInfo contactInfo { get; set; }
        public List<SocialProfile> socialProfiles { get; set; }
    }
}
