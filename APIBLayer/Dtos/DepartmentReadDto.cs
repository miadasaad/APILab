using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBLayer.Dtos
{
    public class DepartmentReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ticketInfoDto> tickets { get; set; } = new();
    }
}



//● "Id": 1,
//● "Name": "Web App Development Department",
//● "Tickets": [
//● {
//● "Id": 10,
//● "Description": "Very cool ticket",
//● "DevelopersCount": 10
//● },
//● {
//● "Id": 20,
//● "Description": "weird bug",
//● "DevelopersCount": 5
//● }
//● ]
//● }
