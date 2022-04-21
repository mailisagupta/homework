using System;

class Point
{
    private int x;
    private int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public Point(double x, double y)
    {
        this.x = (int)x;
        this.y = (int)y;
    }

    public void Add(int x, int y)
    {
        this.x += x;
        this.y += y;
    }

    public void Add(Point p)
    {
        this.x += p.x;
        this.y += p.y;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }
}

