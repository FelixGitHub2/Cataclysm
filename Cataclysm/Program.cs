
using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1024, 768, "Cataclysm");
Raylib.SetTargetFPS(60);

string currentScene = "menu";
float speed = 5f;

const int screenwidth = 1024;
const int screenheight = 768;


List<Rectangle> walls = new List<Rectangle>();

int thickness = 20;

walls.Add(new Rectangle(0, 0, Raylib.GetScreenWidth(), thickness));
walls.Add(new Rectangle(0, Raylib.GetScreenHeight() - thickness, Raylib.GetScreenWidth(), thickness));
walls.Add(new Rectangle(0, 0, thickness, Raylib.GetScreenWidth()));

List<Rectangle> enemy = new List<Rectangle>();



Rectangle character = new Rectangle(200, 768 / 2 - 25, 50, 50);

Vector2 playerlatePos = new Vector2(character.x, character.y);

while (!Raylib.WindowShouldClose())
{
    // LOGIK

    if (currentScene == "menu")
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }
    }
    else if (currentScene == "game")
    {
        playerlatePos = new Vector2(character.x, character.y);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            character.y += speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            character.y -= speed;
        CollitionLogic();
    }


    // GRAFIK
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.LIGHTGRAY);

    if (currentScene == "menu")
    {
        Raylib.DrawText("HAPPY WHEELS", 115, 300, 64, Color.BLACK);
        Raylib.DrawText("MATRIX", 650, 300, 64, Color.DARKGREEN);
        Raylib.DrawText("PRESS ENTER", 280, 400, 64, Color.RED);

    }
    if (currentScene == "game")
    {
        Raylib.DrawRectangleRec(character, Color.BLACK);

        foreach (Rectangle wall in walls)
        {
            Raylib.DrawRectangleRec(wall, Color.GRAY);
        }
    }



    Raylib.EndDrawing();
}

void CollitionLogic()
{
    foreach (Rectangle wall in walls)
    {
        if (Raylib.CheckCollisionRecs(character, wall))
        {
            character.x = playerlatePos.X;
            character.y = playerlatePos.Y;
        }
    }

}
