TheLongGame game = new TheLongGame();

game.Run();

public class TheLongGame {
	public string Username { get; set; }
	private int _score = 0;

	public TheLongGame() {

	}

	public void Run() {
		EstablishUsername();
		if (LoadScore()) {
			Console.WriteLine($"Welcome back, {Username}. Please begin typing");
		} else {
			Console.WriteLine($"Welcome, {Username}. Please begin typing");
		}
		while (Console.ReadKey().Key != ConsoleKey.Enter) {
			_score++;
			Console.WriteLine($" Score: {_score}");
		}

		// Todo: save score to username.txt
		SaveScore();
	}

	private bool LoadScore() {
		bool output = false;
		if (File.Exists($"{Username}.txt")) {
			output = true;
			_score = Convert.ToInt32(File.ReadAllText($"{Username}.txt"));
		}
		return output;
	}

	private void SaveScore() {
		File.WriteAllText($"{Username}.txt", _score + "");
	}

	private void EstablishUsername() {
		string? username = "";
		do {
			Console.Write("Enter your username: ");
			username = Console.ReadLine();
		} while(username == "" || username == null);
		Username = username;
	}
}