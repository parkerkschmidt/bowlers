using System;
using System.Linq;
using BowlersApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlersApp.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlersDbContext context { get; set; }

        public TeamViewComponent(BowlersDbContext temp)
        {
            context = temp;
        }

        // function to grab the distinct different categories to display on the home page
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["teamNames"];

            var teams = context.Teams.Select(x => x.TeamName).Distinct().OrderBy(x => x);
            return View(teams);
        }

    }
}
