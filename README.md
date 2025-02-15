# Card-Management-Example-Project
Recruitment task

## Video
The video shows how the application works in practice

[Watch video](https://youtu.be/XkmAaP16a20)

## Quick Overview
Cards are drawn from the Deck into the hand.<br>
Use the mouse to drag a card from your hand.<br>
Drop a card over the table to put it there.<br>
Press the "End the turn" button to end your turn.<br>
The game ends when there are no more cards to play.<br>

## Task
### Task flow
1. Shuffle our starting deck.
2. Draw X cards from the deck to hand.
3. Play any number of cards from the hand to the table; after playing, each card goes to the discard pile.
4. End the turn.
5. Draw Y cards, so that at the start of the turn there are always X cards in hand.
6. Go to step 3.
### Required functionality
- ✅ Create structures representing a card and a deck of cards
- ✅ Display cards in hand
- ✅ Play cards (drag & drop)
- ✅ Draw cards after the turn ends
### Optional functionality
- ✅ Dragging cards between slots in hand (changing card order)
- ✅ Animations for playing cards
- ✅ After dropping a card (but not playing it), the card should return to its last position in hand
- ✅ Highlight the currently selected card (e.g., show a frame/animate the card when hovered over)

## Project
### Project Structure
```
1 - MyAssets
├── Code
│   ├── Animation
│   │   ├── MoveCardAnimation.cs
│   │   └── SelectCardAnimation.cs
│   ├── Interfaces
│   │   ├── ICardAnimation.cs
│   │   ├── IDisplayInfo.cs
│   │   ├── IGameState.cs
│   │   └── IProduct.cs
│   ├── ScriptableObjects
│   │   └── CardCollection.cs
│   └── Scripts
│   │   ├── CardSystem
│   │   │   ├── Card.cs
│   │   │   ├── CardAnimator.cs
│   │   │   ├── CardsContainer.cs
│   │   │   ├── Deck.cs
│   │   │   ├── DiscardPile.cs
│   │   │   ├── Hand.cs
│   │   │   └── Table.cs
│   │   ├── GameLogic
│   │   │   ├── Game States Folder
│   │   │   │   ├── GameStateDrawPhase.cs
│   │   │   │   ├── GameStateEndGame.cs
│   │   │   │   ├── GameStatePlayerTurn.cs
│   │   │   │   └── GameStateStartGame.cs
│   │   │   └── TestManager.cs
│   │   ├── UI
│   │   │   └── EndTurnBtnScript.cs
│   │   └── Draggable.cs
├── Data
│   └── DefaultCardCollection.asset
├── Prefabs
│   ├── Cards
│   │   ├── CardPrefab_Activate.prefab
│   │   ├── CardPrefab_All out attack.prefab
│   │   ├── CardPrefab_Attack.prefab
│   │   ├── CardPrefab_Double Attack.prefab
│   │   ├── CardPrefab_Hard Skin.prefab
│   │   ├── CardPrefab_Shield up.prefab
│   │   └── CardPrefab_Sub-zero.prefab
│   ├── UI
│   │   ├── Deck Attack.prefab
│   │   ├── Discard pile Skin.prefab
│   │   ├── Hand up.prefab
│   │   └── Table-zero.prefab
│   └── CardPrefab.prefab
├── Scenes
│   └── TestScene.unity
└── Settings
```
### How It Works
The task takes place in a scene called `TestScene`.<br>
The `TestManager` initializes the first game state, `GameStateStartGame`.<br>
The basic set of cards is loaded, and the deck is shuffled.<br>
The hand draws cards. The `Hand` script defines a fixed limit for the number of cards a hand can hold. It only draws as many cards as there is space for.<br>
Once this process is complete, the game enters the GameStatePlayerTurn state.<br>
#### Player Turn
In this state, the player has full control. They can use the mouse to interact with the cards or end their turn by pressing the "End the turn" button.<br>
Hovering over a card triggers an animation controlled by `CardAnimator`. The card is highlighted and begins to move up and down.<br>
Each card has a `Draggable` script, which allows it to be moved with the mouse and handles drag logic.<br>
Moving a card over another card swaps their positions in the hand.<br>
Dropping a card outside of valid areas returns it to the hand.<br>
Dropping a card on the table moves it there. The `Table` script automatically transfers played cards to the discard pile.<br>
The `DiscardPile` keeps track of discarded cards and removes them from the scene.<br>
#### Turn End & Game Flow
A player's turn ends when they use all available cards or press the "End the turn" button.<br>
The game then transitions to the `GameStateDrawPhase`, where new cards are drawn into the player's hand.<br>
If the player still has playable cards, the game returns to `GameStatePlayerTurn`. Otherwise, it proceeds to `GameStateEndGame`.<br>
In `GameStateEndGame`, the game simply ends, and no further actions are available.<br>

## Used
- Unity (version 6000.0.26f1)
- [DOTween (HOTween v2)](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)
- Images of the cards provided to me (not available in the repository)
