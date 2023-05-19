

using APIBLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBLayer.Managers.Tickets
{
    public interface ITicketManager
    {
        
        List<TicketReadDto> GetAll();
        TicketReadDto? GetById(int id);

        int Add(TicketAddDto ticketDto);
        bool Update(TicketUpdateDto ticketDto);
        void Delete(int id);


     
    }
}
