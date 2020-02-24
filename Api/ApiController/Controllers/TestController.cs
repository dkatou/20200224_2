using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.ApiModel.Data;
using Api.ApiModel.Models;

namespace ApiController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApiContext _context;

        public TestController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Test
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestModel>>> GetTestModel()
        {
            return await _context.TestModel.ToListAsync();
        }

        // GET: api/Test/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestModel>> GetTestModel(long id)
        {
            var testModel = await _context.TestModel.FindAsync(id);

            if (testModel == null)
            {
                return NotFound();
            }

            return testModel;
        }

        // PUT: api/Test/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestModel(long id, TestModel testModel)
        {
            if (id != testModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(testModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Test
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TestModel>> PostTestModel(TestModel testModel)
        {
            _context.TestModel.Add(testModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTestModel), new { id = testModel.Id }, testModel);
        }

        // DELETE: api/Test/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TestModel>> DeleteTestModel(long id)
        {
            var testModel = await _context.TestModel.FindAsync(id);
            if (testModel == null)
            {
                return NotFound();
            }

            _context.TestModel.Remove(testModel);
            await _context.SaveChangesAsync();

            return testModel;
        }

        private bool TestModelExists(long id)
        {
            return _context.TestModel.Any(e => e.Id == id);
        }
    }
}
