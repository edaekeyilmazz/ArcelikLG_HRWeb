using ArcelikLgHRWeb.Controllers;
using DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.CalismaControllerTests
{
    [TestClass]
    public class CalismaTest
    {
        public static List<WorkInformation> workInfo;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            workInfo = new List<WorkInformation>(){new WorkInformation(){ UserInfoId=3,WorkID=1,IsStillWorking=false,FireDateOfLastJob =new DateTime(2012,10,30)}
            };
        }
        [TestMethod]
        [Owner("Sena Sarıyılmaz")]
        public void WorkInformation_InsertControl()
        {
            MockObjectWorkRep mockWork = new MockObjectWorkRep(workInfo);
            int newCount = workInfo.Count + 1;
            WorkInformation work = new WorkInformation();
            work.FireDateOfLastJob = new DateTime(2012, 10, 30);
            work.IsStillWorking = false;
            work.UserInfoId = 3;
            work.WorkID = 1;
            work.WorkExperience.Add(new WorkExperience { BeginDateToWork = "2011", EndDateToWork = "2014", Position = "Operatör", FireReasonFromLastJob = string.Empty, WorkPlaceName = "trinoks" });
            mockWork.Insert(work);
            Assert.AreEqual(newCount, workInfo.Count);
            Assert.IsTrue(work.IsValid);
        }
        [TestMethod]
        [Owner("Sena Sarıyılmaz")]
        public void WorkInformation_UpdateControl()
        {
            MockObjectWorkRep mockWork = new MockObjectWorkRep(workInfo);
            var works = mockWork.FirstOrDefault(x => x.UserInfoId == 3);
            WorkInformation work = new WorkInformation();
            work.IsStillWorking = true;
            work.FireDateOfLastJob = new DateTime(2014, 09, 20);               
        }
    }
}
