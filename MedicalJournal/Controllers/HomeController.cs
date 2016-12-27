namespace MedicalJournal.Controllers
{
    using MedicalJournal.Core.Data;
    using MedicalJournal.Models;
    using MedicalJournal.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class HomeController : Controller
    {
        private IMedicJournallService medicalJournalService;
        private IJournalTypeService journalTypeService;
        private IJournalSubscriberService subscriber;
        public HomeController() { }
        public HomeController(IMedicJournallService MedicalJournalService, IJournalTypeService JournalTypeService,IJournalSubscriberService Subscribers)
        {
            medicalJournalService = MedicalJournalService;
            journalTypeService = JournalTypeService;
            subscriber = Subscribers;
        }
        public ActionResult Index()
        {
            IEnumerable<MedicalJournalModel> journels = medicalJournalService.GetJournals().Select(u => new MedicalJournalModel
            {
                Title = u.Title,
                Language = u.Language,
                ISSN = u.ISSN,
                EISSN = u.EISSN,
                ISIImpactFactor = u.ISIImpactFactor,
                Writer = u.Writer,
                JournalType = u.JournalType,
                PublishDate = u.PublishDate,
                ID = u.ID,
                FrontImage = u.FrontImage,
                PdfPath = u.PdfPath,
                Description = u.Description,
                Details = u.Details,                
            });
            return View(journels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult Search(string Query)
        {
            if (!string.IsNullOrEmpty(Query))
            {
                IEnumerable<MedicalJournalModel> journels = medicalJournalService.GetJournals()
                    .Where(t => t.Title.Contains(Query)
                        || t.Description.Contains(Query)
                        || t.ISSN.Contains(Query)
                        || t.Writer.Contains(Query)
                        || t.EISSN.Contains(Query))
                    .Select(u => new MedicalJournalModel
                {
                    Title = u.Title,
                    Language = u.Language,
                    ISSN = u.ISSN,
                    EISSN = u.EISSN,
                    ISIImpactFactor = u.ISIImpactFactor,
                    Writer = u.Writer,
                    JournalType = u.JournalType,
                    PublishDate = u.PublishDate,
                    ID = u.ID,
                    FrontImage = u.FrontImage,
                    PdfPath = u.PdfPath,
                    Description = u.Description,
                    Details = u.Details,
                });
                return PartialView("_SearchResult", journels);
            }
            else
            {
                return PartialView("_SearchResult", medicalJournalService.GetJournals().Select(u => new MedicalJournalModel
                {
                    Title = u.Title,
                    Language = u.Language,
                    ISSN = u.ISSN,
                    EISSN = u.EISSN,
                    ISIImpactFactor = u.ISIImpactFactor,
                    Writer = u.Writer,
                    JournalType = u.JournalType,
                    PublishDate = u.PublishDate,
                    ID = u.ID,
                    FrontImage = u.FrontImage,
                    PdfPath = u.PdfPath,
                    Description = u.Description,
                    Details = u.Details,
                }));
            }
        }
        public JsonResult Subscribe(string Email, string JournalID)
        {
            Int64 JID = 0;
            if (!string.IsNullOrEmpty(Email)
                && !string.IsNullOrEmpty(JournalID)
                && Int64.TryParse(JournalID, out JID))
            {
                JournalSubscriber sub = new JournalSubscriber();
                sub.MedicJournalID = JID;
                sub.Email = Email;
                subscriber.InsertType(sub);
            }
            return Json(new { reponse = true });
        }
    }
}