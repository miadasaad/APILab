using LabOne.filtes;
using LabOne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static List<Car> _cars = new List<Car> { 
            new Car { Id = 1, Model = "BMW", Color = "red" ,ProductionDate = new DateTime(2020, 1, 1)}
            ,new Car{Id = 2, Model = "BMW", Color = "blue",ProductionDate = new DateTime(2020, 1, 1)  } ,
             new Car { Id = 3, Model = "BMW", Color = "yellow",ProductionDate = new DateTime(2020, 1, 1) }
            ,new Car{Id = 4, Model = "BMW", Color = "pink" ,ProductionDate = new DateTime(2020, 1, 1) } 
        };
        

        [HttpGet]
        public ActionResult<List<Car>> getAll()
        {
         
            return _cars;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> getById(int id)
        {
            Car? car = _cars.Find(x => x.Id == id);
            if (car is null)
            {
                return NotFound(new GeneralResponse("car isn't found"));
            }
            return car;
        }
        [HttpPost]
        [Route("oldCar")]
        public ActionResult AddOld(Car car)
        {
            car.Id = _cars.Count + 1;
            car.type = "Gas";
            _cars.Add(car);
            return CreatedAtAction("getById", new { id = car.Id }, new GeneralResponse("car has been added successfully"));
        }
        [HttpPost]
        [Route("newcar")]
        [TypeValidation]
        public ActionResult AddNew(Car car)
        {
            car.Id = _cars.Count + 1;
            _cars.Add(car);
            return CreatedAtAction("getById", new { id = car.Id }, new GeneralResponse("car has been added successfully"));
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(Car car, int id)
        {
            if (id != car.Id)
            {
                return BadRequest(new GeneralResponse("id isn't right"));
            }
            Car? oldCar = _cars.FirstOrDefault(a => a.Id == id);
            if (oldCar is null)
            {
                return NotFound();
            }
            oldCar.Model = car.Model;
                return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete( int id)
        {
            
            Car? oldCar = _cars.FirstOrDefault(a => a.Id == id);
            if (oldCar is null)
            {
                return NotFound();
            }
            _cars.Remove(oldCar);
            return NoContent();
        }
    }
}
