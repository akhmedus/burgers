using webAPI.Models;

namespace webAPI.Services;

public static class BurgerServices{
    static List<Burger> Burgers{get;}

    static BurgerServices(){
        Burgers=new List<Burger>{
            new Burger{ID=1,Name="Little",WithCheese=false},
            new Burger{ID=2,Name="Big",WithCheese=true}
        };
    }

    public static List<Burger> GetBurgers(){
        return Burgers;
    }
    public static Burger? GetBurger(int id){
        return Burgers.FirstOrDefault(p=>p.ID==id);
    }

    public static void AddBurger(Burger burger){
        burger.ID=burger.ID++;
        Burgers.Add(burger);
    }

    public static void RemoveBurger(int id){
        var burger = GetBurger(id);

        if(burger is null){
            return;
        }

        Burgers.Remove(burger);
    }

    public static void EditBurger(Burger burger){
        var index = Burgers.FindIndex(p=>p.ID==burger.ID);

        if(index==-1){
            return;
        }

        Burgers[index]=burger;
    }
}