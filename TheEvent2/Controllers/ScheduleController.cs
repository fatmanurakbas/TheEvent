using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using TheEvent.DAL.Entities;
using TheEvent.DAL.Interfaces;

namespace TheEvent.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public IActionResult Index()
        {
            var values = _scheduleRepository.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSchedule()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSchedule(Schedule model)
        {
            if (model.ImageFile != null)
            {
                var currentDir = Directory.GetCurrentDirectory();
                var ext = Path.GetExtension(model.ImageFile.FileName);
                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(currentDir, "wwwroot/images", fileName + ext);

                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);

                model.ImageUrl = "/images/" + fileName + ext;
            }

            _scheduleRepository.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSchedule(int id)
        {
            var value = _scheduleRepository.GetById(id);
            if (value != null)
            {
                _scheduleRepository.Delete(value);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSchedule(int id)
        {
            var value = _scheduleRepository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSchedule(Schedule model)
        {
            var existingSchedule = _scheduleRepository.GetById(model.ScheduleId);
            if (existingSchedule == null)
                return NotFound();

            if (model.ImageFile != null)
            {
                var currentDir = Directory.GetCurrentDirectory();
                var ext = Path.GetExtension(model.ImageFile.FileName);
                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(currentDir, "wwwroot/images", fileName + ext);

                using var stream = new FileStream(path, FileMode.Create);
                model.ImageFile.CopyTo(stream);

                existingSchedule.ImageUrl = "/images/" + fileName + ext;
            }

            existingSchedule.Name = model.Name;
            existingSchedule.Title = model.Title;
            existingSchedule.Description = model.Description;
            existingSchedule.Time = model.Time;

            _scheduleRepository.Update(existingSchedule);
            return RedirectToAction("Index");
        }
    }
}
