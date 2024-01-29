﻿using ConsoleClient.CrossCutting;
using ConsoleClient.Logic;

namespace ConsoleClient.UI;

class App
{
    private readonly IPersonManager _manager;

    public App(IPersonManager manager)
    {
        _manager = manager;
    }

    public void Run()
    {

        var adults = _manager.GetAllAdults().ToList();
        Console.WriteLine($"### ERWACHSENE ({adults.Count}) ###");
        adults.ForEach(a => Console.WriteLine(a.Name));

        var children = _manager.GetAllChildren().ToList();
        Console.WriteLine($"### KINDER ({children.Count}) ###");
        children.ForEach(c => Console.WriteLine(c.Name));
    }
}