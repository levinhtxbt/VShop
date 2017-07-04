﻿using CKSource.CKFinder.Connector.Core;
using CKSource.CKFinder.Connector.Core.Acl;
using CKSource.CKFinder.Connector.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace VShop.Web.App_Start
{
    public class RoleBasedAuthenticator : IAuthenticator
    {
        private readonly string _allowedRoleMatcherTemplate;

        private readonly StringMatcher _allowedRoleMatcher;

        public RoleBasedAuthenticator(string allowedRoleMatcherTemplate)
        {
            _allowedRoleMatcherTemplate = allowedRoleMatcherTemplate;
            _allowedRoleMatcher = new StringMatcher(allowedRoleMatcherTemplate);
        }

        public Task<IUser> AuthenticateAsync(ICommandRequest commandRequest, CancellationToken cancellationToken)
        {
            var claimsPrincipal = commandRequest.Principal as ClaimsPrincipal;

            var roles = new string[] { };
            if (claimsPrincipal != null && claimsPrincipal.Claims != null)
            {
                roles = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToArray();
            }

            var user = new User(IsAuthenticated(roles), roles);
            return Task.FromResult((IUser)user);
        }

        private bool IsAuthenticated(string[] roles)
        {
            // Should always fail if matcher is empty.
            if (_allowedRoleMatcherTemplate == string.Empty)
            {
                return false;
            }

            // Use empty string when there are no roles, so asterisk pattern will match users without any role.
            var safeRoles = roles.Any() ? roles : new[] { string.Empty };

            return safeRoles.Any(role => _allowedRoleMatcher.IsMatch(role));
        }
    }
}