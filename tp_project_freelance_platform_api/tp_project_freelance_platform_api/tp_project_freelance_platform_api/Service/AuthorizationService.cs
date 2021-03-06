﻿using CryptoHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;
using TP_PROJECT_FreeLancePlatform_Api.Interface;
using TP_PROJECT_FreeLancePlatform_Api.Model;
using TP_PROJECT_FreeLancePlatform_Api.ModelVm;

namespace TP_PROJECT_FreeLancePlatform_Api.Service
{
    public class AuthorizationService: IAuthService
    {
        private readonly IConfiguration _config;
        private readonly FreeLancePlatformContext _context;

        public AuthorizationService(IConfiguration config, FreeLancePlatformContext context)
        {
            _config = config;
            _context = context;
        }
        public UserModel AuthenticateUser(UserModel userModel)
        {
            if(string.IsNullOrEmpty(userModel.EmailAddress) || string.IsNullOrEmpty(userModel.Password)) return null;
            var user = _context.UserModels.SingleOrDefault(x => x.EmailAddress == userModel.EmailAddress);

            if (user == null) return null;

            var passwordValid = VerifyPassword(user.Password, userModel.Password);

            if (!passwordValid)
            {
                return null;
            }

            return user;
        }

        public UserModel AuthorizeUser(int id)
        {
            return _context.UserModels.SingleOrDefault(x => x.Id == id);
        }

        public string GenerateJSONWebToken(UserModel userInformation)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userInformation.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Sub, userInformation.Role),
                new Claim(JwtRegisteredClaimNames.FamilyName, userInformation.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, userInformation.LastName),
                new Claim(JwtRegisteredClaimNames.NameId, userInformation.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt: Issuer"],
                audience: _config["Jwt: Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }

        public IList<Claim> GetClaim(ClaimsIdentity identity)
        {
            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            return claim;
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, password);
        }
    }
}
