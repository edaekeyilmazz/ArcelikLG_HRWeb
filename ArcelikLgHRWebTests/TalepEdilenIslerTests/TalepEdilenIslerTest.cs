using DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.TalepEdilenIslerTests
{
    [TestClass]
    public class TalepEdilenIslerTest
    {
        public static List<JobInformation> jobInfos;
        public TalepEdilenIslerTest()
        {
            jobInfos = new List<JobInformation>(){
                new JobInformation(){ RequestedJob1="Forklift Operatörü",RequestedJob2=string.Empty, RequestedJob3=string.Empty, JobID=3,UserInfoId=3}
            };
        }

        [TestMethod]
        [Owner("Sena Sarıyılmaz")]
        public void JobInformation_Insert()
        {
            //Arrange
            MockObjectJobRep mockjob = new MockObjectJobRep(jobInfos);
            int newCount = jobInfos.Count + 1;
            JobInformation job = new JobInformation();
            //Act
            job.RequestedJob1 = "Forklift";
            job.RequestedJob2 = string.Empty;
            job.RequestedJob3 = string.Empty;
            job.JobID = 3;
            mockjob.Insert(job);
            //Assert
            Assert.AreEqual(newCount, jobInfos.Count, "İş bilgileri kayıt edilmedi.");
            Assert.IsTrue(job.IsValid);
            Assert.IsTrue(job.JobID > 0);

        }

        [TestMethod]
        [Owner("Sena Sarıyılmaz")]
        public void JobInformation_Update()
        {
            //Arrange
            MockObjectJobRep mockjob = new MockObjectJobRep(jobInfos);
            JobInformation job = new JobInformation() { RequestedJob1 = "Operatör", RequestedJob2 = "Forklift Operatörü", RequestedJob3 = string.Empty,JobID=3};
            //Act
            mockjob.Update(job);
            var NewJobInfo = mockjob.FirstOrDefault(X => X.JobID == job.JobID);
            //Assert
            Assert.IsNotNull(job);
            Assert.IsNotNull(NewJobInfo);
            Assert.ReferenceEquals(job, NewJobInfo);
        }
    }
}
