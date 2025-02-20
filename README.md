# Space Explorer

## **Overview**
"Space Explorer" is a 2D Unity game where players control a spaceship to navigate through space, complete specific objectives for each level, avoid asteroids, and collect stars to earn points. The game features three main scenes: **Main Menu**, **Gameplay**, and **End Game**, designed to showcase Unity's core features.

---

## **Game Features**
### 1. **Spaceship (Player)**
- A 2D spaceship controlled by the player.
- **Controls**:
  - **Movement**: WASD or arrow keys.
  - **Shoot Lasers**: Press `Enter` to fire lasers.
- **Functionality**: Move freely in space, destroy asteroids with lasers, and complete level objectives.

### 2. **Asteroids**
- Floating 2D objects moving randomly in space.
- **Functionality**:
  - Colliding with an asteroid deducts points.
  - If the spaceship collides with an asteroid, the game ends.

### 3. **Stars**
- Scattered throughout the scene as collectible items.
- **Functionality**: Collect stars to increase the player's score.

### 4. **Level Objectives**
- Each level has specific objectives that the player must complete, such as:
  - Collecting a certain number of stars.
  - Destroying a specific number of asteroids.
  - Reaching a checkpoint within the level.
- Once all objectives are completed, the level ends and the **total time taken** to complete the level is displayed.

---

## **Game Flow**
### 1. **Main Menu Scene**
- **Play Button**: Starts the gameplay scene.
- **Instructions Button**: Displays a panel with instructions for the game.

### 2. **Gameplay Scene**
- **Objective**: Control the spaceship, avoid asteroids, complete level objectives, and collect stars for points.
- **UI Elements**:
  - Real-time score display.
  - Level objectives tracker.
  - Timer to track time spent on the current level.
- **Game Over**: The game ends when the spaceship collides with an asteroid.

### 3. **End Game Scene**
- Displays the player's final total time taken.
- Provides options to return to the main menu or quit the game.

---

## **Setup Instructions**
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/space-explorer.git
   cd space-explorer
2. **Open in Unity**:
- Launch Unity Hub.
- Select Open Project and navigate to the cloned folder.

3. **Run the Game**:
- Open the Scenes/MainScene scene in Unity.
- Press the Play button in the Unity Editor to start the game.

## **Controls**
- Movement: Use WASD keys or arrow keys.
- Shoot Lasers: Press Enter.

## **Credits**
- Game developed as a Unity 2D learning project.
- Designed by: lingoyuo.
