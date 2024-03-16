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

namespace AsyncSpaghettiDinner {
	internal class Salad { }
	internal class Spaghetti { }
	internal class Sauce { }
	internal class Rolls { }

	class Program {
		static async Task Main(string[] args) {
			DateTime time1 = DateTime.Now;
			var spaghettiTask = BoilSpaghettiAndDrainNoodlesAsync();
			var sauceTask = MakeSauceAsync();
			var rollsTask = BakeRollsAsync();
			var saladTask = PrepareSaladAsync();

			var dinnerTasks = new List<Task> { spaghettiTask, sauceTask, rollsTask, saladTask };
			while (dinnerTasks.Count > 0) {
				Task finishedTask = await Task.WhenAny(dinnerTasks);
				if (finishedTask == spaghettiTask) {
					Console.WriteLine("Noodles are drained and ready");
				} else if (finishedTask == sauceTask) {
					Console.WriteLine("Sauce is done");
				} else if (finishedTask == rollsTask) {
					Console.WriteLine("Rolls are done");
				} else if (finishedTask == saladTask) {
					Console.WriteLine("Salad is done");
				}
				await finishedTask;
				dinnerTasks.Remove(finishedTask);
			}

			TimeSpan elapsedTime = DateTime.Now - time1;
			ConsoleColor color = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Dinner is served! Elapsed time: ");
			Console.Write($"{elapsedTime.Seconds} minutes\n");
			Console.ForegroundColor = color;
		}

		private static async Task<Spaghetti> BoilSpaghettiAndDrainNoodlesAsync() {
			var spaghetti = await BoilNoodlesAsync();
			DrainNoodles(spaghetti);
			return spaghetti;
		}

		private static void DrainNoodles(Spaghetti spaghetti) =>
			Console.WriteLine("Drain the noodles");

		private static async Task<Spaghetti> BoilNoodlesAsync() {
			Console.WriteLine("Boiling the water...");
			await Task.Delay(5000);
			Console.WriteLine("Cooking the noodles...");
			await Task.Delay(7000);
			return new Spaghetti();
		}

		private static async Task<Sauce> MakeSauceAsync() {
			Console.WriteLine("Warming up the saucepan...");
			await Task.Delay(2000);
			Console.WriteLine("Adding the sauce and frozen meatballs.");
			Console.WriteLine("Cooking the sauce...");
			await Task.Delay(8000);
			return new Sauce();
		}

		private static async Task<Rolls> BakeRollsAsync() {
			Console.WriteLine("Pre-heating the oven to 375...");
			await Task.Delay(4000);
			Console.WriteLine("Baking the rolls...");
			await Task.Delay(5000);
			return new Rolls();
		}

		private static async Task<Salad> PrepareSaladAsync() {
			Console.WriteLine("Open salad bag and put salad in bowl");
			Console.WriteLine("Adding dressing and spices and tossing the salad...");
			await Task.Delay(1000);
			return new Salad();
		}
	}

	
 }
