using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.PagesTests
{
    public class AddStudentPageTests : BaseTest
    {
        [Test]
        public void Test_TestAddStudentPage_Content()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            Assert.Multiple(() =>
            {
                Assert.That(addStudentPage.GetPageTitle, Is.EqualTo("Add Student"));
                Assert.That(addStudentPage.GetPageHeading, Is.EqualTo("Register New Student"));
            });

            Assert.That(addStudentPage.NameElement.Text, Is.Empty);
            Assert.That(addStudentPage.EmailElement.Text, Is.Empty);
            Assert.That(addStudentPage.AddButtonElement.Text, Is.EqualTo("Add"));
        }

        [Test]
        public void Test_TestAddStudentPage_Links()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            addStudentPage.HomeLink.Click();
            Assert.That(new HomePage(driver).IsPageOpen(), Is.True);

            addStudentPage.OpenPage();
            addStudentPage.ViewStudentsLink.Click();
            Assert.That(new ViewStudentPage(driver).IsPageOpen(), Is.True);

            addStudentPage.OpenPage();
            addStudentPage.AddStudentLink.Click();
            Assert.That(new AddStudentPage(driver).IsPageOpen(), Is.True);
        }

        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            string name = GenerateRandomName();
            string email = GenerateRandomEmail(name);

            addStudentPage.AddStudent(name, email);

            ViewStudentPage viewStudentPage = new ViewStudentPage(driver);
            Assert.That(viewStudentPage.IsPageOpen(), Is.True);

            var students = viewStudentPage.GetRegisteredStudents();

            string newStudentFullString = name + " (" + email + ")";

            Assert.IsTrue(students.Contains(newStudentFullString));
        }

        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            AddStudentPage addStudentPage = new AddStudentPage(driver);
            addStudentPage.OpenPage();

            addStudentPage.AddStudent("", "petar@gmail.com");

            Assert.That(addStudentPage.IsPageOpen(), Is.True);
            Assert.That(addStudentPage.GetErrorMessage(), Is.EqualTo("Cannot add student. Name and email fields are required!"));
        }

        private string GenerateRandomName()
        {
            var random = new Random();
            string[] names = { "Ivan", "Petar", "Georgi", "Alexander" };

            return names[random.Next(names.Length)] + random.Next(999, 9999).ToString();
        }

        private string GenerateRandomEmail(string name)
        {
            var random = new Random();

            return name.ToLower() + random.Next(999, 9999).ToString() + "@gmail.com";
        }
    }
}
