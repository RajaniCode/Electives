using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using SimpleExamples.Models;
using MVCControlsToolkit.Linq;

namespace SimpleExamples.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        //ESimple Controls Page
        [HttpGet]
        public ActionResult Index()
        {
            var model = new SimpleControlsViewModel();
            

            

            model.PersonalData = new PersonalInfosExt();
            model.PersonalData.MinAge = 18f;


            model.PersonalData.MaxAge = 40f;
            model.PersonalData.MinAgeDelay = 0f;

            model.Start = new DateTime(2010, 3, 2, 16, 20, 22);
            model.Stop = new DateTime(2010, 3, 2, 20, 20, 22);
            model.Delay = new TimeSpan(0, -4, 0, 0, 0);

            model.Selection = "choice2"; //View list "tab" selection

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(SimpleControlsViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();

            }
            //delay must be set again, since it was not stored in the page
            model.Delay = new TimeSpan(0, -4, 0, 0, 0);
            return View(model);
        }
        [System.Web.Mvc.OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult ServerTime()
        {
            DateTime now = DateTime.Now;
            return PartialView("ServerTime", now);
        }
        public ActionResult AvailableRoles()
        {
            var res = Json(MVCControlsToolkit.Controls.ChoiceListHelper.CreateGrouped(SimpleControlsViewModel.AllRoles,
                                m => m.Code,
                                m => m.Name,
                                m => m.GroupCode,
                                m => m.GroupName).PrepareForJson(), JsonRequestBehavior.AllowGet);
            return res;
        }
        //End Simple Controls Page
        public ActionResult ItemsControlsDescription()
        { 
            return View();
        }
        //Sortable list Example
        [HttpGet]
        public ActionResult SortableListExample()
        {
            var model = new SortableListExampleViewModel
            {
                Keywords = new List<string> { "francesco", "Abbruzzese", "Programmer" },
                Keywords1 = new List<KeywordItem> { 
                    new KeywordItem{Keyword="francesco", Title="My Program 1"},
                    new KeywordItemExt{Keyword="Giovanni", Title="My Program 2"},
                    new KeywordItem{Keyword="Fausto", Title="My Program 3"}
                }
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult SortableListExample(SortableListExampleViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                if (model.KeywordsOrdering != null && model.KeywordsOrdering.Count > 0)
                {
                    model.Keywords1 = model.Keywords1.ApplyOrder(model.KeywordsOrdering).ToList();
                }

            }
            return View(model);
        }
        //End Sortable list Example

        //TreeView Example
        [HttpGet]
        public ActionResult TreeViewExample()
        {
            var model = new TreeViewExampleViewModel();
            model.EmailFolders = new List<EmailElement>();
            EmailElement friends = new EmailFolder()
            {
                Name = "Friends",
                Children =
                    new List<EmailElement>{
                            new EmailDocument{
                                Name="EMail_Friend_1"
                            },
                            new EmailDocument{
                                Name="EMail_Friend_2"
                            },
                            new EmailDocument{
                                Name="EMail_Friend_3"
                            }
                        }

            };
            model.EmailFolders.Add(friends);

            EmailElement relatives = new EmailFolder()
            {
                Name = "Relatives",
                Children =
                    new List<EmailElement>{
                            new EmailDocument{
                                Name="EMail_Relatives_1"
                            },
                            new EmailDocument{
                                Name="EMail_Relatives_2"
                            },
                            new EmailDocument{
                                Name="EMail_Relatives_3"
                            }
                        }

            };
            model.EmailFolders.Add(relatives);
            EmailElement work = new EmailFolder()
            {
                Name = "Work",
                Children =
                    new List<EmailElement>{
                            new EmailDocument{
                                Name="EMail_Work_1"
                            },
                            new EmailDocument{
                                Name="EMail_Work2"
                            },
                            new EmailDocument{
                                Name="EMail_Work_3"
                            }
                        }

            };
            model.EmailFolders.Add(work);
            model.EmailFolders = new List<EmailElement>
            {
                new EmailFolder{
                    Name = "All Folders",
                    Children = model.EmailFolders
                }
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult TreeViewExample(TreeViewExampleViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();

            }
            return View(model);
        }
        //TreeView Example End
        public ActionResult DataGridExample()
        {

            return View();
        }

        // Client Blocks
        [HttpGet]
        public ActionResult ClientBlocksExample()
        {
            var model = new ClientBlocksViewModel();
            model.ClientKeywords = new List<string>();
            model.ClientKeywords.Add("To Start");
            return View(model);
        }

        [HttpPost]
        public ActionResult ClientBlocksExample(ClientBlocksViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();

            }
            return View(model);
        }
        //End Client Blocks

        public ActionResult About()
        {
            return View();
        }
    }
}
