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
	int myTextureHandle = CreateSprite("./images/crate_sideup.png", 100, 100, false);
	int direction = 1;

	float radius = 100.0f;
	float angle = 90.0f;
	float angleInRadians = angle * (180 / PI);

	//Game Loop
	do
	{
		ClearScreen();
		float deltaT = GetDeltaTime();
		float x, y;
		if (angle >= 0)
		{
			/*xPos = xPos + sin(angle) * angle;
			yPos = yPos + sin(angle + (PI / 2)) * angle;*/
			x = (xPos +  (radius * cos(angle/radius)));
			y = yPos + (radius * sin(angle / radius));
			angle -= 1.0f;
			angleInRadians = angle * (180 / PI);

			cout << "degrees: " << angle << endl;
			cout << "radians: " << angleInRadians << endl;
			/*cout << "xpos: " << x << endl;
			cout << "ypos: " << y<< endl;*/
			//system("pause");
		}
		else
		{
  			angle = 0.0f;
			x = 0;
			y = 0;
		}

		MoveSprite(myTextureHandle, x, y);
		DrawSprite(myTextureHandle);
	} while (!FrameworkUpdate());

	Shutdown();

	return 0;
}
