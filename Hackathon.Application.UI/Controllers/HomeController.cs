using Hackathon.Application.BusinessRules.Common.Utility;
using Hackathon.Application.BusinessRules.Services.Implementation;
using Hackathon.Application.BusinessRules.Services.Interface;
using Hackathon.Application.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hackathon.Application.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMatterService _MatterService;
		private readonly IDocumentService _DocumentService;

		public HomeController(ILogger<HomeController> logger, IMatterService MatterService, IDocumentService DocumentServices)
        {
            _logger = logger;
            _MatterService = MatterService;
            _DocumentService = DocumentServices;

		}

        [HttpPost]
        public IActionResult Initialize(int MatterId)
        {
            var matter = _MatterService.Initialize(MatterId);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var matterDetails = new MatterDetails();
            var Matterlist = _MatterService.GetAllMatter();

            matterDetails.ActiveMatterList = Matterlist.Where(f => f.Status == SD.StatusActive).ToList();
            matterDetails.RejectedMatterList = Matterlist.Where(f => f.Status == SD.StatusRejected).ToList();
            matterDetails.CompletedMatterList = Matterlist.Where(f => f.Status == SD.StatusCompleted).ToList();

            return View(matterDetails);
        }
		public IActionResult MatterDetail(int MatterId)
		{
			var matterDetails = new MatterDetails();
			matterDetails.Matter = _MatterService.GetMatterById(MatterId);
            matterDetails.DocumentList = _DocumentService.GetAllDocument().Where(f => f.MatterId == MatterId).ToList();
			return View(matterDetails);
		}

		public IActionResult Dashboard()
		{
			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
