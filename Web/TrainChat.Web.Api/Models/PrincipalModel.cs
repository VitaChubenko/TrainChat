using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace TrainChat.Web.Api.Models
{
    interface ICustomPrincipal : IPrincipal
    {
        string Login { get; set; }
        string Password { get; set; }
    }

    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public CustomPrincipal(string email)
        {
            this.Identity = new GenericIdentity(email);
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class CustomPrincipalSerializeModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    
}