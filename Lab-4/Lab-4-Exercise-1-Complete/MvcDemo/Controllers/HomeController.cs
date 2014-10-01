﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;
using MvcDemo.ActionFilters;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var meetingRepository = new MockMeetingRepository();
            List<Meeting> meetings = meetingRepository.GetAll();
            
            return View(meetings);    
        }

//        [CustomAction]
        [ProfileAction]
        public string FilterTest()
        {
            return "This is the FilterTest action";
        }
    }
}