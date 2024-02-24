MonsterPatterns mp = new MonsterPatterns();

Console.Title = "Monster Patterns";

List<Monster> monsters = new List<Monster>();
monsters.Add(new Snake(2.0));
monsters.Add(new Snake(5.5));
monsters.Add(new Dragon(DragonType.Red, LifePhase.Adult));
monsters.Add(new Skeleton());
Sword woodenSword = new Sword(SwordType.WoodenStick);
monsters.Add(new Orc(woodenSword));

foreach (Monster monster in monsters) {
	Console.WriteLine($"{monster.GetType(), -20}Score: {mp.ScoreFor(monster)}");
}

class MonsterPatterns {
	public MonsterPatterns() {

	}

	public int ScoreFor(Monster monster) {
		return monster switch {
			Snake s when s.Length >= 3 => 7,
			Snake					   => 3,
			Dragon					   => 50,
			_						   => 5
		};
	}
}

public abstract record Monster;

public record Skeleton() : Monster;
public record Snake(double Length) : Monster;
public record Dragon(DragonType Type, LifePhase LifePhase) : Monster;
public enum DragonType { Black, Green, Red, Blue, Gold }
public enum LifePhase { Wyrmling, Young, Adult, Ancient }
public record Orc(Sword Sword) : Monster;
public record Sword(SwordType Type);
public enum SwordType { WoodenStick, ArmingSword, Longsword }