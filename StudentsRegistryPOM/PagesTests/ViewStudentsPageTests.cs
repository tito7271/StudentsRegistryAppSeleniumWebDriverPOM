using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.PagesTests
{
    public class ViewStudentsPageTests : BaseTest
    {

        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            ViewStudentPage viewStudentPage = new ViewStudentPage(driver);
            viewStudentPage.OpenPage();

            Assert.Multiple(() =>
            {
                Assert.That(viewStudentPage.GetPageTitle, Is.EqualTo("Students"));
                Assert.That(viewStudentPage.GetPageHeading, Is.EqualTo("Registered Students"));
            });

            var students = viewStudentPage.GetRegisteredStudents();

            foreach (var student in students)
            {
                Assert.That(student.Contains("("), Is.True);
                Assert.That(student.LastIndexOf(")") == student.Length - 1, Is.True);
            }
        }

        [Test]
        public void Test_ViewStudentsPage_Links()
        {
            ViewStudentPage viewStudentPage = new ViewStudentPage(driver);
            viewStudentPage.OpenPage();

            viewStudentPage.HomeLink.Click();
            Assert.That(new HomePage(driver).IsPageOpen(), Is.True);

            viewStudentPage.OpenPage();
            viewStudentPage.ViewStudentsLink.Click();
            Assert.That(new ViewStudentPage(driver).IsPageOpen(), Is.True);

            viewStudentPage.OpenPage();
            viewStudentPage.AddStudentLink.Click();
            Assert.That(new AddStudentPage(driver).IsPageOpen(), Is.True);
        }
    }
}
