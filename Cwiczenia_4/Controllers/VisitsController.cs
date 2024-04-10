using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Cwiczenia_4.Models;

namespace Cwiczenia_4.Controllers;
    
    
    [ApiController]
    [Route("api/visits")]
    public class VisitsController : ControllerBase
    {
        private static readonly List<Wizyta> _wizyty = new List<Wizyta>()
        {
            new Wizyta { Id = 1, ZwierzeId = 1, DataWizyty = new DateTime(2023, 10, 01), Opis = "Szczepienie", Cena = 150.00M },
            new Wizyta { Id = 2, ZwierzeId = 2, DataWizyty = new DateTime(2023, 10, 15), Opis = "Kontrola zdrowia", Cena = 100.00M }
        };

        [HttpGet("{zwierzeId}")]
        public ActionResult<IEnumerable<Wizyta>> Get(int zwierzeId)
        {
            var wizyty = _wizyty.Where(w => w.ZwierzeId == zwierzeId).ToList();
            if (!wizyty.Any()) return NotFound();
            return wizyty;
        }

        [HttpPost]
        public IActionResult Post(Wizyta wizyta)
        {
            _wizyty.Add(wizyta);
            return CreatedAtAction("Get", new { zwierzeId = wizyta.ZwierzeId }, wizyta);
        }
    }
