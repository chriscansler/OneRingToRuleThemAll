int[] testArray = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5};

List<int> whatever1 = ProceduralCodeOnly(testArray);
Print(whatever1);

IEnumerable<int> whatever2 = KeywordLINQ(testArray);
Print(whatever2);

IEnumerable<int> whatever3 = KeywordLINQ(testArray);
Print(whatever3);

void Print(IEnumerable<int> whatever) {
	foreach(int n in whatever) {
		Console.Write($"{n} ");
	}
	Console.WriteLine();
}

List<int> ProceduralCodeOnly(int[] myArray) {
	Array.Sort(myArray);
	List<int> output = new List<int>();
	foreach(int n in myArray) {
		if (n % 2 == 0) {
			output.Add(n * 2);
		}
	}

	return output;
}

IEnumerable<int> KeywordLINQ(int[] myArray) {
	// evens

	// sorted

	// doubled

	IEnumerable<int> doubled = from o in myArray
							   where o % 2 == 0
							   orderby o
							   select o * 2;	

	return doubled;
}

IEnumerable<int> MethodCallLINQ(int[] myArray) {
	IEnumerable<int> doubled = myArray
									.Where(o => o % 2 == 0)
									.OrderBy(o => o)
									.Select(o => o * 2);

	return doubled;
}

// Smallest size is the method call linq. Easiest to understand is a tie between the
// keyword LINQ and the method call LINQ - however, I think the "into" aspect of the keyword
// version doesn't add much to readability. 

// I still like the keyword LINQ the best, but I also like the library of methods and intellisense on the method LINQ.
// I guess it's a draw for me. 