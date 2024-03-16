using System.Text;

string? word = null;
while (word != "quit") {
	do {
		Console.WriteLine("Enter a short word (\"quit\" to quit): ");
		word = Console.ReadLine();
	} while (word == null);

	if (word != "quit") {
		HandleWord(word);
	}
}

int RandomlyRecreate(string? word) {
	if (word == null) return 0;
	int attempts = 0;
	StringBuilder sb;
	Random random = new Random();

	do {
		sb = new StringBuilder();
		for (int i = 0; i < word.Length; i++) {
			sb.Append((char)('a' + random.Next(26)));
		}
		attempts += 1;
	} while (sb.ToString() != word);

	return attempts;

}

async Task HandleWord(string word) {
	DateTime time1 = DateTime.Now;
	int attempts = await RandomlyRecreateAsync(word);
	TimeSpan elapsedTime = DateTime.Now - time1;
	ConsoleColor oldColor = Console.ForegroundColor;
	Console.ForegroundColor = ConsoleColor.White;
	Console.WriteLine($"Operation for \"{word}\" took {attempts} attempts and {elapsedTime}");
	Console.ForegroundColor = oldColor;
}

Task<int> RandomlyRecreateAsync(string word) {
	return Task.Run(() => {
		return RandomlyRecreate(word);
	});
}