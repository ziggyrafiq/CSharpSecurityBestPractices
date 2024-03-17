namespace AuthorizationWithRoleBasedAccessControl
{
    public static class CheckAccess
    {
       public static bool IsAuthorized(string username, string userRole, string resource)
        {
            // In a real application, you would likely have a more robust authorization mechanism
            // Here, we simply check if the user is an "admin" to grant access to the "AdminPanel" resource
            if (userRole.Equals("admin") && resource.Equals("AdminPanel"))
            {
                return true;
            }

            return false;
        }
    }
}
