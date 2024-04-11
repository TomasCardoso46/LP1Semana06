using System;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    public Color(int red, int green, int blue, int alpha)
    {
        Red = red;
        Green = green;
        Blue = blue;
        Alpha = alpha;
    }

    public Color(int red, int green, int blue) : this(red, green, blue, 255)
    {
    }

    public int Red
    {
        get { return red; }
        set { red = ValidateColorComponent(value); }
    }

    public int Green
    {
        get { return green; }
        set { green = ValidateColorComponent(value); }
    }

    public int Blue
    {
        get { return blue; }
        set { blue = ValidateColorComponent(value); }
    }

    public int Alpha
    {
        get { return alpha; }
        set { alpha = ValidateColorComponent(value); }
    }

    public int GetGrey()
    {
        return (Red + Green + Blue) / 3;
    }

    private int ValidateColorComponent(int value)
    {
        if (value < 0 || value > 255)
        {
            throw new ArgumentException("Color component must be between 0 and 255");
        }
        return value;
    }
}

public class Sphere
{
    private Color color;
    private double radius;
    private int timesThrown;

    public Sphere(Color color, double radius)
    {
        this.Color = color;
        this.Radius = radius;
        this.timesThrown = 0;
    }

    public void Pop()
    {
        Radius = 0;
    }

    public void Throw()
    {
        if (Radius > 0)
        {
            timesThrown++;
        }
    }

    public int GetTimesThrown()
    {
        return timesThrown;
    }

    public Color Color
    {
        get { return color; }
        set { color = value; }
    }

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando uma cor vermelha
        Color color = new Color(255, 0, 0);

        // Criando uma esfera vermelha com raio 5
        Sphere sphere1 = new Sphere(color, 5);

        Console.WriteLine("Esfera 1:");
        PrintSphereState(sphere1);

        // Atirando a esfera
        sphere1.Throw();

        Console.WriteLine("\nEsfera 1 depois de ser atirada:");
        PrintSphereState(sphere1);

        // Furando a esfera
        sphere1.Pop();

        Console.WriteLine("\nEstado da Esfera 1 depois de ser furada:");
        PrintSphereState(sphere1);
    }

    // Método auxiliar para imprimir o estado da esfera
    static void PrintSphereState(Sphere sphere)
    {
        Console.WriteLine($"Cor da esfera: R={sphere.Color.Red}, G={sphere.Color.Green}, B={sphere.Color.Blue}, A={sphere.Color.Alpha}");
        Console.WriteLine($"Raio da esfera: {sphere.Radius}");
        Console.WriteLine($"Número de vezes que a esfera foi atirada: {sphere.GetTimesThrown()}");
    }
}

