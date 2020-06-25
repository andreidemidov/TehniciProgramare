using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using tp_project_freelance_platform_api.Repository;
using tp_project_freelance_platform_api.ViewModels;

namespace TPApiTests
{
    class UserDetailRepositoryTest
    {
        [Test]
        public void CreateUserTest()
        {
            //Arrange
            var userRepo = new UserDetailRepository();
            var user = new UserDetailVm
            {
               City = "Orastie",
               County = "Hunedoara",
               PersonalDescription = "Short description working!!!",
               Phone = "0754566257",
               Position = "Junior web developer",
               SelectedFile = "Teorie.pdf",
               SelectedFileName = "D:/files/Teorie_20200616231210.pdf",
               UserModelId = 6
            };

            //Act
            var userDetail = userRepo.GetById(4);

            //Assert
            Assert.AreEqual(userDetail, user);
        }
    }
}
