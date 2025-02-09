using UnityEngine;

public class TestManager : MonoBehaviour
{
    #region Singleton
    [HideInInspector] public static TestManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this) return;
        Instance = this;
        SetNewState(new GameStateStartGame());
    }
    #endregion
   
    #region Variables
    private IGameState _state;
    [SerializeField] public CardCollection DefaultCardCollectio;

    public bool IsPlayerTurn => _state is GameStatePlayerTurn;
    #endregion

    #region Logic
    public void SetNewState(IGameState newState)
    {
        _state = newState;
        _state.EnterState();
    }

    public void ExecuteStateLogic()
    {
        _state.StateLogic();
    }

    public void EndCurrentState()
    {
        _state.EndState();
    }
    #endregion

    #region Unity-API
    private void Update()
    {
        if(_state != null && _state.State == IGameState.GameState.Running)
        {
            _state.StateLogic();
        }
    }
    #endregion
}
