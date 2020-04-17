# Party Thyme
Is a console app that allows users to track their gardens. This will let us track what plants we have planted, how long ago they were planted and other details.

# Objectives

- Create a console app that uses an ORM to talk to a database
- Working with EF Core
- Reenforce SQL basics

# Includes: 

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [LINQ](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
- [EF CORE](https://docs.microsoft.com/en-us/ef/core/)
- [POSTGRESQL](https://www.postgresql.org/)
- MVC design pattern

```C#
 public partial class PlantContext : DbContext
    {
        public DbSet<Plant> Plants {get;set;}
        public PlantContext()
        {
        }

        public PlantContext(DbContextOptions<PlantContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("server=localhost;database=PlantDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
 ```
 
## User Actions

- View
- Plant
- Remove
- Water
- Need to be watered
- Location Summary

## App In Action

### VIEW
![record it](http://g.recordit.co/gXmrMoRIDf.gif)

### PLANT
![record it](http://g.recordit.co/CX2YTzDhyN.gif)

### REMOVE
![record it](http://g.recordit.co/SjUOkdIANb.gif)

### WATER & NEED TO BE WATERED
![record it](http://g.recordit.co/K6S6EwQCFW.gif)

### LOCATION SUMMARY
![record it](http://g.recordit.co/LB0pFXeu63.gif)
