# Card management system 🃏

> **A core framework for Trading Card Games (TCG) featuring a Finite State Machine (FSM) architecture, drag & drop mechanics, and DOTween animations.**

---

### 🔗 Links
[🎬 Watch demo (YouTube)](https://youtu.be/XkmAaP16a20)

---

### 📝 About
**Card management system** is a robust implementation of core card game mechanics designed in Unity. The project simulates a complete gameplay loop, from deck shuffling and drawing cards to managing a player's hand and playing cards onto the table.

The system focuses on **modularity** and **user experience**, featuring smooth procedural animations for card interactions and a strict separation of game logic from visual presentation.

### ✨ Key features
* **Advanced hand management:**
    * Dynamic card slots with support for reordering (swapping positions).
    * Automatic card drawing logic based on hand capacity limits.
    * Visual feedback: Hover scaling and highlighting animations.
* **Drag & drop system:**
    * Physics/UI-based `Draggable` logic allowing cards to be played on the table.
    * "Return to hand" safety mechanic if a card is dropped in an invalid area.
* **Card lifecycle:**
    * Full cycle implementation: **deck** -> **hand** -> **table** -> **discard pile**.
    * Automatic cleanup of played cards.
* **Game flow:**
    * Turn-based system with distinct phases (start, draw, play, end).

### ⚙️ Technical highlights

The project is structured around clean code principles, utilizing **Interfaces** and **Design Patterns** to ensure scalability.

#### 🏗️ Architecture: Finite state machine (FSM)
The Game Loop is not hardcoded into a single manager but is driven by a flexible **State Pattern** (implementing `IGameState`).
* **GameStateStartGame:** Initializes the deck and shuffles `CardCollection`.
* **GameStateDrawPhase:** Handles drawing logic, ensuring the hand is refilled to the target count (X) at the start of the turn.
* **GameStatePlayerTurn:** Unlocks input, allowing the player to drag cards, interact with the board, or end the turn manually.
* **GameStateEndGame:** Handles the win/loss condition (e.g., deck empty).

#### 🧩 Interface-based design & SOLID
The code relies on interfaces to decouple systems, making the project easy to extend.
* `ICardAnimation`: Abstracts visual behavior, allowing different card types to have unique animations without changing the core `CardAnimator`.
* `IGameState`: Standardizes how the `TestManager` switches between game phases.
* `IDisplayInfo`: Ensures UI elements display data uniformly.

#### 🗃️ Data management (ScriptableObjects)
Card data is strictly separated from logic using **ScriptableObjects** (`CardCollection`). This allows designers to balance the game and add new cards via the Inspector without touching the codebase.

#### 🎨 Procedural animations (DOTween)
Instead of static transitions, the project uses **DOTween** for fluid visuals:
* **Hover effects:** Cards scale up and float (`SelectCardAnimation.cs`).
* **Movement:** Smooth transitions when drawing cards or returning them to hand (`MoveCardAnimation.cs`).

### 🕹️ Controls
* **Drag & drop:** Move cards from Hand to table to play them.
* **Drag in hand:** Reorder cards within your hand.
* **End turn button:** Manually finish the current turn.

### 🛠️ Used
* Unity 6 (6000.0.26f1)
* DOTween (HOTween v2)
