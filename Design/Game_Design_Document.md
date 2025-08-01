# 📘 Game Design Document: _Your Game Title_

---

## 🎯 1. Game Overview
- **Title**: Pie Alley
- **Genre**: Arcade, 2D
- **Platform(s)**: PC, WebGL, Android, iOS
- **Target Audience**: Casual gamers
- **Elevator Pitch**: Break blocks in the sky and collecting the falling pies in order to ship them for love and profit.

---

## 🕹️ 2. Gameplay Summary
- **Core Loop**:
  - The player uses a ball to break blocks, revealing different pies. As the pies fall from these blocks, the player must collect them, then load them on to shipping trucks.
- **Win/Lose Conditions**:
  - Player wins the stage when:
    - They've broken all the boxes and collected and shipped enough pies to satisfy stage goals (i.e. ship 30 apple pies and 10 pumpkin pies, or ship $2000 worth of pies)
  - Player loses the stage when:
    - They've broken all the boxes, but not shipped enough pies to meet stage goals
    - They've let their block break ball drop too many times
- **Key Mechanics**:
  - Movement
    - Player moves character left and right to reflect the ball used to break blocks and catch falling pies
  - Inventory
    - Keep a count of each pie collected during the stage
    - Number of pies remaining for each shipping truck
    - Count of total pies shipped for each type
    - Sum of total dollar value for all pies shipped
    - Count of balls remaining for the stage

---

## 🎮 3. Controls & Interface
- **Input Method**: (Keyboard/mouse, gamepad, touch)
- **Control Scheme**:
  ```
  A – Move left
  D - Move right
  Left Click – Launch ball / Load truck
  Space Bar - Launch ball / Load truck
  Mouse - Move left / right
  Touch Slide - Move left / right
  Touch Tap - Launch ball / Load truck
  ```
- **UI Elements**:
  - Balls remaining
  - Count of pie types shipped / collected
  - Sum dollar value of pies shipped
  - Stage goals (i.e. pies to ship, money to make)

---

## 🌍 4. World & Level Design
- **Setting / Theme**: Player character is outdoors on a paved surface, while boxes float in the air against a sky background. The stages can vary, but should be open air and lighthearted. 
The CEO gives directives from his office, at the top of a large grey corporate building. These scenes should also be lighthearted to contrast with the CEO's communication style of yelling directives and being proud of his decision making.
- **Level Structure**: Linear
- **Example Levels**:
  - Level 1: Tutorial zone with minimal challenge. Break a few blocks and collect slow falling pies. 1 type of pie with a low shipping target. 
  - Level 2: Different box layouts, slightly increased shipping goals.
  - Level 5: Introduce shipped value goal.
  - Level 6 - 10: Increasing shipped value goals.
  - Level 11: Introduce a different type of pie and pie shipping goals
  - Level 12 - 20: Varied pie shipping and shipped value goals, varied box layouts.

---

## 👤 5. Characters
- **Player Character**:
  - Name: TBD
  - Role: Break boxes to reveal pies. Collect pies and load shipping trucks
  - Abilities: See various power-ups
- **Enemies**:
  - none?
- **NPCs**:
  - CEO: Presents stage challenges

---

## 🎨 6. Art & Style
- **Visual Style**: Vector
- **Mood Board / References**:
  - [Link to references or concepts]
- **Asset List**:
  - Character sprites
    - Player character
    - Pies
    - Ball
    - Trucks
    - CEO
    - Boxes
  - Backgrounds
  - UI icons

---

## 🔊 7. Audio
- **Music**:
  - Different music for each level
    - A level might have a theme, i.e. Halloween or Christmas
- **Sound Effects**:
  - Player actions
  - UI
  - Environment
    - Box breaking
    - Ball bouncing off walls
    - Ball bounding off paddle
    - Pies collected
    - Pies hitting ground
    - Pies loaded on truck
    - Truck closing door, driving away
    - New truck appearing

---

## ⚙️ 8. Technical Design (Optional)
- **Engine**: Unity
- **Code Architecture**: High-level overview of core systems
- **Save System**:
  - Save level completion progress and best stats

---

## 📅 9. Production Plan
- **Milestones**:
  - Prototype → Alpha → Beta → Launch
- **Team Roles**:
  - Designer: Mike Chin
  - Programmer: Mike Chin
  - Artist: Mike Chin?
- **Tools**: GitHub

---

## 🧪 10. Known Risks & Questions
- Is the procedural generation too complex?
- Will art style scale to mobile?
- How will we market this?
