using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingFPT.Models;
using TrainingFPT.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace TrainingFPT.Controllers
{
    public class TrainerTopicsController : Controller
    {
        private ApplicationDbContext _context;

        public TrainerTopicsController()
        {
            _context = new ApplicationDbContext();
        }
        [Authorize(Roles = "Staff, Trainer")]
        public ActionResult Index()
        {
            if (User.IsInRole("Staff"))
            {
                var trainertopics = _context.TrainerTopics
                  .Include(t => t.Topic)
                  .Include(t => t.Trainer)
                  .ToList();
                return View(trainertopics);
            }

            if (User.IsInRole("Trainer"))
            {
                var trainerId = User.Identity.GetUserId();
                var Res = _context.TrainerTopics
                  .Where(e => e.TrainerId == trainerId)
                  .Include(t => t.Topic)
                  .ToList();
                return View(Res);
            }
            return View("Login");
        }

        [Authorize(Roles = "Staff")]
        [HttpGet]
        public ActionResult Create()
        {
            var role = (from r in _context.Roles
                        where r.Name.Contains("Trainer")
                        select r)
                        .FirstOrDefault();
            var users = _context.Users
              .Where(x => x.Roles
              .Select(y => y.RoleId)
              .Contains(role.Id))
              .ToList();

            var topics = _context.Topics.ToList();

            var TrainerTopicVM = new TrainerTopicViewModel()
            {
                Topics = topics,
                Trainers = users,
                TrainerTopic = new TrainerTopic()
            };

            return View(TrainerTopicVM);
        }

        [HttpPost]
        public ActionResult Create(TrainerTopicViewModel model)
        {
            var role = (from r in _context.Roles
                        where r.Name.Contains("Trainer")
                        select r)
                        .FirstOrDefault();
            var users = _context.Users
              .Where(x => x.Roles
              .Select(y => y.RoleId)
              .Contains(role.Id))
              .ToList();

            var topics = _context.Topics.ToList();
            if (!ModelState.IsValid)
            {
                return View();
            }

            var trainerTopics = _context.TrainerTopics.ToList();
            var topicId = model.TrainerTopic.TopicId;

            var checkTrainerInTopic = trainerTopics
              .SingleOrDefault(c => c.TopicId == topicId && c.TrainerId == model.TrainerTopic.TrainerId);

            if (checkTrainerInTopic != null)
            {
                ModelState.AddModelError("Name", "Trainer Topic Already Exists.");
                var TrainerTopicVM = new TrainerTopicViewModel()
                {
                    Topics = topics,
                    Trainers = users,
                    TrainerTopic = new TrainerTopic()
                };
                return View(TrainerTopicVM);
            }

            /*var TrainerTopicVM = new TrainerTopicViewModel()
            {
              Topics = topics,
              Trainers = users,
              TrainerTopic = new TrainerTopic()
            };*/
            _context.TrainerTopics.Add(model.TrainerTopic);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}