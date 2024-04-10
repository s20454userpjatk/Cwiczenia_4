using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Cwiczenia_4.Models;

namespace Cwiczenia_4.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{

    private static readonly List<Zwierze> _zwierzeta = new List<Zwierze>()
    {
        new Zwierze { Id = 1, Imie = "Reksio", Kategoria = "Pies", Masa = 20.5, KolorSiersci = "Czarny" },
        new Zwierze { Id = 2, Imie = "Mruczek", Kategoria = "Kot", Masa = 5.0, KolorSiersci = "Szary" }
    };

    [HttpGet]
    public IEnumerable<Zwierze> Get()
    {
        return _zwierzeta;
    }

    [HttpGet("{id}")]
    public ActionResult<Zwierze> Get(int id)
    {
        var zwierze = _zwierzeta.FirstOrDefault(z => z.Id == id);
        if (zwierze == null) return NotFound();
        return zwierze;
    }

    [HttpPost]
    public IActionResult Post(Zwierze zwierze)
    {
        _zwierzeta.Add(zwierze);
        return CreatedAtAction(nameof(Get), new { id = zwierze.Id }, zwierze);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Zwierze zwierze)
    {
        var index = _zwierzeta.FindIndex(z => z.Id == id);
        if (index == -1) return NotFound();

        _zwierzeta[index] = zwierze;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var zwierze = _zwierzeta.FirstOrDefault(z => z.Id == id);
        if (zwierze == null) return NotFound();

        _zwierzeta.Remove(zwierze);
        return NoContent();
    }
}