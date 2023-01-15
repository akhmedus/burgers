using webAPI.Models;
using webAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BurgerController:ControllerBase{
    public BurgerController(){

    }

    [HttpGet]
    public ActionResult<List<Burger>> GetBurgers(){
        return BurgerServices.GetBurgers();
    }
    
    [HttpGet("{id}")]
    public ActionResult<Burger> GetBurger(int id){
        
        var burger=BurgerServices.GetBurger(id);

        if(burger==null){
            return NotFound();
        }

        return burger;
    }


    [HttpPost]
    public IActionResult AddBurger(Burger burger){
        
        BurgerServices.AddBurger(burger);

        return CreatedAtAction(nameof(GetBurger),new{
            id=burger.ID
        },burger);

    }


    [HttpPut("{id}")]
    public IActionResult EditBurger(int id,Burger burger){

        if(id!=burger.ID){
            return BadRequest();
        }

        var burgerEdit = BurgerServices.GetBurger(id);

        if(burgerEdit is null){
            return NotFound();
        }

        BurgerServices.EditBurger(burger);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoveBurger(int id){
        
        var burger = BurgerServices.GetBurger(id);

        if(burger is null){
            return NotFound();
        }

        BurgerServices.RemoveBurger(id);

        return NoContent();
    }
}