/* Spaghetti Dinner
 * 1) Spaghetti
 *		a) boil the water (5 minutes)
 *		b) cook the noodles (7 minutes)
 *		c) drain the noodles
 *		
 *	2) Sauce
 *		a) heat the pan (2 minutes)
 *		b) add sauce and frozen meatballs
 *		c) cook the sauce (8 minutes)
 *		
 *	3) Rolls
 *		a) preheat the oven to 375 (4 minutes)
 *		c) bake the rolls (5 minutes)
 *		
 *	4) Salad
 *		a) open salad bag and put salad in bowl
 *		b) add dressing pack and seasoning and toss the salad (1 minute)
 *		
 * 
 */

namespace SlowSpaghettiDinner {
	internal class Salad { }
	internal class Spaghetti { }
	internal class Sauce { }
	internal class Rolls { }

	class Program {
		static void Main(string[] args) {

			DateTime time1 = DateTime.Now;

			// Spaghetti noodles
			Spaghetti spaghetti = BoilSpaghetti();
			DrainNoodles(spaghetti);
			Console.WriteLine("Spaghetti noodles are ready");

			// Spaghetti sauce
			Sauce sauce = MakeSauce();
			Console.WriteLine("Sauce is ready");

			// Rolls
			Rolls rolls = BakeRolls();
			Console.WriteLine("Rolls are ready");

			// Salad
			Salad salad = PrepareSalad();
			Console.WriteLine("Salad is ready");

			TimeSpan elapsedTime = DateTime.Now - time1;
			ConsoleColor color = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($"Dinner is served! Elapsed time: {elapsedTime.Seconds} minutes");
			Console.ForegroundColor = color;
		}

		private static Spaghetti BoilSpaghetti() {
			Console.WriteLine("Heating up the water...");
			Task.Delay(5000).Wait();
			Console.WriteLine("Boiling the noodles...");
			Task.Delay(7000).Wait();
			return new Spaghetti();
		}

		private static void DrainNoodles(Spaghetti spaghetti) =>
			Console.WriteLine("Draining the noodles.");

		private static Sauce MakeSauce() {
			Console.WriteLine("Warming up the saucepan...");
			Task.Delay(2000).Wait();
			Console.WriteLine("Adding the sauce and frozen meatballs.");
			Console.WriteLine("Cooking the sauce...");
			Task.Delay(8000).Wait();
			return new Sauce();
		}

		private static Rolls BakeRolls() {
			Console.WriteLine("Pre-heating the oven to 375...");
			Task.Delay(4000).Wait();
			Console.WriteLine("Baking the rolls...");
			Task.Delay(5000).Wait();
			return new Rolls();
		}

		private static Salad PrepareSalad() {
			Console.WriteLine("Open salad bag and put salad in bowl");
			Console.WriteLine("Adding dressing and spices and tossing the salad...");
			Task.Delay(1000).Wait();
			return new Salad();
		}

	}


}
