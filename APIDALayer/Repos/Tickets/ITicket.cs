using APIDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace APIDALayer.Repos.Tickets
{
    public interface ITicket
    {
        IEnumerable<Ticket> GetAll();
        Ticket? GetById(int id);
        void Add(Ticket entity);
        void Update(Ticket entity);
        void Delete(Ticket entity);

        int SaveChanges();
        Ticket? GetWithPatientsAndIssues(int id);
    }
}
