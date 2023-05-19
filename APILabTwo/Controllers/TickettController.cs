using APIBLayer.Dtos;
using APIBLayer.Managers.Tickets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAPresentationLabTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickettController : ControllerBase
    {
        private readonly ITicketManager ticketManager;
        public TickettController(ITicketManager _ticketManager)
        {
            ticketManager = _ticketManager;
        }
        [HttpGet]
        public ActionResult<List<TicketReadDto>> GetAll()
        {
            return ticketManager.GetAll();
        }
        [HttpPut]
        public ActionResult Update(TicketUpdateDto upd_ticket) {
           var res =  ticketManager.Update(upd_ticket);
            if (res)
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult AddTicket(TicketAddDto add_ticket)
        {
           int tickId =  ticketManager.Add(add_ticket);
            
            return CreatedAtAction("getById", new { id = tickId});
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<TicketReadDto> getById(int id)
        {
           var ticket = ticketManager.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult delete(int id)
        {
            ticketManager.Delete(id);
            return NoContent();
        }
        //[HttpGet]
        //[Route("department/{id}")]
        //public ActionResult<DepartmentReadDto> getDept(int id)
        //{

        //}
    }
}
