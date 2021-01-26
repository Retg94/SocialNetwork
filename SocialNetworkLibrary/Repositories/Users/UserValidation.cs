using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SocialNetworkLibrary.Repositories.Users
{
    public static class UserValidation
    {
        public static bool ValidateUsername(string username)
        {
            bool isOkay = true;
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
                isOkay = false;
            return isOkay;
        }
    }
}
