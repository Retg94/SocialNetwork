using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkLibrary.Repositories
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {
        }
    }

    public class NonUniqueUserName : UserException
    {
        public NonUniqueUserName(string message = "The UserName was not unique") : base(message)
        {
        }
    }

    public class NonUniqueId : UserException
    {
        public NonUniqueId(string message = "The Id was not unique") : base(message)
        {
        }
    }
    public class InvalidCharacters : UserException
    {
        public InvalidCharacters(string message = "Invalid characters. Can only accept letters and numbers") : base(message)
        {
        }
    }
    public class UserNotFound : UserException
    {
        public UserNotFound(string message = "User not found") : base(message)
        {
        }
    }
}

