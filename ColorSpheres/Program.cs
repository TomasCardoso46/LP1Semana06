using System;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    // Construtor que aceita todos os parâmetros necessários para inicializar o estado de uma cor
    public Color(int red, int green, int blue, int alpha)
    {
        this.red = ValidateColorComponent(red);
        this.green = ValidateColorComponent(green);
        this.blue = ValidateColorComponent(blue);
        this.alpha = ValidateColorComponent(alpha);
    }

    // Construtor que aceita red, green e blue, colocando alpha a 255 (opaco)
    public Color(int red, int green, int blue) : this(red, green, blue, 255)
    {
    }

    // Métodos getter para os componentes red, green, blue e alpha
    public int Red { get { return red; } }
    public int Green { get { return green; } }
    public int Blue { get { return blue; } }
    public int Alpha { get { return alpha; } }

    // Método para calcular o grau de cinzento da cor
    public int GetGrey()
    {
        return (red + green + blue) / 3;
    }

    // Método para validar os componentes de cor
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

    // Construtor que aceita a cor e o raio da esfera
    public Sphere(Color color, double radius)
    {
        this.color = color;
        this.radius = radius;
        this.timesThrown = 0;
    }

    // Método para furar a esfera (coloca o raio a zero)
    public void Pop()
    {
        radius = 0;
    }

    // Método para incrementar o número de vezes que a esfera foi atirada
    public void Throw()
    {
        if (radius > 0)
        {
            timesThrown++;
        }
    }

    // Método para obter o número de vezes que a esfera foi atirada
    public int GetTimesThrown()
    {
        return timesThrown;
    }

    // Propriedades para acessar a cor e o raio da esfera
    public Color Color { get { return color; } }
    public double Radius { get { return radius; } }
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
