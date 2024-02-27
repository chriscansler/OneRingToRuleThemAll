// This example is about LINQ, which stands for Language Integrated Queries.
// These queries are done on objects in memory - arrays, lists, and dictionaries.
// When used in this manner, we call it LINQ for Objects. There is also a LINQ
// for SQL.

// The format is
//		from
//		where
//		select

List<GameObject> objects = new List<GameObject>();
objects.Add(new Ship { ID = 1, X=0, Y=0, HP = 50, MaxHP = 100, PlayerID = 1 });
objects.Add(new Ship { ID = 2, X=4, Y=2, HP = 75, MaxHP = 100, PlayerID = 1 });
objects.Add(new Ship { ID = 3, X=9, Y=3, HP = 0, MaxHP = 100, PlayerID = 2 });

List<Player> players = new List<Player>();
players.Add(new Player(1, "Player 1", "Red"));
players.Add(new Player(2, "Player 2", "Blue"));

IEnumerable<(GameObject, string)> healthStatus = from o in objects
												 where o.HP > 0
												 select (o, $"{o.HP}/{o.MaxHP}");
Console.WriteLine("healthStatus:");
foreach ((GameObject, string) status in healthStatus) {
	Console.WriteLine($"{status.Item1} {status.Item2}");
}

IEnumerable<GameObject> weakestObjects = from o in objects
										 orderby o.MaxHP ascending, o.HP ascending // ascending is the default and could be left off
										 select o;

Console.WriteLine("\nweakestObjects:");
foreach(GameObject o in weakestObjects) {
	Console.WriteLine($"{o} HP: {o.HP} MaxHP: {o.MaxHP}");
}

var wimpyObjects = objects
						.OrderBy(o => o.MaxHP )
						.OrderBy(o => o.HP );

Console.WriteLine("\nwimpyObjects:");
foreach (GameObject o in wimpyObjects) {
	Console.WriteLine($"{o} HP: {o.HP} MaxHP: {o.MaxHP}");
}

int highestHP = objects.Max(o => o.HP);
double averageHP = objects.Average(o => o.HP);
Console.WriteLine($"\nHighest HP: {highestHP}");
Console.WriteLine($"\nAverage HP: {averageHP:0.00}");

public class GameObject {
	public int ID { get; set; }
	public double X { get; set; }
	public double Y { get; set; }
	public int MaxHP { get; set; }
	public int HP { get; set; }
	public int PlayerID { get; set; }
}

public class Ship : GameObject { }

public record Player(int ID, string UserName, string TeamColor);


