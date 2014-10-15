#include "AIE.h"
#include <iostream>
#include <cmath>

#define PI 3.14159

using namespace std;

int maxWidth = 1024;
int maxHeight = 768;
int main(int argc, char* argv[])
{
	Initialise(maxWidth, maxHeight, false, "Test Game");

	SetBackgroundColour(SColour(0, 0, 0, 255));
	float xPos = maxWidth * 0.5f;
	float yPos = maxHeight * 0.5f;
	int myTextureHandle = CreateSprite("./images/ship_destory_spritesheet.png", 511 / 6.0f, 106, true);
	int direction = 1;

	int count = .001;
	float timer = 1.0;
	float animTimer = timer;
	SetSpriteUVCoordinates(myTextureHandle, 0.0f, 0.0f, 52.0f / 511.0f, 1.0f);
	//Game Loop
	do
	{
		ClearScreen();
		
		if (animTimer <= 0)
		{
			SetSpriteUVCoordinates(myTextureHandle, 0.0f, (52.0f * count) / 511.0f, 52.0f * ++count / 511.0f, 1.0f);
			animTimer = timer;
			count++;
		}
		else
		{
			animTimer -= GetDeltaTime();
		}
		MoveSprite(myTextureHandle, xPos, yPos);
		DrawSprite(myTextureHandle);
	} while (!FrameworkUpdate());

	Shutdown();

	return 0;
}
