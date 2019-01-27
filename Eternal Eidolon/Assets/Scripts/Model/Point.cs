using System;

[System.Serializable]

/************************************************************

Point.cs

IMPORTANT
	Currently does not support height. This will be necessary
	to implement later... but for now, I guess we can deal.

************************************************************/

public struct Point
{
	public int x;
	public int y;

	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public static Point operator +(Point a, Point b)
	{
		return new Point(a.x + b.x, a.y + b.y);
	}

	public static Point operator -(Point a, Point b)
	{
		return new Point(a.x - b.x, a.y - b.y);
	}

	public static bool operator ==(Point a, Point b)
	{
		return a.x == b.x && a.x == b.y;
	}

	public static bool operator !=(Point a, Point b)
	{
		return !(a == b);
	}

	public override bool Equals(Object obj) 
	{
		//Check for null and compare run-time types.
		if ((obj == null) || ! this.GetType().Equals(obj.GetType())) 
			return false;
		else 
		{ 
			Point p = (Point) obj; 
			return (this.x == p.x) && (this.y == p.y);
		}   
	}
	
	public override int GetHashCode() 
	{
		return (x << 2) ^ y;
	}
}
