using System;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

  
    public Color(int red, int green, int blue, int alpha)
    {
        this.red = ValidateColorComponent(red);
        this.green = ValidateColorComponent(green);
        this.blue = ValidateColorComponent(blue);
        this.alpha = ValidateColorComponent(alpha);
    }

    
    public Color(int red, int green, int blue) : this(red, green, blue, 255)
    {
    }

    public int Red { get { return red; } }
    public int Green { get { return green; } }
    public int Blue { get { return blue; } }
    public int Alpha { get { return alpha; } }

    
    public int GetGrey()
    {
        return (red + green + blue) / 3;
    }
    public class Sphere
{
    private Color color;
    private double radius;
    private int timesThrown;

    
    public Sphere(Color color, double radius)
    {
        this.color = color;
        this.radius = radius;
        this.timesThrown = 0;
    }

    
    public void Pop()
    {
        radius = 0;
    }

    
    public void Throw()
    {
        if (radius > 0)
        {
            timesThrown++;
        }
    }

    
    public int GetTimesThrown()
    {
        return timesThrown;
    }
}
}

