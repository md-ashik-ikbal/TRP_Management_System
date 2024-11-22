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
                return View(c);
            }
            return View(c);
        }
    }
}