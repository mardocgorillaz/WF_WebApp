using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WF_WebApplication.Models;

namespace WF_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BMI model = new BMI();
            return View(model);
        }

       
        [HttpPost]
        public ActionResult FindBMI(BMI model)
        {
            var result = WorkflowInvoker.Invoke(new BMIRuleEngine.Workflow1(), new Dictionary<string, object> {
                            {
                                "BMIInput",
                                model.BMIValue
                            }
                             });
            model.Recommendation = result["Recomendetion"] as String;
            TempData["wfResult"] = model;
            return RedirectToAction("ShowResult");
        }
        [HttpGet]
        public ActionResult ShowResult()
        {
            BMI model = TempData["wfResult"] as BMI;
            return View(model);
        }
    }
}