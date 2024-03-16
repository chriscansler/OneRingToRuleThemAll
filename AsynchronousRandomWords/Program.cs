using System.Text;

string? word = null;

do {
	Console.Write("Enter a short word: ");
	word = Console.ReadLine();
} while(word == null);

DateTime time1 = DateTime.Now;
int attempts = await RandomlyRecreateAsync(word);
Console.WriteLine(attempts);
TimeSpan elapsedTime = DateTime.Now - time1;
Console.WriteLine($"Operation took {elapsedTime}");

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
	} while(sb.ToString() != word);

	return attempts;

}

Task<int> RandomlyRecreateAsync(string word) {
	return Task.Run(() => {
		return RandomlyRecreate(word);
	});
}