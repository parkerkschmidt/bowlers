using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlersApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BowlersApp.Controllers
{
    public class HomeController : Controller
    {

        private BowlersDbContext context { get; set; }

        public HomeController(BowlersDbContext temp)
        {
            context = temp;
        }

        //home page
        public IActionResult Index(string teamNames)
        {
            ViewBag.teams = teamNames;
            var bowlersContext = context.Bowlers
                .Where(b => b.Team.TeamName == teamNames || teamNames == null)
                .ToList();
            return View(bowlersContext);
        }


        // add bowler page
        [HttpGet]
        public IActionResult AddBowler()
        {
            ViewBag.teams = context.Teams.ToList();
            return View("BowlerForm", new Bowler());
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                context.Add(bowler);
                context.SaveChanges();

                return RedirectToAction("Index", bowler);
            }
            else
            {
                return View(bowler);

            }
        }

        //edit bowler page 
        [HttpGet]
        public IActionResult EditBowler(int id)
        {
            ViewBag.teams = context.Teams.ToList();
            var bowler = context.Bowlers.Single(x => x.BowlerID == id);

            return View("BowlerForm", bowler);
        }

        [HttpPost]
        public IActionResult EditBowler(Bowler bowler)
        {
            context.Update(bowler);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        //delete bowler page
        [HttpGet]
        public IActionResult DeleteBowler(int id)
        {
            var bowler = context.Bowlers.Single(x => x.BowlerID == id);

            return View("DeleteBowler", bowler);
        }


        [HttpPost]
        public IActionResult DeleteBowler(Bowler bowler)
        {
            context.Remove(bowler);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }




}
