using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElVegetarianoFurio.Models
{
    public class VegiContext : DbContext

    {
        //Zugriggsschnittstelle zur Datenbank
        public VegiContext(DbContextOptions<VegiContext> options): base(options)
        {

        }  

        //Das EF wird zwei Tabellen anlegen, Dishes und Caregries
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

// ---Wichtige Infos---(Genaue angaben unter Kap.3: EF Code First Migrationen ausführen)

// Nugetpackade hinzufügen
// Microsoft.EntityFrameworkCore.Design

//----Info cmd micration commandos---
//dotnet tool install --global dotnet-ef    -- Nur einmal um das EF tool zu instalieren
//dotnet ef                                 -- EF Tool anzeigen

//Datenbank anlegen
// 1. cd C:\Users\BucFra\Documents\GIT_GitHub\demo\ElVegetarianoFurio\ElVegetarianoFurio
// 2. dotnet ef migrations add InitialCreate
// 3. dotnet ef database update  

// Datenbank wurde jetzt angelegt
// Öffne Server-Explorer
//(localdb)\mssqllocaldb
// ElVegetarianoFurioSpa
