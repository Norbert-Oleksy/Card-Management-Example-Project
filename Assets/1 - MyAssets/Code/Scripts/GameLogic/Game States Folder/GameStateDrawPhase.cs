
public class GameStateDrawPhase : IGameState
{
    public IGameState.GameState State { get; set; } = IGameState.GameState.Enter;

    public void EndState()
    {
        if (Hand.Instance.GetCardCount() > 0)
        {
            TestManager.Instance.SetNewState(new GameStatePlayerTurn());
        }else
        {
            TestManager.Instance.SetNewState(new GameStateEndGame());
        }
    }

    public void EnterState()
    {        
        if(Deck.Instance.GetCardCount() == 0)
        {
            State = IGameState.GameState.End;
            EndState();
            return;
        }
        State = IGameState.GameState.Running;
    }

    public void StateLogic()
    {
        if (Hand.Instance.IsDrawingCards) return;

        if (!Hand.Instance.IsHandFull()) Hand.Instance.FillHand();

        if (Hand.Instance.IsHandFull() || Deck.Instance.GetCardCount() == 0)
        {
            State = IGameState.GameState.End;
            EndState();
        }
    }
}
