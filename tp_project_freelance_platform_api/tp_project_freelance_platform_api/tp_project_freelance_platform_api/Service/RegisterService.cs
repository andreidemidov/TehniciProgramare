using AutoMapper;
using AutoMapper.Configuration;
using CryptoHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Repository;
using tp_project_freelance_platform_api.Repository.Interfaces;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;
using TP_PROJECT_FreeLancePlatform_Api.Interface;
using TP_PROJECT_FreeLancePlatform_Api.Model;
using TP_PROJECT_FreeLancePlatform_Api.ModelVm;

namespace TP_PROJECT_FreeLancePlatform_Api.Service
{
    public class RegisterService: IRegister
    {
        private readonly FreeLancePlatformContext _context;
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public RegisterService(FreeLancePlatformContext context, IMapper mapper, UserRepository userRepository)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public UserVm CreateUser(UserVm userVm)
        {
            UserModel user = _mapper.Map<UserModel>(userVm);

            if (string.IsNullOrWhiteSpace(user.Password))
                throw new AppException("Password is required");

            if (_context.UserModels.Any(x => x.EmailAddress == user.EmailAddress))
                throw new AppException("Username " + user.EmailAddress + " is already taken");

            var paswordHash = HashPassword(user.Password);
            user.Password = paswordHash;

            _userRepository.CreateUser(user);

            var userConfirmation = _context.UserModels.SingleOrDefault(x => x.EmailAddress == user.EmailAddress);
            var userReturned = new UserVm();
            if (userConfirmation != null)
            {
               return userReturned = _mapper.Map<UserVm>(userConfirmation);
            }

            return userReturned;
        }

        public string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }
    }
}
