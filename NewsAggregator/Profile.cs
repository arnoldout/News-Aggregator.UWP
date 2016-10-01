using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace NewsAggregator
{
    [DataContract]
    class Profile
    {
        [DataMember]
        string username;
        [DataMember]
        string password;

        public Profile(string usr, string pass)
        {
            this.username = usr;
            this.password = pass;
        }
    }
}
