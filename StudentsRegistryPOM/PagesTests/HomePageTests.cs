using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.PagesTests
{
    public class HomePageTests : BaseTest
    {
        [Test]
        public void Test_HomePage_Content()
        {
            HomePage homePage = new HomePage(driver);
            homePage.OpenPage();

            Assert.Multiple(() =>
            {
                Assert.That(homePage.GetPageTitle, Is.EqualTo("MVC Example"));
                Assert.That(homePage.GetPageHeading, Is.EqualTo("Students Registry"));
            });

            Assert.IsTrue(homePage.StudentCount() > 0);
        }

        [Test]
        public void Test_HomePage_Links()
        {
            HomePage homePage = new HomePage(driver);
            homePage.OpenPage();

            homePage.HomeLink.Click();
            Assert.That(homePage.IsPageOpen(), Is.True);

            homePage.OpenPage();
            homePage.ViewStudentsLink.Click();
            Assert.That(new ViewStudentPage(driver).IsPageOpen(), Is.True);

            homePage.OpenPage();
            homePage.AddStudentLink.Click();
            Assert.That(new AddStudentPage(driver).IsPageOpen(), Is.True);
        }
    }
}
