using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace improweb2022_02.Security
{
    public class SecurityManager
    {
        #region Multiple login
        /*public async void SignIn(HttpContext httpContext, Users account, string schema) 
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(account), schema);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(schema, claimsPrincipal);
        }
        public async void SignOut(HttpContext httpContext, string schema)
        {
            await httpContext.SignOutAsync(schema);
        }
        private IEnumerable<Claim> getUserClaims(Users account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.EMailAddress));
            foreach (var roleAccount in account.RoleAccounts)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleAccount.Role.Name));
            }
            return claims;
        }*/
        #endregion
        #region Admin Security Manager
        public async void SignIn(HttpContext httpContext, Users account) 
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(account), 
                CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                claimsPrincipal);
        }

        private IEnumerable<Claim> getUserClaims(Users account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.EMailAddress));
            account.RoleAccounts.ToList().ForEach(ac => {
                claims.Add(new Claim(ClaimTypes.Role, ac.Role.Name));
            });
            return claims;
        }
        #endregion
        #region Customer Security Manager
        public async void LogIn(HttpContext httpContext, Customer account/*, string schema*/) 
        {
            /*ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(account), schema);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(schema, claimsPrincipal);*/
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getCustomerClaims(account), 
                CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                claimsPrincipal);
        }
        private IEnumerable<Claim> getCustomerClaims(Customer account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Email));
            //single login
            /*account.RoleAccounts.ToList().ForEach(ac => {
                claims.Add(new Claim(ClaimTypes.Role, ac.Role.Name));
            });*/          
            //multi login
            /*foreach (var roleAccount in account.RoleAccounts)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleAccount.Role.Name));
            }*/
            return claims;
        }
        #endregion     
        public async void SignOut(HttpContext httpContext/*, string schema*/)
        {
            await httpContext.SignOutAsync(/*schema*/);
        }

    }
}