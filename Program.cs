using System;

using Grid;
using Grid.Event;

class Program {

    static void Func1(object? sender, Grid.Event.MagicStringEvent e) {
        Console.WriteLine($" - - - OPERATION: {e.String} - - -");

        Console.WriteLine("Function 1: done");
    }

    static void Func2(object? sender, Grid.Event.MagicStringEvent e) {
        Console.WriteLine($" - - - OPERATION: {e.String} - - -");

        Console.WriteLine("Function 2: done");
    }

    static void Func3(object? sender, Grid.Event.MagicStringEvent e) {
        Console.WriteLine($" - - - OPERATION: {e.String} - - -");

        Console.WriteLine("Function 3: done");
    }


    static void Main(string[] args) {
        var grid = new MagicGrid();

        grid._init_();

        grid.AppendLine("Function 1"); grid.LastString.Function += Func1;
        grid.AppendLine("Function 2"); grid.LastString.Function += Func2;
        grid.AppendLine("Function 3"); grid.LastString.Function += Func3;
        grid.AppendLine(grid.AppendExitLine());

        grid.VolumeGrid();
    }
}