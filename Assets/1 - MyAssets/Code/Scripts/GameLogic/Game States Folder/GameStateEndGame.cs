/// <summary>
/// There are no more cards to play with
/// </summary>
public class GameStateEndGame : IGameState
{
    public IGameState.GameState State { get; set; } = IGameState.GameState.Enter;

    public void EndState()
    {
        throw new System.NotImplementedException();
    }

    public void EnterState()
    {

    }

    public void StateLogic()
    {
        throw new System.NotImplementedException();
    }
}
