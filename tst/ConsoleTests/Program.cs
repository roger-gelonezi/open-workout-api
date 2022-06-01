using Repository.Context;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<OpenWorkoutContext>()
                .UseSqlServer("Data Source=localhost;Initial Catalog=OpenWorkout;Persist Security Info=True;User ID=sa;Password=Pass@word")
                .Options;
var context = new OpenWorkoutContext(options);

var list = await context.MuscleGroups.ToListAsync();

Console.WriteLine("Created");
Console.WriteLine(list);