using RESTservices.RESTdto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebProject.REST.REST_dto;

namespace RESTservices.Utilities
{
    public class RestComparator
    {
        public static bool CompareUserDTOs(UserPostDTO userPost, UserGetDTO userGet)
        {
            return
                userPost.id == userGet.id
                && userPost.username == userGet.username
                && userPost.email == userGet.email
                && userPost.phone == userGet.phone
                && userPost.website == userGet.website;   
        }
    }
}
