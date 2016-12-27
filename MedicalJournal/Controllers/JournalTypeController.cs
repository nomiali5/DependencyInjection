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
    public class JournalTypeController : Controller
    {
        private IJournalTypeService journalTypeService;
        public JournalTypeController(IJournalTypeService JournalTypeService)
        {
            this.journalTypeService = JournalTypeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<JournalTypeModel> users = journalTypeService.GetTypes().Select(u => new JournalTypeModel
            {
                TypeName = u.TypeName,
                ID = u.ID,
                FrontImage = u.FrontImage
            });
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateEditJournalType(int? id)
        {
            JournalTypeModel model = new JournalTypeModel();
            if (id.HasValue && id != 0)
            {
                JournalType userEntity = journalTypeService.GetType(id.Value);
                model.TypeName = userEntity.TypeName;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditJournalType(JournalTypeModel model, HttpPostedFileBase[] UploadImage)
        {
            var ImagePath = "";
            if (model.ID == 0)
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
                JournalType userEntity = new JournalType
                {
                    TypeName = model.TypeName,
                    FrontImage = ImagePath
                };
                journalTypeService.InsertType(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }
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
                JournalType userEntity = journalTypeService.GetType(model.ID);
                userEntity.TypeName = model.TypeName;
                userEntity.FrontImage = ImagePath;
                journalTypeService.UpdateType(userEntity);
                if (userEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }

            }
            return View(model);
        }

        public ActionResult DetailJournalType(int? id)
        {
            JournalTypeModel model = new JournalTypeModel();
            if (id.HasValue && id != 0)
            {
                JournalType userEntity = journalTypeService.GetType(id.Value);
                model.TypeName = userEntity.TypeName;
                model.FrontImage = userEntity.FrontImage;
            }
            return View(model);
        }

        public ActionResult DeleteJournalType(int id)
        {
            JournalTypeModel model = new JournalTypeModel();
            if (id != 0)
            {
                JournalType userEntity = journalTypeService.GetType(id);
                if (userEntity != null)
                {
                    model.TypeName = userEntity.TypeName;
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteJournalType(int id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    JournalType userEntity = journalTypeService.GetType(id);
                    journalTypeService.DeleteType(userEntity);
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