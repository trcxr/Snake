# Assignment_AmanAhuja - Snake Game

## Overview
The game is a remake of the classic snake with some additional features.

## Scenes
The game consists of 2 scenes:
1. Menu Scene -
  The Menu Scene allows the player to start the game, while also showing the all time top score.
2. Game Scene -
  The Game Scene is where the player actually plays the game of Snake, completing objectives while also trying to get the highest score.

## Controls
1. The snake starts moving as soon as the game starts and will keep on moving in the same direction until the player triggers a direction change by using one of the direction control keys.
2. The player can control the direction of the head of the snake by using the 'W, A, S, D' to change to 'Up, Left, Down, Right' respectively.
3. The player cannot reverse the direction of the Snake, for example if the Snake is moving up, the player cannot press the 'Down(S)' key to make the snake go down.

## Obective
The objective of the game is to create the highest score by collecting the food items that spawn all while the snake is growing in size by 1 unit for each food item it eats.

## Gameplay
1. The game starts with the Snake moving in a particular direction, with 1 food item spawned on the map.
2. As and when the snake heads meets with the food, it is eaten and a new food item is spawned at a random location.
3. Different types of food items give different points and eating the same food item continously grants a point multiplier.
4. The Snake will die if its head touches its body sections, or the wall.
5. The more food the snake eats, the longer it grows in size. So plan accordingly.

## Food Items
Currently there are 2 food items in the game:
1. Red Food - Red food gives '15' points on being eaten.
2. Blue Food - Blue food gives '20' points on being eaten.

## Point Multiplier
The point multiplier is displayed on the top left of the screen. It starts with a value of 1.
The point multiplier also displays the food color for the current streak food item. Starts with a black color.
The point multiplier changes as the player progresses the streak of eating the same food item consecutively.
For Example:
* Player eats 'Red Food'    - Multiplier x1 - Points '1 x 15 = 15'  - Total Points  '  0 + 15 =  15'
* Player eats 'Red Food'    - Multiplier x2 - Points '2 x 15 = 30'  - Total Points  ' 15 + 30 =  45'
* Player eats 'Red Food'    - Multiplier x3 - Points '3 x 15 = 45'  - Total Points  ' 45 + 45 =  90'
* Player eats 'Red Food'    - Multiplier x4 - Points '4 x 15 = 60'  - Total Points  ' 90 + 60 = 150'
* Player eats 'Blue Food'   - Multiplier x1 - Points '1 x 20 = 20'  - Total Points  '150 + 20 = 170'
* Player eats 'Blue Food'   - Multiplier x2 - Points '2 x 20 = 40'  - Total Points  '170 + 40 = 210'
* Player eats 'Red Food'    - Multiplier x1 - Points '1 x 15 = 15'  - Total Points  '210 + 15 = 225'
* Player eats 'Red Food'    - Multiplier x2 - Points '2 x 15 = 30'  - Total Points  '225 + 30 = 255'

## Music
Music is taken from Freesound.org

## Video
A gameplay video is available on [YouTube](https://www.youtube.com/watch?v=5sCbNFI7nWc "3D Snake").

***More details will be updated as and when added to the game.***
