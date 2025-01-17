using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Models;

namespace MoneyManager.Services
{
    // Manages the authentication state of the users in the application.
    internal class AuthenticationStateService
    {
        private User authenticatedUser;// Holds the currently authenticated user

        public User GetAuthenticatedUser()// Retrieves information of the currently authenticated user.
        {
            return authenticatedUser;// Returns the user object if one is authenticated.
        }

        // Sets the authenticated user to store the user's details..
        public void SetAuthenticatedUser(User user)
        {
            authenticatedUser = user;
        }

        public bool IsAuthenticated() 
        {
            if (authenticatedUser != null)// Checks if a user is currently logged in (authenticated).
            {
                return true;// If 'authenticatedUser' is not 'null', it means a user is logged in, so it returns 'true'.
            }
            return false; // If 'authenticatedUser' is 'null', it means a user is not logged in, so it returns 'false'.
        }
    }
}
