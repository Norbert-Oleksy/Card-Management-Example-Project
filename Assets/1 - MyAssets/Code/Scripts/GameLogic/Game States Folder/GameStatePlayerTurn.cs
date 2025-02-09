/// <summary>
/// Zagrywamy dowoln¹ iloœæ kart z rêki na stó³, po zagraniu ka¿da karta trafia na discard pile.
/// Koñczymy turê.
/// </summary>
public class GameStatePlayerTurn : IGameState
{
    public IGameState.GameState State { get; set; } = IGameState.GameState.Enter;

    public void EndState()
    {
        if (Deck.Instance.GetCardCount() > 0)
        {
            Hand.Instance.SetAllCardsInHandInteractive(false);
            TestManager.Instance.SetNewState(new GameStateDrawPhase());
        }else if (Hand.Instance.GetCardCount() > 0)
        {
            TestManager.Instance.SetNewState(new GameStatePlayerTurn());
        }else
        {
            TestManager.Instance.SetNewState(new GameStateEndGame());
        }
    }

    public void EnterState()
    {
        Hand.Instance.SetAllCardsInHandInteractive(true);
        State = IGameState.GameState.Running;
    }

    public void StateLogic()
    {
        if(Hand.Instance.GetCardCount() == 0)
        {
            State = IGameState.GameState.End;
            EndState();
        }
    }
}
