// BlockCoordiate + BlockOffset = BlockCoordinate
// example: (4,3) + offset (2,0) = (6,3)

BlockCoordinate bc = new BlockCoordinate(4, 3);
BlockOffset bo= new BlockOffset(2, 0);

Console.WriteLine(bc + bo);

Console.WriteLine($"North: {bc + Direction.North}");
Console.WriteLine($"East: {bc + Direction.East}");
Console.WriteLine($"South: {bc + Direction.South}");
Console.WriteLine($"West: {bc + Direction.West}");

Console.WriteLine($"bc[0]: {bc[0]}\nbc[1]: {bc[1]}\n");

List<BlockCoordinate> bcList = new List<BlockCoordinate>() {
	new BlockCoordinate(0, 0),
	new BlockCoordinate(0, 1),
	new BlockCoordinate(0, 2),
	new BlockCoordinate(1, 0),
	new BlockCoordinate(1, 1),
	new BlockCoordinate(1, 2),
	new BlockCoordinate(2, 0),
	new BlockCoordinate(2, 1),
	new BlockCoordinate(2, 2),
};

foreach (BlockCoordinate b in bcList) {
	Console.WriteLine($"{b.Row} {b.Column} vs {b[0]} {b[1]}");
}

BlockOffset n = Direction.North;
BlockOffset e = Direction.East;
BlockOffset s = Direction.South;
BlockOffset w = Direction.West;
Console.WriteLine($"Direction.North as a BlockOffset: {n}");
Console.WriteLine($"Direction.East as a BlockOffset: {e}");
Console.WriteLine((BlockOffset)Direction.South);


public record BlockCoordinate(int Row, int Column) {
	public static BlockCoordinate operator +(BlockCoordinate bc, BlockOffset bo) {
		return new BlockCoordinate(bc.Row + bo.RowOffset, bc.Column + bo.ColumnOffset);
	}

	public static BlockCoordinate operator +(BlockCoordinate bc, Direction d) {
		BlockOffset bo = d switch {
			Direction.North => new BlockOffset(-1, 0),
			Direction.East => new BlockOffset(0, 1),
			Direction.South => new BlockOffset(1, 0),
			Direction.West => new BlockOffset(0, -1),
			_ => new BlockOffset(0, 0)
		};

		return bc + bo;
	}
	// bc[0] is the same as bc.Row and bc[1] is the same as bc.Column
	// Slightly shorter to type, but more cryptic. I don't find it compelling.
	// Perhaps the example is too contrived to see the usefulness of the indexing operator overload.
	public int this[int index] {
		get {
			return index == 0 ? Row : Column;
		}
	}

}

public record BlockOffset(int RowOffset, int ColumnOffset) {
	public static implicit operator BlockOffset(Direction d) {
		return d switch {
			Direction.North => new BlockOffset(-1, 0),
			Direction.East => new BlockOffset(0, 1),
			Direction.South => new BlockOffset(1, 0),
			Direction.West => new BlockOffset(0, -1),
		};
	}
}

public enum Direction { North, East, South, West };


// Going from Direction to BlockOffset can be implicit, since there is
// no change at loss of data. Going from BlockOffset to Diretion - definitely
// explicit because there is defitely going to be a loss of data in most cases.