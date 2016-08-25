using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PlanGrid.Api.Tests
{
    [TestFixture]
    public class ProjectsTests
    {
        [Test]
        public async Task GetProjectsTotalCount()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Project> page = await client.GetProjects();
            Assert.AreEqual(3, page.TotalCount);
        }

        [Test]
        public async Task GetProjectsLimit()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Project> page = await client.GetProjects(limit: 1);
            Assert.AreEqual(1, page.Data.Length);
        }

        [Test]
        public async Task GetProjectsOffset()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Page<Project> page = await client.GetProjects();
            string secondProjectUid = page.Data[1].Uid;

            page = await client.GetProjects(1);
            Assert.AreEqual(secondProjectUid, page.Data.First().Uid);
        }

        [Test]
        public async Task GetProject()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Project project = await client.GetProject(TestData.Project1Uid);
            Assert.AreEqual("Project 1", project.Name);
        }

        [Test]
        public async Task UpdateProject()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Project project = await client.GetProject(TestData.Project2Uid);
            string oldName = project.Name;
            await client.UpdateProject(project.Uid, new ProjectUpdate
            {
                Name = oldName + "1"
            });
            project = await client.GetProject(TestData.Project2Uid);
            Assert.AreEqual(oldName + "1", project.Name);
            await client.UpdateProject(project.Uid, new ProjectUpdate
            {
                Name = oldName
            });
            project = await client.GetProject(TestData.Project2Uid);
            Assert.AreEqual(oldName, project.Name);
        }

/*
        [Test]
        public async Task CreateProject()
        {
            IPlanGridApi client = PlanGridClient.Create();
            Project project = await client.CreateProject(new PutProject { Name = "#Test Case Project" });
            Assert.AreEqual("#Test Case Project", project.Name);
            Assert.IsTrue(!string.IsNullOrEmpty(project.Uid));
        }
*/
    }
}