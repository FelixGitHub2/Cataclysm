
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


Rectangle character = new Rectangle(200, 768 / 2 - 25, 50, 50);

Vector2 playerlatePos = new Vector2(character.x, character.y);

Rectangle enemy = new Rectangle(1500, 1000 / 2 - 25, 50, 500);

Vector2 enemylatePos = new Vector2(enemy.x);

Rectangle enemy2 = new Rectangle(1750, 90 / 2 - 25, 50, 500);

Vector2 enemy2latePos = new Vector2(enemy2.x);

Rectangle enemy3 = new Rectangle(2350, 300 / 2 - 25, 50, 1200);

Vector2 enemy3latePos = new Vector2(enemy3.x);

Rectangle diamond = new Rectangle(3000, 768 / 2 - 25, 20, 20);

Vector2 diamondlatePos = new Vector2(diamond.x);

Rectangle enemy4 = new Rectangle(3500, 90 / 2 - 25, 50, 1600);

Vector2 enemy4latePos = new Vector2(enemy4.x);

while (!Raylib.WindowShouldClose())
{
    // LOGIK

    //COLLISION FÖR CHARACTER OCH ENEMY
    bool are0verlapping = Raylib.CheckCollisionRecs(character, enemy);
    bool are0verlapping2 = Raylib.CheckCollisionRecs(character, enemy2);
    bool are0verlapping3 = Raylib.CheckCollisionRecs(character, enemy3);
    bool are0verlapping4 = Raylib.CheckCollisionRecs(character, enemy4);

    bool are0verlappingdiamond = Raylib.CheckCollisionRecs(character, diamond);


    if (are0verlapping == true)
    {
        return;
    }

    if (are0verlapping2 == true)
    {
        return;
    }

    if (are0verlapping3 == true)
    {
        return;
    }

    if (are0verlapping4 == true)
    {
        return;
    }


    //SCENES
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

        enemylatePos = new Vector2(enemy.x);
        if (currentScene == "game")
            enemy.x -= speed;

        enemy2latePos = new Vector2(enemy2.x);
        if (currentScene == "game")
            enemy2.x -= speed;

        enemy3latePos = new Vector2(enemy3.x);
        if (currentScene == "game")
            enemy3.x -= speed;

        diamondlatePos = new Vector2(diamond.x);
        if (currentScene == "game")
            diamond.x -= speed;

        enemy4latePos = new Vector2(enemy4.x);
        if (currentScene == "game")
            enemy4.x -= speed;

    }

    if (currentScene == "game")
    {
        if (are0verlappingdiamond == true)
        {
            currentScene = "win";
        }

    }


    // GRAFIK
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.LIGHTGRAY);

    if (currentScene == "menu")
    {
        Raylib.DrawText("HAPPY WHEELS", 115, 300, 64, Color.BLACK);
        Raylib.DrawText("MATRIX", 650, 300, 64, Color.DARKGREEN);
        Raylib.DrawText("PRESS ENTER", 280, 400, 64, Color.RED);
        Raylib.DrawText("W/UP", 20, 650, 64, Color.GRAY);
        Raylib.DrawText("S/DOWN", 20, 700, 64, Color.GRAY);
        Raylib.DrawText("GOAL = GET DIAMOND", 350, 705, 50, Color.GRAY);
        Rectangle diamondwin = new Rectangle(950, 1485 / 2 - 25, 20, 20);
        Raylib.DrawRectangleRec(diamondwin, Color.BLUE);
    }
    if (currentScene == "game")
    {
        Raylib.DrawRectangleRec(character, Color.BLACK);

        Raylib.DrawRectangleRec(enemy, Color.RED);
        Raylib.DrawRectangleRec(enemy2, Color.RED);
        Raylib.DrawRectangleRec(enemy3, Color.RED);
        Raylib.DrawRectangleRec(enemy4, Color.RED);

        Raylib.DrawRectangleRec(diamond, Color.BLUE);

        foreach (Rectangle wall in walls)
        {
            Raylib.DrawRectangleRec(wall, Color.GRAY);
        }


    }
    if (currentScene == "win")
    {
        Raylib.DrawText("YOU GOT DIAMOND :D", 150, 300, 64, Color.BLACK);

        Rectangle characterwin = new Rectangle(470, 900 / 2 - 255, 50, 50);
        Raylib.DrawRectangleRec(characterwin, Color.BLACK);

        Rectangle diamondwin = new Rectangle(515, 890 / 2 - 25, 20, 20);
        Raylib.DrawRectangleRec(diamondwin, Color.BLUE);

    }

    Raylib.EndDrawing();
}



//CRED ATLE
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


