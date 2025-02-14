using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Model;
using Backend.Model;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResidentsController : ControllerBase
{
    private readonly DataContext context;
    public ResidentsController(DataContext c)
    {
        context = c;
    }
    [HttpGet]
    public IActionResult GetResidents()
    {
        var residents = context.ResidentList!.AsQueryable();
        return Ok(residents);

    }
    [HttpPost]
    public IActionResult Create([FromBody] Resident e)
    {
        var dbResident = context.ResidentList?.Find(e.Id);
        if (dbResident == null)
        {
            context.ResidentList?.Add(e);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetResidents), new { e.Id }, e);
        }
        return Conflict();
    }
    [HttpPut("{id}")]
    public IActionResult Update(int? id, [FromBody] Resident e)
    {
        var dbResident = context.ResidentList!.AsNoTracking().FirstOrDefault(residentInDB => residentInDB.Id == e.Id);
        if (id != e.Id || dbResident == null) return NotFound();
        context.Update(e);
        context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var residentToDelete = context.ResidentList?.Find(id);
        if (residentToDelete == null) return NotFound();
        context.ResidentList?.Remove(residentToDelete);
        context.SaveChanges();
        return NoContent();
    }

}