using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBLayer.Dtos
{
    public class ticketInfoDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DeveloperCount { get; set; }
    }
}


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