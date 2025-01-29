# Survival Shooter

## Project Description
This is an arcade-style 3D third-person shooter game built using Unity. Players compete for the highest score by surviving against waves of enemies, utilizing power-ups and crowd control to stay alive. The game takes place in a thematic "nightmare" environment.

## Asset Usage
This project incorporates animations, models, and AI behaviors from Unity’s Asset Store and external libraries (primarily pulling from a 3rd person shooter tutorial). While these assets were not created from scratch, integrating work from other locations allowed for faster development and produced a more polished end product.

## Key Features
- **Game Mechanics**: Waves of increasing difficulty spawn continuously so that no player can survive forever. At the same time, power-ups spawn in hidden set locations randomly, building up over time to give players an edge.
- **Player Mechanics**: Players are able to smoothly move across the map, directing enemies advancement towards them. Through mouse-clicks the player can aim and shoot, killing enemies and increasing their score. 
- **Enemies**: 3 different enemy models with varying animations and 2 different stat blocks appear in-game. Enemy behavior is universally zombie-like pursuing after the player.
- **Power-Ups**: 3 different power ups allow the player to increase their damage, their fire rate, and their speed temporarily. 
- **Visuals and Audio**: The game uses high-quality premade models, animations, and particle effects to give a polished feel. Sounds and music were similarly sourced to prevent boring silent gameplay.
- **Arcade-Style**: After their health drops to zero, the player is given a score which is compared to the locally stored hi-score. Shortly after, the scene is reloaded and the player is given the opportunity to play again.

## Setup Instructions
---
### Running the Game
1. Clone the repository.
2. Open the FinishedBuild folder and run the .exe file
3. Enjoy!

### Running the Project
1. Clone the repository.
2. Ensure all necessary build supports are installed
3. Open the project in Unity (version 2021.3.1f1 recommended)
4. Explore!


## Learning Journey
- **Inspiration**: This game was inspired by a 3rd person shooter tutorial in Unity and my own love of arcade style zombies modes in Call of Duty Games. In particular the desire to give different weapon feels through power-ups and a sense of never-ending difficulty came from these games.
- **Impact**: This project serves as a fun way to entertain and engage users. It allows players to compete with each other taking turns playing and seeing who can do the best. In future itterations, I would love to entertain more people by giving more environments and features to keep gameplay dynamic and fresh.
- **Technology Learned**: I learned a large deal of medium to small things about Unity through this development process, these include:
  - Utilizing premade assets by setting up animation controllers, scripting particle usage, and ensuring proper and seamless integration.
  - Converted imported models into prefabs for efficient usage in spawning.
  - Dealing with a large base of scripts and models and organizing internal folders accordingly.
  - Using Unity’s version control system with Git for the first time to manage changes.
- **Why This Technology**: Learning how to utilize high-quality outside assets allowed me to increase the overall quality of the game. Additionally, Git is a tool I continue to use more and more frequently, learning it for Unity is a natural extension of my current skills and will likely help me with version control in the future. Lastly learning large project management and Unity's built in prefab and animation systems was essential for creating the product I desired.
- **Challenges**:
  - Learning all of my previously listed technologies was the most difficult part of this project, however the process of encountering difficulties allowed me to grow more confident in my understanding of these systems.
  - Balancing the game to be fun was difficult as super easy enemies were boring and super difficult enemies were frustrating. The inclusion of power-ups made the game feel viable even as difficulty ramped up and also increased the strategy. Working through this problem really helped me to consider user experience and how playing the game actually felt.
  - I had several issues related to file version in the late-stage of my development. The confusion ultimately led to me temporarily deleting my entire codebase. The pain and stress of this taught me the undeniable importance of regular backups and clear file structure. Additionally, it has given me an idea of pre-creating a file structure so that I am not forced to shift the general format later on.

## Screenshots & Demo


## Application
[The Finished Build](./FinishedBuild)


