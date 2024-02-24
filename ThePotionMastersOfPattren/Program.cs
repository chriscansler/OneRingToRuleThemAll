Potions potion = Potions.Water;
List<Ingredients> ingredients = new List<Ingredients> {
	Ingredients.Stardust,
	Ingredients.SnakeVenom,
	Ingredients.DragonBreath,
	Ingredients.ShadowGlass,
	Ingredients.EyeshineGem
};

while(true) {
	Console.WriteLine($"You currently have a {potion} potion right now.");
	PrintIngredientsList();
	Console.WriteLine($"{ingredients.Count + 1} - Stop");

	int choice;
	do {
		Console.Write("Which ingredient would you like to add? ");
	} while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > ingredients.Count + 1);

	if (choice == ingredients.Count + 1) {
		if (potion is Potions.Water) {
			Console.WriteLine($"Well, you made a {potion} potion. Is that really what you wanted?");
		} else {
			Console.WriteLine($"Alright, you made a {potion} potion, good job! ");
		}
		
		break;
	}

	Ingredients ingredientChoice = GetIngredient(choice);
	Console.WriteLine($"Now adding {ingredientChoice} to {potion}...");
	potion = GetPotion(ingredientChoice, potion);
	if (potion is Potions.Ruined) {
		Console.WriteLine($"Adding {ingredientChoice} ruined the potion. Let's start over again with {Potions.Water}");
		potion = Potions.Water;
	}
	
}

bool QuitAddingStuff() {
	int choice;
	do {
		Console.WriteLine("What would you like to do?");
		Console.WriteLine("1 - keep adding stuff");
		Console.WriteLine("2 - stop here");
	} while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2);

	return choice == 2;
}

Potions GetPotion(Ingredients ingredient, Potions potion) {
	return (ingredient, potion) switch {
		(Ingredients.Stardust,		Potions.Water)			=> Potions.Elixir,
		(Ingredients.SnakeVenom,	Potions.Elixir)			=> Potions.Poison,
		(Ingredients.DragonBreath,	Potions.Elixir)			=> Potions.Flying,
		(Ingredients.ShadowGlass,	Potions.Elixir)			=> Potions.Invisibility,
		(Ingredients.EyeshineGem,	Potions.Elixir)			=> Potions.NightSight,
		(Ingredients.ShadowGlass,	Potions.NightSight)		=> Potions.CloudyBrew,
		(Ingredients.EyeshineGem,	Potions.Invisibility)	=> Potions.CloudyBrew,
		(Ingredients.Stardust,		Potions.CloudyBrew)		=> Potions.Wraith,
		_ => Potions.Ruined
	};
}

Ingredients GetIngredient(int choice) {
	return choice switch {
		1 => Ingredients.Stardust,
		2 => Ingredients.SnakeVenom,
		3 => Ingredients.DragonBreath,
		4 => Ingredients.ShadowGlass,
		5 => Ingredients.EyeshineGem,
		_ => Ingredients.Stardust,
	};
}

void PrintIngredientsList() {
	int i = 1;
	foreach (Ingredients ingredient in ingredients) {
		Console.WriteLine($"{i++} - {ingredient}");
	}
}

public enum Potions { Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined }
public enum Ingredients { Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem }


