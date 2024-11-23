using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP_Management_System.DTOs;
using TRP_Management_System.EF;

namespace TRP_Management_System.Controllers
{
    public class ChannelController : Controller
    {
        private readonly TRP_Management_System_Entities tmse = new TRP_Management_System_Entities();

        // Converts Channel dto to entity
        private Channel Convert(Create_Channel_DTO d)
        {
            return new Channel()
            {
                ChannelName = d.ChannelName,
                EstablishedYear = (int)d.EstablishedYear,
                Country = d.Country,
            };
        }

        // Converts Channel entity to dto
        private Create_Channel_DTO Convert(TRP_Management_System_Entities e)
        {
            return new Create_Channel_DTO();
        }

        [HttpGet]
        public ActionResult List_Of_Channels()
        {
            return View(tmse.Channels.ToList());
        }

        [HttpGet]
        public ActionResult Create_Channel()
        {
            return View(new Create_Channel_DTO());
        }

        [HttpPost]
        public ActionResult Create_Channel(Create_Channel_DTO c)
        {
            if (ModelState.IsValid)
            {
                tmse.Channels.Add(Convert(c));
                tmse.SaveChanges();
                return RedirectToAction("List_Of_Channels");
            }
            return View(c);
        }

        [HttpGet]
        public ActionResult Edit_Channel(int id)
        {
            return View(tmse.Channels.Find(id));
        }

        [HttpPost]
        public ActionResult Edit_Channel(int id, Create_Channel_DTO c)
        {
            if (ModelState.IsValid)
            {
                var isExist = tmse.Channels.Find(id);

                if (isExist == null)
                {
                    return View();
                }
                else
                {
                    isExist.ChannelName = c.ChannelName;
                    isExist.EstablishedYear = (int)c.EstablishedYear;
                    isExist.Country = c.Country;
                    tmse.SaveChanges();

                    return RedirectToAction("List_Of_Channels");
                }
            }
            else
            {
                return View(c);
            }
        }

        [HttpGet]
        public ActionResult Delete_Channel(int id)
        {
            return View(tmse.Channels.Find(id));
        }

        [HttpPost]
        public ActionResult Delete_Channel(int id, string Decision)
        {
            var getChannel = tmse.Channels.Find(id);

            if(Decision == "Delete")
            {
                tmse.Channels.Remove(getChannel);
                tmse.SaveChanges();
            }

            return RedirectToAction("List_Of_Channels");
        }
    }
}