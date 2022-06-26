using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Consts.Messages.Identity
{
    public static class IdentityMessages
    {
        #region Errors
        public static string EmailOrPasswordInvalid = "Email or password invalid";
        public static string ExistEmail = "An account registered with this email already exists";
        #endregion

        #region Success
        public static string UserCreated = "User created successfully.";
        #endregion

    }
}
