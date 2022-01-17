using System;
using System.Numerics;
using Raylib_cs;
using System.Collections.Generic;

Raylib.InitWindow(800, 600, "The title of my window");
Raylib.SetTargetFPS(60);

string level = "lobby";


while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    if (level == "lobby")
    {
        Raylib.ClearBackground(Color.YELLOW);

    }

    if (level == "fight")
    {
        Raylib.ClearBackground(Color.GRAY);
    }


    Raylib.EndDrawing();
}