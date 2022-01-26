using System;
using System.Numerics;
using Raylib_cs;
using System.Collections.Generic;


Raylib.InitWindow(800, 600, "The title of my window");
Raylib.SetTargetFPS(60);

float speed = 6f;


Rectangle playerRect = new Rectangle(100, 100, 50, 50);
Rectangle doorRect = new Rectangle(260, 560, 40, 40);
Rectangle doorRect2 = new Rectangle(300, 560, 40, 40);
Rectangle bossRect = new Rectangle(700, 70, 40, 40);
Texture2D winterBackground = Raylib.LoadTexture("Vinterprojektet.png");


float time = 0;
int fighers_hp = 100;


string level = "start";
bool undoX = false;
bool undoY = false;



Vector2 movement = new Vector2();

while (!Raylib.WindowShouldClose())
{
    undoX = false;
    undoY = false;

    time += Raylib.GetFrameTime();

    if (time > 60 && fighers_hp < 100){
        fighers_hp ++;
        time = 0;
    }
    

    if (level == "start" || level == "shop")
    {
        playerRect = CheckMovement();

        movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

        if (playerRect.x < 0 || playerRect.width > Raylib.GetScreenWidth())
        { undoX = true; }
        if (playerRect.y < 0 || playerRect.width > Raylib.GetScreenWidth())
        { undoY = true; }
        if (playerRect.x < 0 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
        { undoX = true; }
        if (playerRect.y < 100 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
        { undoY = true; }
    }

    else if (level == "outside")
    {
        movement = ReadMovement(speed);
        playerRect.x += movement.X;
        playerRect.y += movement.Y;

        if (playerRect.x < 0 || playerRect.width > Raylib.GetScreenWidth())
        { undoX = true; }
        if (playerRect.y > 400 || playerRect.width > Raylib.GetScreenWidth())
        { undoY = true; }
        if (playerRect.x < 280 || playerRect.x + playerRect.width > Raylib.GetScreenWidth())
        { undoX = true; }
        if (playerRect.y < 100 || playerRect.y + playerRect.height > Raylib.GetScreenHeight())
        { undoY = true; }
    }


    if (Raylib.CheckCollisionRecs(, doorRect) && level == "start")
    {
        level = "outside";
        playerRect.x = 300;
        playerRect.y = 140;
        doorRect.x = 260;
        doorRect.y = 70;

        doorRect2.x = 500;
        doorRect2.y = 70;

    }

    else if (Raylib.CheckCollisionRecs(playerRect, doorRect) && level == "outside")
    {
        level = "start";
        playerRect.x = 300;
        playerRect.y = 500;
        doorRect.x = 260;
        doorRect.y = 560;
        bossRect.x = 700;
        bossRect.y = 70;
    }

    else if (Raylib.CheckCollisionRecs(playerRect, doorRect2) && level == "outside")
    {
        level = "shop";
        playerRect.x = 500;
        playerRect.y = 500;
        doorRect2.x = 500;
        doorRect2.y = 560;
    }

    if (Raylib.CheckCollisionRecs(playerRect, doorRect2) && level == "shop")
    {
        level = "outside";
        playerRect.x = 500;
        playerRect.y = 140;
        doorRect.x = 260;
        doorRect.y = 70;

        doorRect2.x = 500;
        doorRect2.y = 70;

    }


    if (undoX == true) playerRect.x -= movement.X;
    if (undoY == true) playerRect.y -= movement.Y;

    Raylib.BeginDrawing();

    if (level == "start")
    {
        Raylib.ClearBackground(Color.BLUE);
        Raylib.DrawRectangleRec(playerRect, Color.BROWN);
        Raylib.DrawRectangleRec(doorRect, Color.BLACK);
        Raylib.DrawRectangleRec(bossRect, Color.PURPLE);
    }

    else if (level == "outside")
    {
        Raylib.ClearBackground(Color.PINK);
        Raylib.DrawTexture(winterBackground, 0, 0, Color.WHITE);
        Raylib.DrawRectangleRec(playerRect, Color.BROWN);
        Raylib.DrawRectangleRec(doorRect, Color.BLACK);
        Raylib.DrawRectangleRec(doorRect2, Color.BLACK);
    }

    else if (level == "shop")
    {
        Raylib.ClearBackground(Color.RED);
        Raylib.DrawRectangleRec(playerRect, Color.BROWN);
        Raylib.DrawRectangleRec(doorRect2, Color.BLACK);
    }


    Raylib.EndDrawing();
}


static Vector2 ReadMovement(float speed)
{
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y = speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X = -speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X = speed;

    return movement;
}


static void CheckMovement(){
    
}




















//Raylib.InitWindow(800, 600, "The title of my window");
//Raylib.SetTargetFPS(60);

//string level = "lobby";
//bool undoX = false;
//bool undoY = false;

//while (!Raylib.WindowShouldClose())
//{
//   Raylib.BeginDrawing();



//    if (level == "lobby")
//   {
//       Raylib.ClearBackground(Color.YELLOW);

//   }

//   if (level == "fight")
//   {
//       Raylib.ClearBackground(Color.GRAY);
//   }


//  Raylib.EndDrawing();
//}