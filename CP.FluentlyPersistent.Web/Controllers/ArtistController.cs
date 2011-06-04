using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using CP.FluentlyPersistent.Web.Models.Domain;
using CP.FluentlyPersistent.Web.Models.ViewModels;
using NHibernate;

namespace CP.FluentlyPersistent.Web.Controllers
{
    public class ArtistController : Controller
    {
        readonly ISession _session;

        public ArtistController(ISession session)
        {
            _session = session;
        }
        
            Tuple<long, T> ExecuteWithStopwatch<T>(Func<T> action)
            {
                
            var stopwatch = new Stopwatch();
            stopwatch.Start();
             var model = action.Invoke();
            stopwatch.Stop();
                return new Tuple<long, T>(stopwatch.ElapsedMilliseconds,model);
            }

        public ActionResult Index()
        {
            ViewBag.Title = "Artist (Domain Model)";
            ViewBag.Message = "Artist (Domain Model)";

            var model = ExecuteWithStopwatch(() => _session.QueryOver<Artist>().List());

            ViewBag.QueryTime = model.Item1;
            return View(model.Item2);
        }

        public ActionResult ViewModel()
        {

            ViewBag.Title = "Artist (View Model)";
            ViewBag.Message = "Artist (View Model)";
            var model = ExecuteWithStopwatch(GetArtistViewModel);

            ViewBag.QueryTime = model.Item1;
            return View("ArtistViewModel",model.Item2);
        }
        public ActionResult BetterViewModel()
        {
            ViewBag.Title = "Artist (Better View Model)";
            ViewBag.Message = "Artist (Better View Model)";

            var model =ExecuteWithStopwatch(GetBetterArtistViewModel);

            ViewBag.QueryTime = model.Item1;
            return View("ArtistViewModel",model.Item2);
        }

        public ActionResult About()
        {
            return View();
        }




        List<ArtistViewModel> GetArtistViewModel()
        {
            return  _session.QueryOver<Artist>()
                .OrderBy(x => x.Name).Asc
                .List<Artist>()
                .Select(x => new ArtistViewModel
                                 {
                                     Id = x.Id,
                                     Name = x.Name,
                                     AlbumCount = x.Albums.Count()
                                 })
                .ToList();
        }

        List<ArtistViewModel> GetBetterArtistViewModel()
        {
            Album album = null;
            var model = _session.QueryOver<Artist>()
                .Left.JoinAlias(artist=>artist.Albums,()=>album)
                .OrderBy(x => x.Name).Asc
                .List<Artist>()
                .Select(x => new ArtistViewModel
                                 {
                                     Id =x.Id,
                                     Name = x.Name,
                                     AlbumCount = x.Albums.Count()
                                 })
                .ToList();
            return model;
        }

    }
}
