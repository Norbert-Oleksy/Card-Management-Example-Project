
public interface IGameState
{
    GameState State { get; set; }
    void EnterState();
    void StateLogic();
    void EndState();

    public enum GameState
    {
        Enter,
        Running,
        End,
    }
}