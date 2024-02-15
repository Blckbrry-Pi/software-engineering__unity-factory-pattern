using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitState: GameStateSingleton.IState
{
    public GameStateSingleton.IState PrevStateInCaseOfQuitFailure;

    public ExitState(GameStateSingleton.IState prevState)
    {
        PrevStateInCaseOfQuitFailure = prevState;
    }
    
    public void Start()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public GameStateSingleton.IState Update()
    {
        return PrevStateInCaseOfQuitFailure;
    }

    public void Exit()
    {
        Debug.Log("Exiting failed, returning to previous state");
    }
}

