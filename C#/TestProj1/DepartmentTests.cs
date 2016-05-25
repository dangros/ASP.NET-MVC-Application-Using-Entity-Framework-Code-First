using ContosoUniversity.Controllers;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DepartmentTests
{ // this solution is not very testable!!!!  This is a sample test as a result
    [TestFixture]
    public class DepartmentTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void PassingTest()
        {
            Assert.IsTrue(1==1);
        }

        [Test]
        [Ignore("Dbcontext is not testable in this bad boy")]
        public  void Delete_SetsEntityState_ToDeleted()
        {
            var department = new Department();
            var mockController = new Mock<DepartmentController>();
            mockController.Setup(mock => mock.Delete(It.IsAny<Department>()));
            
            var mockDb = new Mock<SchoolContext>();

            //db.Entry(department).State = EntityState.Deleted;
            //await db.SaveChangesAsync();

            var result =  mockController.Object.Delete(department) as Task<ActionResult>;
            //var model = (IList<Department>)result.Result;
            mockDb.VerifySet(db => db.Entry(department).State = EntityState.Deleted);
            //mockDb.Verify(x => x.SaveChangesAsync)
        }
    }
}
