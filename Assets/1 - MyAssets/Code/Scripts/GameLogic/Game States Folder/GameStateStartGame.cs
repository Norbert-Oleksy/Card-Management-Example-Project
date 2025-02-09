
/// <summary>
/// Wczytuje deck.
/// Tasujemy nasz pocz¹tkowy deck.
/// Wyci¹gamy z decku X kart na rêkê.
/// </summary>
public class GameStateStartGame : IGameState
{
    public IGameState.GameState State { get; set; } = IGameState.GameState.Enter;

    public void EndState()
    {
        TestManager.Instance.SetNewState(new GameStatePlayerTurn());
    }

    public void EnterState()
    {
        Deck.Instance.LoadCardsToDeck(TestManager.Instance.DefaultCardCollectio.ListOfCards);
        State = IGameState.GameState.Running;
    }

    public void StateLogic()
    {
        if(Hand.Instance.IsDrawingCards) return;

        if (!Hand.Instance.IsHandFull()) Hand.Instance.FillHand();

        if (Hand.Instance.IsHandFull() || Deck.Instance.GetCardCount() == 0)
        {
            State = IGameState.GameState.End;
            EndState();
        }
    }
}
