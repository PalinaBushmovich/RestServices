using RESTservices.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTservices.RESTdto
{
    public class UserPostDTO
    {
        public string id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string company { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string zipcode { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }

        public UserPostDTO()
        {
            username = Randomizer.RandomString(10);
            id = "10003";
            email = Randomizer.RandomString(10);
            city = Randomizer.RandomString(10);
            phone = "1-770-736-8031 x56442";
            website = "hildegard.org";
            company = Randomizer.RandomString(10);
            street = Randomizer.RandomString(10);
            suite = Randomizer.RandomString(10);
            zipcode = Randomizer.RandomString(10);
            lat = Randomizer.RandomString(10);
            lng = Randomizer.RandomString(10);
            name = Randomizer.RandomString(10);
            catchPhrase = Randomizer.RandomString(10);
            bs = Randomizer.RandomString(10);
        }
    }
}
