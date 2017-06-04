namespace TUI
{
	public class Position
	{
		public Position(int x = 0, int y = 0)
		{
			this.X = x;
			this.Y = y;
		}

		public int X { get; set; }

		public int Y { get; set; }

		public override bool Equals(object obj)
		{
			var other = obj as Position;

			return other.X == X && other.Y == Y;
		}

		public static Position operator -(Position one, Position two)
		{
			return new Position(one.X - two.X, one.Y - two.Y);
		}

		public Position Clone()
		{
			return new Position(X, Y);
		}
	}
}