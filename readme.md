# Summary
Prototype Escape Room is a basic 5-minute adventure with 2 puzzles. Players will have to use their wits as they discover a secret code and brave a dark maze. If players survive, they will be rewarded with a 3-second jingle and a feeling of self-satsifaction.


# How to Build
To build the game, open the project in Unity 2020.3.17f1. Make sure to download the following packages via Unity's Package Manager before attempting to build:
* Text Mesh Pro
* Probuilder

Open the "EscapeRoom" scene, navigate to "File>Build Settings" and click **Add open scenes**.  Choose "PC, Mac & Linux Standalone" as the platform and click **Build to Run**


#How to Play
Prototype Escape Room was built using Unity's new input management system. Currently, controls are set to mouse and keyboard:
* Mouse - Look
* WASD - Move
* Left-click - Interact

Other input devices can be easily added in the **PlayerControls** input action asset.


#Cheater's Guide
To solve the puzzle of the first room, pay attention to when the lights flicker. Listen for a light buzzing sound that continues, despite the rest of the lights being out. Near the sound, you'll be able to find the code illuminated when the other lights are out. The code is 589, but in future versions my be randomized.

To solve the second puzzle, follow the maze and find the three paper hints. Using these hints, you'll discover that you'll need to use your flashlight on a solar panel near the exit, holding the flashlight for five seconds at each panel in a particular order: top-right, bottom-right, bottom-left, top-left.