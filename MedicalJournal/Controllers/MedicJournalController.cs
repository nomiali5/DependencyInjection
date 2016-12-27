namespace MedicalJournal.Controllers
{
    using MedicalJournal.Core.Data;
    using MedicalJournal.Models;
    using MedicalJournal.Service;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    [Authorize(Roles = "Publisher")]
    public class MedicJournalController : Controller
    {
        private IMedicJournallService medicalJournalService;
        private IJournalTypeService journalTypeService;
        public MedicJournalController(IMedicJournallService MedicalJournalService,
            IJournalTypeService JournalTypeService)
        {
            this.medicalJournalService = MedicalJournalService;
            this.journalTypeService = JournalTypeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<MedicalJournalModel> users = medicalJournalService.GetJournals().Select(u => new MedicalJournalModel
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
                FrontImage = u.FrontImage
            });
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateEditMedicJournal(int? id)
        {
            MedicalJournalModel model = new MedicalJournalModel();
            var TypeList = journalTypeService.GetTypes();
            model.JournalTypeList = new SelectList(TypeList, "ID", "TypeName");
            if (id.HasValue && id != 0)
            {
                MedicJournal userEntity = medicalJournalService.GetJournal(id.Value);
                model.Description = userEntity.Description;
                model.Details = userEntity.Details;
                model.EISSN = userEntity.EISSN;
                model.ISIImpactFactor = userEntity.ISIImpactFactor;
                model.ISSN = userEntity.ISSN;
                model.JournalType = userEntity.JournalType;
                model.Language = userEntity.Language;
                model.PdfPath = userEntity.PdfPath;
                model.PublishDate = userEntity.PublishDate;
                model.Title = userEntity.Title;
                model.WebsiteURL = userEntity.WebsiteURL;
                model.Writer = userEntity.Writer;
                model.ISIImpactFactor = userEntity.ISIImpactFactor;
                model.JournalTypeList = new SelectList(TypeList, "ID", "TypeName", userEntity.JournalTypeID);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditMedicJournal(MedicalJournalModel model, HttpPostedFileBase[] UploadFile, HttpPostedFileBase[] UploadImage)
        {
            var TypeList = journalTypeService.GetTypes();
            var SavePath = "";
            var ImagePath = "";
            if (model.ID == 0)
            {
                foreach (var file in UploadFile)
                {
                    if (file != null)
                    {
                        string e = Path.GetExtension(file.FileName);
                        if (e == ".pdf")
                        {
                            var filename = Path.Combine(Server.MapPath("~/Documents/Journals_PDF/") + file.FileName.Replace(" ", "_"));
                            Directory.CreateDirectory(Server.MapPath("~/Documents/Journals_PDF/"));
                            if (Directory.Exists(Server.MapPath("~/Documents/Journals_PDF/")))
                            {
                                file.SaveAs(filename);
                            }
                            SavePath = "../../Documents/Journals_PDF/" + file.FileName.Replace(" ", "_");
                        }
                        else
                        {
                            ModelState.AddModelError("1", "Please upload .pdf file");
                            model.JournalTypeList = new SelectList(TypeList, "ID", "TypeName");
                            return View(model);
                        }
                    }
                }
                foreach (var file in UploadImage)
                {
                    if (file != null)
                    {
                        string e = Path.GetExtension(file.FileName);
                        if (e == ".jpg" || e == ".jpeg" || e == ".png")
                        {
                            var filename = Path.Combine(Server.MapPath("~/Documents/Covers/") + file.FileName.Replace(" ", "_"));
                            Directory.CreateDirectory(Server.MapPath("~/Documents/Covers/"));
                            if (Directory.Exists(Server.MapPath("~/Documents/Covers/")))
                            {
                                file.SaveAs(filename);
                            }
                            ImagePath = "../../Documents/Covers/" + file.FileName.Replace(" ", "_");
                        }
                        else
                        {
                            ModelState.AddModelError("1", "Please upload .jpg/.jpeg/.png type file");
                            return View(model);
                        }
                    }
                }
                MedicJournal userEntity = new MedicJournal
                {
                    Description = model.Description,
                    Details = model.Details,
                    EISSN = model.EISSN,
                    ISIImpactFactor = model.ISIImpactFactor,
                    ISSN = model.ISSN,
                    JournalType = journalTypeService.GetType(model.JournalTypeID),
                    Language = model.Language,
                    PdfPath = SavePath,
                    PublishDate = model.PublishDate,
                    Title = model.Title,
                    WebsiteURL = model.WebsiteURL,
                    Writer = model.Writer,
                    FrontImage = ImagePath
                };
                medicalJournalService.InsertJournal(userEntity);
                if (userEntity.ID > 0)
                {
                    model.JournalTypeList = new SelectList(TypeList, "ID", "TypeName");
                    return RedirectToAction("index");
                }
                model.JournalTypeList = new SelectList(TypeList, "ID", "TypeName");
            }
            else
            {
                foreach (var file in UploadImage)
                {
                    if (file != null)
                    {
                        string e = Path.GetExtension(file.FileName);
                        if (e == ".jpg" || e == ".jpeg" || e == ".png")
                        {
                            var filename = Path.Combine(Server.MapPath("~/Documents/Covers/") + file.FileName.Replace(" ", "_"));
                            Directory.CreateDirectory(Server.MapPath("~/Documents/Covers/"));
                            if (Directory.Exists(Server.MapPath("~/Documents/Covers/")))
                            {
                                file.SaveAs(filename);
                            }
                            ImagePath = "../../Documents/Covers/" + file.FileName.Replace(" ", "_");
                        }
                        else
                        {
                            ModelState.AddModelError("1", "Please upload .jpg/.jpeg/.png type file");
                            return View(model);
                        }
                    }
                }
                foreach (var file in UploadFile)
                {
                    if (file != null)
                    {
                        string e = Path.GetExtension(file.FileName);
                        if (e == ".pdf")
                        {
                            var filename = Path.Combine(Server.MapPath("~/Documents/Journals_PDF/") + file.FileName.Replace(" ", "_"));
                            Directory.CreateDirectory(Server.MapPath("~/Documents/Journals_PDF/"));
                            if (Directory.Exists(Server.MapPath("~/Documents/Journals_PDF/")))
                            {
                                file.SaveAs(filename);
                            }
                            SavePath = "../../Documents/Journals_PDF/" + file.FileName.Replace(" ", "_");
                        }
                        else
                        {
                            ModelState.AddModelError("1", "Please upload .pdf file");
                            model.JournalTypeList = new SelectList(TypeList, "ID", "TypeName");
                            return View(model);
                        }
                    }
                }
                MedicJournal userEntity = medicalJournalService.GetJournal(model.ID);
                userEntity.Description = model.Description;
                userEntity.Details = model.Details;
                userEntity.EISSN = model.EISSN;
                userEntity.ISIImpactFactor = model.ISIImpactFactor;
                userEntity.ISSN = model.ISSN;
                userEntity.JournalType = model.JournalType;
                userEntity.Language = model.Language;
                if(!string.IsNullOrEmpty(SavePath)){
                    userEntity.PdfPath = SavePath;
                }
                userEntity.PublishDate = model.PublishDate;
                userEntity.Title = model.Title;
                userEntity.WebsiteURL = model.WebsiteURL;
                userEntity.Writer = model.Writer;
                if(!string.IsNullOrEmpty(ImagePath)){
                    userEntity.FrontImage = ImagePath;
                }
                medicalJournalService.UpdateJournal(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }
                model.JournalTypeList = new SelectList(TypeList, "ID", "TypeName");
            }
            return View(model);
        }

        public ActionResult DetailMedicJournal(int? id)
        {
            MedicalJournalModel model = new MedicalJournalModel();
            if (id.HasValue && id != 0)
            {

                MedicJournal userEntity = medicalJournalService.GetJournal(id.Value);
                model.Description = userEntity.Description;
                model.Details = userEntity.Details;
                model.EISSN = userEntity.EISSN;
                model.ISIImpactFactor = userEntity.ISIImpactFactor;
                model.ISSN = userEntity.ISSN;
                model.TypeName = journalTypeService.GetType(userEntity.JournalTypeID).TypeName;
                model.Language = userEntity.Language;
                model.PdfPath = userEntity.PdfPath;
                model.PublishDate = userEntity.PublishDate;
                model.Title = userEntity.Title;
                model.WebsiteURL = userEntity.WebsiteURL;
                model.Writer = userEntity.Writer;
                model.PublishDate = userEntity.PublishDate;
                model.FrontImage = userEntity.FrontImage;
            }
            return View(model);
        }

        public ActionResult DeleteMedicJournal(int id)
        {
            MedicalJournalModel model = new MedicalJournalModel();
            if (id != 0)
            {
                MedicJournal userEntity = medicalJournalService.GetJournal(id);
                if (userEntity != null)
                {
                    model.Title = userEntity.Title;
                    model.ISSN = userEntity.ISSN;
                    model.EISSN = userEntity.EISSN;
                    model.Writer = userEntity.Writer;
                    model.PublishDate = userEntity.PublishDate;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteMedicJournal(int id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    MedicJournal userEntity = medicalJournalService.GetJournal(id);
                    medicalJournalService.DeleteJournal(userEntity);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}