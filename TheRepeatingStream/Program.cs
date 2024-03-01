
RecentNumbers rn = new RecentNumbers();
rn.Recent1 = -1;
rn.Recent2 = -1;
Thread thread = new Thread(Run);
thread.Start(rn);

while(true) {
	Console.ReadKey(true);
	bool isDuplicate = false;
	lock(rn) {
		isDuplicate = rn.Recent1 == rn.Recent2;
	}
	if (isDuplicate) {
		Console.WriteLine("a match!");
	} else {
		Console.WriteLine("keep looking");
	}
	
}

void Run(Object? obj) {
	if (obj == null || obj is not RecentNumbers) return;
	RecentNumbers rn = (RecentNumbers)obj;
	Random random = new Random();
	while(true) {
		int x = random.Next(10);
		lock (rn) {
			rn.Recent2 = rn.Recent1;
			rn.Recent1 = x;
		}
		Console.WriteLine(x);
		Thread.Sleep(1000);
	}
}


class RecentNumbers {
	public int Recent1 { get; set; }
	public int Recent2 { get; set; }
}