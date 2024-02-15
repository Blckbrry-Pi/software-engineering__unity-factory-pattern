using UnityEngine;

public class GameStateSingleton : MonoBehaviour
{
    public interface IState
    {
        public void Start();
        public IState Update();
        public void Exit();
    }

    private readonly static SingletonBase<GameStateSingleton> _instance = new();
    public static GameStateSingleton Instance => _instance.Instance;

    public IState CurrentState = new HomeScreenState();

    void Awake()
    {
        _instance.GetOrInitInstance(this);
        CurrentState.Start();
    }

    // Update is called once per frame
    void Update()
    {
        _instance.GetOrInitInstance(this);

        IState newState = CurrentState.Update();
        if (newState != CurrentState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Start();
        }
    }
}
