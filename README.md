# Card-Management-Example-Project
Recruitment task

## Video
The video shows how the application works in practice

[Watch video](https://youtu.be/XkmAaP16a20)

## Quick Overview
Cards are drawn from the Deck into the hand.

Use the mouse to drag a card from your hand.

Drop a card over the table to put it there.

Press the "End the turn" button to end your turn.

The game ends when there are no more cards to play.

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
### To Be continued
WIP
## Used
- [DOTween (HOTween v2)](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)
- Images of the cards provided to me (not available in the repository)
