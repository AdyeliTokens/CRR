﻿using Newtonsoft.Json;
using CRR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Globalization;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using CRR.DAL;
using CRR.Models.Helpers;
using CRR.Modelo.AtomFeed;

namespace CRR.Controllers
{
    [Authorize]
    public class AtomFeedController : Controller
    {
        private CRRContext db = new CRRContext();

        public ActionResult Index()
        {
            FechaInicioFin model = new FechaInicioFin();
            model.Inicio = DateTime.Now.Date;
            model.Fin = DateTime.Now.Date.AddDays(1);
            return View(model);
        }


        [HttpPost]
        public ActionResult PopulateAtomFeed(FechaInicioFin model)
        {
            string atomFeedUrl = ConfigurationManager.AppSettings["AtomFeedUrl"];
            List<AtomFeedView> feeds = new List<AtomFeedView>();
            XmlTextReader reader = new XmlTextReader(atomFeedUrl);
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            if (feed != null)
            {
                feeds.AddRange(feed.Items.Select(i => new AtomFeedView
                {
                    Title = i.Title.Text,
                    PublishDate = i.PublishDate.DateTime.ToUniversalTime().ToString(CultureInfo.InvariantCulture),
                    Description = ((TextSyndicationContent)(i.Content)).Text

                }));
            }

            return PartialView(feeds);
        }

    }

}