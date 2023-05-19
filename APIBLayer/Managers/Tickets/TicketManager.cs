using APIBLayer.Dtos;
using APIDAL.Data.Models;
using APIDALayer.Repos.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBLayer.Managers.Tickets
{
    public class TicketManager : ITicketManager
    {
        private readonly ITicket ticket;
        public TicketManager(ITicket _ticket)
        {
            ticket = _ticket;
        }
        public int Add(TicketAddDto ticketDto)
        {
            var newTicket = new Ticket
            {
                Title = ticketDto.Title,
                Description = ticketDto.Description
            };
            ticket.Add(newTicket);
            ticket.SaveChanges();
            return newTicket.Id;

        }

        public void Delete(int id)
        {
            var oldTicket = ticket.GetById(id);
            if (oldTicket == null)
            {
                return ;
            }
    
            ticket.Delete(oldTicket);
            ticket.SaveChanges();
        }

        public List<TicketReadDto> GetAll()
        {
            IEnumerable<Ticket> tickets = ticket.GetAll();
            return tickets.Select(a => new TicketReadDto
            {
                Id = a.Id,
                Description = a.Description,
                Title = a.Title 
            }).ToList();
        }

        public TicketReadDto? GetById(int id)
        {
            var my_ticket = ticket.GetById(id);
            if (my_ticket == null){ 
                return null;
            }
            return new TicketReadDto
            {
                Id = my_ticket.Id,
                Description = my_ticket.Description,
                Title = my_ticket.Title
            };
        }

       

        public bool Update(TicketUpdateDto ticketDto)
        {
            var oldTicket = ticket.GetById(ticketDto.Id);
            if (oldTicket == null)
            {
                return false;
            }
            oldTicket.Title = ticketDto.Title;
            oldTicket.Description = ticketDto.Description;
            ticket.Update(oldTicket);
            ticket.SaveChanges();
            return true;
        }
    }
}
