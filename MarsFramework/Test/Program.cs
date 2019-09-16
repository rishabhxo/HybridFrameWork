using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    [TestFixture(BrowserType.Firefox)]
    [TestFixture(BrowserType.Chrome)]
    public class Program : Base
    {
        public Program(BrowserType browser) : base(browser)
        {
        }
        [Test]
        public void UserAccount()
        {
            //create objects to call Profile Page methods
            UserAccount obj = new UserAccount(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("User Account Test");
            obj.AccountSetting();
            Base.test = Base.extent.StartTest("User Account Change Password Test");
            obj.ChangePassword();
            Base.test = Base.extent.StartTest("User Account Deactivate Test");
            obj.Deactivate();

        }

        [Test]
        public void Profile()
        {
            //create objects to call Profile Page methods
            Profile obj = new Profile(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("Profile Test");
            obj.EditProfile();
            obj.EditAvailability();
            obj.EditHours();
            obj.EditEarnTarget();
            obj.EditDescription();
        }
        [Test]
        public void SearchSkills()
        {
            //create objects to call methods
            SearchSkill obj = new SearchSkill(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("Search By Category and SubCategory");
            obj.SearchByCategoryandSubCategory();
            Base.test = Base.extent.StartTest("Search by Filter");
            obj.SearchByFilter();

        }
        [Test]
        public void Chat()
        {
            //create objects to call methods
            Chat obj = new Chat(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("Chat Test");
            obj.Chatting();
        }
        [Test]
        public void Notification()
        {
            //create objects to call methiods
            Notification obj = new Notification(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("Notification Test");
            obj.Notify();
        }
        [Test]
        public void Language()
        {
            //create objects to call Profile Page methods
            Profile obj = new Profile(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("Language Test");
            obj.AddLanguage();
        }
        [Test]
        public void Skill()
        {
            //create objects to call Profile Page methods
            Profile obj = new Profile(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("Skill Test");
            obj.Skills();

        }
        [Test]
        public void Education()
        {
            //create objects to call Profile Page methods
            Profile obj = new Profile(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("Education Test");
            obj.Education();

        }
        [Test]
        public void Certification()
        {
            //create objects to call Profile Page methods
            Profile obj = new Profile(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("Certification Test");
            obj.Certification();

        }
        [Test]
        public void ShareSkill()
        {
            // Create Share Skills object to call methods      
            ShareSkill obj = new ShareSkill(_driver);
            //extent Reports
            Base.test = Base.extent.StartTest("Share Skill Add Test");
            //call methods
            obj.EnterShareSkill();
            
        }

        [Test]
        public void ManageList()
        {
            // Create ManageListing Object to call menthods
            ManageListings obj = new ManageListings(_driver);
            //call method
            obj.DeleteService("Testing");
        }




    }
}