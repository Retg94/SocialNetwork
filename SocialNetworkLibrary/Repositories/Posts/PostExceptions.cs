using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Repositories.Posts
{
    class PostExceptions
    {
        public class PostException : Exception
        {
            public PostException(string message) : base(message)
            {
            }
        }

        public class ContentAmountOfCharacters : PostException
        {
            public ContentAmountOfCharacters(string message = "The content must contain between 5 and 150 characters.") : base(message)
            {
            }
        }
        public class NotCorrectUser : PostException
        {
            public NotCorrectUser(string message = "This user dont have acess to what you are trying to do.") : base(message)
            {
            }
        }
        public class PostNotFound : PostException
        {
            public PostNotFound(string message = "Could not find the post") : base(message)
            {
            }
        }


    }
}
