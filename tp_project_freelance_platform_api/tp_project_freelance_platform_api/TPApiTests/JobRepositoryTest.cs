using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using tp_project_freelance_platform_api.Repository;
using Xunit;

namespace TPApiTests
{
    
    public class JobRepositoryTest
    {
        [Test]
        public void TestGetAllJobsMethod()
        {
            // Arrange
            var jobrepo = new JobRepository();

            //Act
            var jobs = jobrepo.GetAll(7);

            //Asert
            NUnit.Framework.Assert.AreEqual(2, jobs.Count);

        }
    }
}
