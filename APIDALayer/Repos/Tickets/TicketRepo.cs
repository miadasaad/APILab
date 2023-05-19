using APIDAL.Data.Context;
using APIDAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDALayer.Repos.Tickets
{
    
    public class TicketRepo : ITicket
    {
        private readonly DataBaseContext context;
        public TicketRepo(DataBaseContext _context)
        {
            context = _context;
        }
        public void Add(Ticket entity)
        {
            context.Set<Ticket>().Add(entity);
        }

        public void Delete(Ticket entity)
        {
            context.Set<Ticket>().Remove(entity);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return context.Set<Ticket>().AsNoTracking();
        }

        public Ticket? GetById(int id)
        {
            return context.Set<Ticket>().Find(id);
        }

        public Ticket? GetWithPatientsAndIssues(int id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void Update(Ticket entity)
        {
            
        }
    }
}
