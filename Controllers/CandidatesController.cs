using api.Data;
using api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly DataContext _context;

        public CandidatesController(DataContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> Get()
        {
            var candidates = new List<Candidate>();

            try
            {
                candidates = await _context.Candidates.ToListAsync();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(candidates);

        }


        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
            return Ok(candidate);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Candidate>> PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest("Wrong ID.");
            }

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(candidate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);

            if(candidate == null) return NotFound();

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return Ok("Candidate deleted.");
        }
    }
}
