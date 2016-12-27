namespace MedicalJournal.Controllers
{
    using Core.Data;
    using Data;
    using MedicalJournal.Service;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    [Authorize(Roles = "Admin")]
    public class PublisherController : Controller
    {
        private IPubService userService;
        public PublisherController(IPubService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {

            IEnumerable<PublisherModel> users = userService.GetPublishers().Select(u => new PublisherModel
            {
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Address = u.Address,
                ID = u.Id
            });
            return View(users);
        }

        [HttpGet]
        public ActionResult CreateEditPublisher(string id)
        {

            PublisherModel model = new PublisherModel();
            if (!string.IsNullOrEmpty(id))
            {
                ApplicationUser userEntity = userService.GetPublisher(id);
                model.FirstName = userEntity.FirstName;
                model.LastName = userEntity.LastName;
                model.Address = userEntity.Address;
                model.Email = userEntity.Email;
                model.UserName = userEntity.UserName;
            }
            return View(model);
        }
        public ActionResult DetailPublisher(string id)
        {
            PublisherModel model = new PublisherModel();
            if (!string.IsNullOrEmpty(id))
            {
                ApplicationUser userEntity = userService.GetPublisher(id);
                model.FirstName = userEntity.FirstName;
                model.LastName = userEntity.LastName;
                model.Address = userEntity.Address;
                model.Email = userEntity.Email;
                model.UserName = userEntity.UserName;
            }
            return View(model);
        }

        public ActionResult DeletePublisher(string id)
        {
            PublisherModel model = new PublisherModel();
            if (!string.IsNullOrEmpty(id))
            {
                ApplicationUser userEntity = userService.GetPublisher(id);
                if (userEntity != null)
                {
                    model.FirstName = userEntity.FirstName;
                    model.LastName = userEntity.LastName;
                    model.Address = userEntity.Address;
                    model.Email = userEntity.Email;
                    model.UserName = userEntity.UserName;
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult DeletePublisher(string id, FormCollection collection)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    ApplicationUser userEntity = userService.GetPublisher(id);
                    userService.DeletePublisher(userEntity);
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