using SplashKitSDK;
using static SplashKitSDK.SplashKit;

//constants

const int SCREEN_HEIGHT = 600;
const int SCREEN_WIDTH = 800;
const int CHARACTER_WIDTH = 101;
const int CHARACTER_HEIGHT = 123;
const int CHARACTER_SPEED = 5;
const int KEY_WIDTH = 74;
const int KEY_HEIGHT = 35;

//variables
bool blueKeyLive = true;
bool redKeyLive = true;
bool greenKeyLive = true;

int redKeyX = Rnd(SCREEN_WIDTH);
int redKeyY = Rnd(SCREEN_HEIGHT);
int blueKeyX = Rnd(SCREEN_WIDTH);
int blueKeyY = Rnd(SCREEN_HEIGHT);
int greenKeyX = Rnd(SCREEN_WIDTH);
int greenKeyY = Rnd(SCREEN_HEIGHT);

double characterX = SCREEN_WIDTH/2 - (CHARACTER_WIDTH/2);
double characterY = SCREEN_HEIGHT/2 - (CHARACTER_HEIGHT/2);



// Open Window
OpenWindow("Gorilla Key Puzzle", SCREEN_WIDTH, SCREEN_HEIGHT);
ClearScreen();

while (!QuitRequested())
{
    
    //draws character in the centre of the screen
    DrawBitmap("character.bmp",characterX ,characterY);
    //this redraws the character as it goes off screen
    if (characterX> SCREEN_WIDTH - (CHARACTER_WIDTH/2))
    {
        characterX = 0 - (CHARACTER_WIDTH*.33);
    }
    if (characterX< 0 - (CHARACTER_WIDTH/2))
    {
        characterX = SCREEN_WIDTH - (CHARACTER_WIDTH/2);
    }
    if (characterY> SCREEN_HEIGHT - (CHARACTER_HEIGHT/2))
    {
        characterY = 0 - (CHARACTER_HEIGHT*.33);
    }
    if (characterY< 0 - (CHARACTER_HEIGHT/2))
    {
        characterY = SCREEN_HEIGHT - (CHARACTER_HEIGHT/2);
    }

    //draws keys in random locations if they should be spawned. while loop makes sure they are onscreen.
    if (blueKeyLive)
    {
        DrawBitmap("blue key.bmp", blueKeyX, blueKeyY);
        while (blueKeyX > (SCREEN_WIDTH - KEY_WIDTH) || blueKeyY > (SCREEN_HEIGHT - KEY_HEIGHT) || BitmapCollision(bmp1:BitmapNamed("character.bmp") , characterX, characterY, bmp2:BitmapNamed("blue key.bmp") ,  blueKeyX, blueKeyY))
        {
            blueKeyX = Rnd(SCREEN_WIDTH);
            blueKeyY = Rnd(SCREEN_HEIGHT);
            DrawBitmap("blue key.bmp", blueKeyX, blueKeyY);
            
        }

       
    }
    
    if (greenKeyLive)
    {
        DrawBitmap("green key.bmp", greenKeyX, greenKeyY);
        while (greenKeyX > (SCREEN_WIDTH - KEY_WIDTH) || greenKeyY > (SCREEN_HEIGHT - KEY_HEIGHT) || BitmapCollision(bmp1:BitmapNamed("character.bmp") , characterX, characterY, bmp2:BitmapNamed("green key.bmp") ,  greenKeyX, greenKeyY))
        {
            greenKeyX = Rnd(SCREEN_WIDTH);
            greenKeyY = Rnd(SCREEN_HEIGHT);
            DrawBitmap("green key.bmp", greenKeyX, greenKeyY);
            
        }
    }

    if (redKeyLive)
    {
        DrawBitmap("red key.bmp", redKeyX, redKeyY);
        while (redKeyX > (SCREEN_WIDTH - KEY_WIDTH) || redKeyY > (SCREEN_HEIGHT - KEY_HEIGHT) || BitmapCollision(bmp1:BitmapNamed("character.bmp") , characterX, characterY, bmp2:BitmapNamed("red key.bmp") ,  redKeyX, redKeyY))
        {
            redKeyX = Rnd(SCREEN_WIDTH);
            redKeyY = Rnd(SCREEN_HEIGHT);
            DrawBitmap("red key.bmp", redKeyX, redKeyY);
            
        }
    }

    
    //character movement
    if (KeyDown(SplashKitSDK.KeyCode.UpKey))
    {
        characterY -= CHARACTER_SPEED;
    }
    if (KeyDown(SplashKitSDK.KeyCode.DownKey))
    {
        characterY += CHARACTER_SPEED;
    }
    if (KeyDown(SplashKitSDK.KeyCode.LeftKey))
    {
        characterX -= CHARACTER_SPEED;
    }
    if (KeyDown(SplashKitSDK.KeyCode.RightKey))
    {
        characterX += CHARACTER_SPEED;
    }   


    //Allow the character to collect keys. Branching statements will ensure that keys will reset if earlier keys havent been collected
    if (BitmapCollision(bmp1:BitmapNamed("character.bmp") , characterX, characterY, bmp2:BitmapNamed("blue key.bmp") ,  blueKeyX, blueKeyY))
    {
        blueKeyLive = false;
    }

    if (BitmapCollision(bmp1:BitmapNamed("character.bmp") , characterX, characterY, bmp2:BitmapNamed("green key.bmp") ,  greenKeyX, greenKeyY))
    {
        if (!blueKeyLive)
        {
            greenKeyLive = false;
        }
        else 
        {
            //reset all keys
            ClearScreen();
            blueKeyLive = true;
            greenKeyLive = true;
            redKeyLive = true;

            DrawBitmap("character.bmp", characterX,characterY);

            DrawBitmap("blue key.bmp", Rnd(SCREEN_WIDTH), Rnd(SCREEN_HEIGHT));
            while (blueKeyX > (SCREEN_WIDTH - KEY_WIDTH) || blueKeyY > (SCREEN_HEIGHT - KEY_HEIGHT) || BitmapCollision(bmp1:BitmapNamed("character.bmp"), characterX, characterY, bmp2:BitmapNamed("blue key.bmp"), blueKeyX, blueKeyY))
            {
                blueKeyX = Rnd(SCREEN_WIDTH);
                blueKeyY = Rnd(SCREEN_HEIGHT);
                DrawBitmap("blue key.bmp", blueKeyX, blueKeyY);
            }
            

            
            DrawBitmap("green key.bmp",Rnd(SCREEN_WIDTH), Rnd(SCREEN_HEIGHT));
                while (greenKeyX > (SCREEN_WIDTH - KEY_WIDTH) || greenKeyY > (SCREEN_HEIGHT - KEY_HEIGHT) || BitmapCollision(bmp1:BitmapNamed("character.bmp") , characterX, characterY, bmp2:BitmapNamed("green key.bmp") ,  greenKeyX, greenKeyY))
                {
                    greenKeyX = Rnd(SCREEN_WIDTH);
                    greenKeyY = Rnd(SCREEN_HEIGHT);
                    DrawBitmap("green key.bmp", greenKeyX, greenKeyY);

                
                }
                

            DrawBitmap("red key.bmp", Rnd(SCREEN_WIDTH), Rnd(SCREEN_HEIGHT));
            while (redKeyX > (SCREEN_WIDTH - KEY_WIDTH) || redKeyY > (SCREEN_HEIGHT - KEY_HEIGHT) || BitmapCollision(bmp1:BitmapNamed("character.bmp"), characterX, characterY, bmp2:BitmapNamed("red key.bmp"), redKeyX, redKeyY))
            {
                redKeyX = Rnd(SCREEN_WIDTH);
                redKeyY = Rnd(SCREEN_HEIGHT);
                DrawBitmap("red key.bmp", redKeyX, redKeyY);
            }
            
        }
    }

    if (BitmapCollision(bmp1:BitmapNamed("character.bmp") , characterX, characterY, bmp2:BitmapNamed("red key.bmp") ,  redKeyX, redKeyY))
    {
        if (!blueKeyLive & !greenKeyLive)
        {
            redKeyLive = false;
            ClearScreen();
            DrawText("WIN", Color.Black, (SCREEN_WIDTH/2), SCREEN_HEIGHT/2);
            
            
        }
        else 
        {
            //reset all keys
            ClearScreen();
            blueKeyLive = true;
            greenKeyLive = true;
            redKeyLive = true;

            DrawBitmap("character.bmp", characterX,characterY);

            DrawBitmap("blue key.bmp", Rnd(SCREEN_WIDTH), Rnd(SCREEN_HEIGHT));
            while (blueKeyX > (SCREEN_WIDTH - KEY_WIDTH) || blueKeyY > (SCREEN_HEIGHT - KEY_HEIGHT) || BitmapCollision(bmp1:BitmapNamed("character.bmp"), characterX, characterY, bmp2:BitmapNamed("blue key.bmp"), blueKeyX, blueKeyY))
            {
                blueKeyX = Rnd(SCREEN_WIDTH);
                blueKeyY = Rnd(SCREEN_HEIGHT);
                DrawBitmap("blue key.bmp", blueKeyX, blueKeyY);
            }
            

            
            DrawBitmap("green key.bmp",Rnd(SCREEN_WIDTH), Rnd(SCREEN_HEIGHT));
                while (greenKeyX > (SCREEN_WIDTH - KEY_WIDTH) || greenKeyY > (SCREEN_HEIGHT - KEY_HEIGHT) || BitmapCollision(bmp1:BitmapNamed("character.bmp") , characterX, characterY, bmp2:BitmapNamed("green key.bmp") ,  greenKeyX, greenKeyY))
                {
                    greenKeyX = Rnd(SCREEN_WIDTH);
                    greenKeyY = Rnd(SCREEN_HEIGHT);
                    DrawBitmap("green key.bmp", greenKeyX, greenKeyY);

                
                }
                

            DrawBitmap("red key.bmp", Rnd(SCREEN_WIDTH), Rnd(SCREEN_HEIGHT));
            while (redKeyX > (SCREEN_WIDTH - KEY_WIDTH) || redKeyY > (SCREEN_HEIGHT - KEY_HEIGHT) || BitmapCollision(bmp1:BitmapNamed("character.bmp"), characterX, characterY, bmp2:BitmapNamed("red key.bmp"), redKeyX, redKeyY))
            {
                redKeyX = Rnd(SCREEN_WIDTH);
                redKeyY = Rnd(SCREEN_HEIGHT);
                DrawBitmap("red key.bmp", redKeyX, redKeyY);
            }
            
        }
    }
    RefreshScreen(60);
    ClearScreen();
    ProcessEvents();
    
}
