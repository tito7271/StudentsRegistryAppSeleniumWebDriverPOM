using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace StudentsRegistryPOM.Pages
{
    public class ViewStudentPage : BasePage
    {
        public ViewStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/students";

        public ReadOnlyCollection<IWebElement> StudentsListItems => driver.FindElements(By.XPath("//body//ul//li"));

        public string[] GetRegisteredStudents()
        {
            var elementsStudents = this.StudentsListItems.Select(student => student.Text).ToArray();
            return elementsStudents;
        }
    }
}
