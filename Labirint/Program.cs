using System.Collections.Generic;

int[,] labirynth = new int[,]
{
{1, 1, 1, 1, 1, 1, 1 },
{1, 0, 0, 0, 0, 0, 1 },
{1, 0, 1, 1, 1, 0, 1 },
{0, 0, 0, 0, 1, 0, 2 },
{1, 1, 0, 0, 1, 1, 1 },
{1, 1, 1, 1, 1, 1, 1 },
{1, 1, 1, 1, 1, 1, 1 }
};


Console.WriteLine(HasExit(1, 1, labirynth));

static bool HasExit(int startI, int startJ, int[,] labirynth)
{
    Queue<(int, int)> coords = new();

    if (labirynth[startJ, startI] != 1)
    {
        coords.Enqueue((startI, startJ));
    }
    while (coords.Count > 0)
    {
        (int i, int j) = coords.Dequeue();

        if (labirynth[i, j] == 2) return true;

        labirynth[i, j] = 1;
        if (i - 1 >= 0 && labirynth[i - 1, j] != 1) coords.Enqueue((i - 1, j));
        if (i + 1 < labirynth.GetLength(0) && labirynth[i + 1, j] != 1) coords.Enqueue((i + 1, j));
        if (j - 1 >= 0 && labirynth[i, j-1] != 1) coords.Enqueue((i, j - 1));
        if (j + 1 < labirynth.GetLength(1) && labirynth[i, j + 1] != 1) coords.Enqueue((i, j + 1));
    }
    return false;
}
