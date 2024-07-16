using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/add-student";

        public IWebElement NameElement => driver.FindElement(By.Id("name"));
        public IWebElement EmailElement => driver.FindElement(By.Id("email"));
        public IWebElement AddButtonElement => driver.FindElement(By.CssSelector("button[type='submit']"));  
        public IWebElement ErrorMessageElement => driver.FindElement(By.XPath("//body//div[text()='Cannot add student. Name and email fields are required!']"));

        public string GetErrorMessage()
        {
            return ErrorMessageElement.Text;
        }

        public void AddStudent(string name, string email)
        {
            this.NameElement.SendKeys(name);
            this.EmailElement.SendKeys(email);
            this.AddButtonElement.Click();
        }
    }
}
