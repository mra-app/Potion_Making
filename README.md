# Potion_Making
3D computer game

<a name="header1"/>

## Game Description (Brief)
"Potion making" is a first person puzzle 3D game that is a made with unity the goal of being relaxing and rewarding. In this section, the gameplay from  start to finish is described.

The game begins with the game menu, which allows the user to choose which level to play.
This game has two different levels and the player can quit or restart the level at any time with the Q and R keys, respectively.
The first level's goal is to collect ingridents for the potion that will be made in the second level.
In the first level, the player starts the game in the middle of a maze in a garden next to a small room in which there is a cauldron inside and must collect the items shown in a list at the top of the screen in the garden. There are four types of items in total, and they are randomly spawned on the walls and inside the maze. The player cannot jump over the walls to catch the items, so he has to use magic to bring them close when the item is not too far away. When an item collides with the player, the number of items in the list will be updated, and when there are enough items, the item line will have a check mark next to it. When all the items have a check mark, the player can go back to where he started and by colliding with the cauldron (if he has enough items), he will be sent to the next level. If he did not collect enough items, the Game Over panel will appear, and he can use the replay key on the keyboard to play again.

The second level starts in a room with a boiling potion and the collected items in level1, and the goal is to follow the instructions to make a potion. The instruction consists of adding any of the four items to the potion, stirring the pot, and hitting the oven as the last step. When the player hits the oven, the potion is finished and if the steps done by the player were exactly the same as the instructions, the potion is created successfully and the player wins the game. Otherwise the player loses and can use the replay key on the keyboard to try again.

<a name="header2"/>

## Comparing the game with games in the course

This game might look similar to dread halls because of the maze, but in this game there is a list of items to be collected instead of a single coin, and they must be collected using a magic spell and the player cannot walk to them all the time.
It is similar to portals for having a FPS character with a weapon, but in this game, the player uses a magic wand to do different magic spells instead of using a gun to create portals in the walls.
This game has a second level in which it is completely different from these games. In general it is not similar to portals or dread halls in other aspects which are explained in detail in other parts of this text.

<a name="header3"/>

## game Complexity and features

There are two different goals to achieve in this game: in level1 it is collecting items in a maze and reaching the game finish point afterward, and in level2 it is doing a set of instructions in the correct order to win the game. 
In level1 the player can walk around and use the mouse to collect items which moves the items closer to him, but in level2 the player can only look around and use the mouse to achieve the goal and clicking plays a different animation for each item. in this level
Different animations and suitable sound effects were chosen for each move. in order to give the user a new experience each time he plays the game, each level is randomized in every run, including: in level1, the number of items from each item type to collect and the distribution of items in the garden and the maze structure, in level2 the instructions order.
Casting a spell is implemented using the observer pattern and each item is registered on the list of items which have a similar function that is called when a spell is cast and only the items in a specific distance will react to it.

<a name="header4"/>

## Technical Game Description 
This game consists of three different scenes: menu, level1, and level2. To make the game easy to win, small number of steps and items were chosen, such as number 4 for the types of items to collect and number 7 for the steps in the instructions. This makes it a relaxing and rewarding game. The technical details of each scene, which were not previously discussed, are explained in this section.

### 1-Menu
The game starts with the menu. There is a boiling potion in this scene. It uses particle effect to simulate smoke, and the fire under the cauldron has an animation to show natural changes of light intensity in a fireplace.
To display the instructions and the buttons, unity UI is used. The buttons change the scene to the first and second levels. The user can quit the menu using the Q key on the keyboard. The soundtrack playing in this scene is biiansu_by_light on the zapsplat website. The 3D items in this scene were created by ProBuilder.

### 2- Level 1 (collecting the ingredients)
The first level starts in the middle of a garden next to trees and a small room which was made by ProBuilder. The room contains a cauldron with a collider, and it triggers the game finish with different sound effects for win or lose. It also displays a panel using unity UI and if the user has won, the next scene will be displayed using a coroutine to delay it for a few seconds.
The items to be collected are spheres in different colors.
The list of items and the plus mark in the middle of the screen, which is used for targeting while casting a spell, are displayed using unity UI. 
 Every time the user clicks, all items are checked and items close enough to the player and the middle of the screen start to move towards him. Every time a spell is cast, the hand holding the wand shakes with animation and a sound effect is played. The items move towards the player with an animation and a sound effect. When an item collides with the player, it will be added to the item count in the list.
 A maze is generated randomly in each run to change the structure of the garden every time. It uses levelgenerator script which was used in dread halls with some changes. The items are randomly spawned on and around the walls and their color is chosen at random.
 To make it difficult to see the items in the distance, fog is used, and to make it harder to collect the items, only items close enough to the user can be collected with a spell.
 The item list is made with UI and shows random numbers for each type of item to collect, as the goal of the game. Each line has a checkbox that will be checked when enough items are collected, so the player won't have to constantly compare the numbers in the list. he will also have a sense of achievement when enough items are collected.
 In this level, the soundtrack is kulluh_Rise on the zapsplat website, and it will continue in the next level using DontDestroyOnLoad script. nature sounds sound effect is playing on loop to simulate a real garden.

### 3- Level 2 (making the potion)
The second level takes place is a room with the cauldron and items from the first level. A randomly generated list of 7 steps instructions using Unity UI is shown as the goal to achieve. The player cannot walk through the scene, but like the first level, he can select items with the wand, and instead of attracting the item towards the player, a specific animation and soundtrack will be played: Each item has an animation that will move it inside the cauldron with a water splashing sound effect. The spoon moves in a circle and has a metal sound effect, and the oven will trigger the game finish.
The order of selecting items and the spoon is checked with the instructions, and a panel is shown with different final potion colors and different sound effects for win and lose.
 The soundtrack in this level is the same as level 1 and if the game is started after winning level1, the soundtrack will continue playing from where it stopped. The boiling water sound effect is on loop to simulate the boiling of the potion in this level.

<a name="header5"/>

## Assets Credits:

Soundtracks: music_biiansu_by_light_011.mp3 and music_kulluh_Rise_004.mp3 from www.zapsplat.com

Sound effects from www.zapsplat.com

potion game icon and menu and UI wooden art from www.freepik.com

3D art Fist club by Wolfgang Wozniak from www.opengameart.org

Richard Samuels font from www.dafont.com


This game's idea was based on Harry Potter Accio spell and advanced potion making book.



