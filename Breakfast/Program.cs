// make coffee
// start bacon, eggs, and toast at same time
// put jam and butter on toast
// pour juice

namespace AsyncBreakfast {
	internal class Coffee { }
	internal class Egg { }
	internal class Bacon { }
	internal class Toast { }
	internal class Juice { }

	class Program {
		static async Task Main(string[] args) {
			Coffee cup = PourCoffee();
			Console.WriteLine("The coffee is ready.");
			
			var eggsTask = FryEggsAsync(2);
			var baconTask = FryBaconAsync(3);
			var toastTask = MakeToastWithButterAndJamAsync(2);

			var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
			while (breakfastTasks.Count > 0) {
				// doesn't await the finished task;
				// it awaits the Task returned by Task.WhenAny
				Task finishedTask = await Task.WhenAny(breakfastTasks); 
				if (finishedTask == eggsTask) {
					Console.WriteLine("eggs are ready");
				} else if (finishedTask == baconTask) {
					Console.WriteLine("bacon is done");
				} else if (finishedTask == toastTask) {
					Console.WriteLine("toast is done");
				}
				// Task has finished running, but we must await it again.
				// That's how you retrieve the result (or possible exception)
				await finishedTask;
				breakfastTasks.Remove(finishedTask);
			}

			Juice oj = PourOJ();
			Console.WriteLine("oj is ready");
			Console.WriteLine("Breakfast is ready!");
		}

		private static Juice PourOJ() {
			Console.WriteLine("Pouring orange juice");
			return new Juice();
		}

		static async Task<Toast> MakeToastWithButterAndJamAsync(int number) {
			var toast = await ToastBreadAsync(number);
			ApplyButter(toast);
			ApplyJam(toast);

			return toast;
		}

		private static void ApplyJam(Toast toast) =>
			Console.WriteLine("Putting jam on the toast");

		private static void ApplyButter(Toast toast) =>
			Console.WriteLine("Putting butter on the toast");

		private static async Task<Toast> ToastBreadAsync(int slices) {
			for (int slice = 0; slice < slices; slice++) {
				Console.WriteLine("Putting a slice of bread in the toaster");
			}
			Console.WriteLine("Start toasting...");
			await Task.Delay(3000);
			Console.WriteLine("Remove toast from toaster");

			return new Toast();
		}

		private static async Task<Bacon> FryBaconAsync(int slices) {
			Console.WriteLine($"Putting {slices} slices of bacon in the pan");
			Console.WriteLine("cooking first side of bacon...");
			await Task.Delay(3000);
			for (int slice = 0; slice < slices; slice++) {
				Console.WriteLine("flipping a slice of bacon");
			}
			Console.WriteLine("cooking the second side of bacon...");
			await Task.Delay(3000);
			Console.WriteLine("Put bacon on plate");
			return new Bacon();
		}

		private static async Task<Egg> FryEggsAsync(int howMany) {
			Console.WriteLine("Warming up the pan...");
			await Task.Delay(3000);
			Console.WriteLine($"cracking {howMany} eggs");
			Console.WriteLine("cooking the eggs...");
			await Task.Delay(3000);
			Console.WriteLine("Put eggs on plate");
			return new Egg();
		}

		private static Coffee PourCoffee() {
			Console.WriteLine("Pouring coffee");
			return new Coffee();
		}
	}
}