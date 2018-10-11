using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NLog;
using OrganizerMVC.Models;
using OrganizerMVC.ViewModels;

namespace OrganizerMVC.Controllers
{
    public class BaseController : Controller
    {
        protected OrganizerDbContext DbContext;
        protected ILogger Logger;
        protected IMapper Mapper;

        public BaseController()
        {
            DbContext = new OrganizerDbContext();
            Logger = LogManager.GetCurrentClassLogger();

            ConfigureAutoMapper();
        }

        private void ConfigureAutoMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Event, EventViewModel>();
                    cfg.CreateMap<Sport, SportViewModel>();
                });

            Mapper = config.CreateMapper();
        }

    }
}