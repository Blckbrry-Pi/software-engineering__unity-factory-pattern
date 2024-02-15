using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenState: GameStateSingleton.IState
{
    public void Start()
    {
        // SceneManager.LoadScene("HomeScreen");
        Debug.Log("HomeScreen Start");
    }

    public GameStateSingleton.IState Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return new PlayState();
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            return new ExitState(this);
        } else
        {
            return this;
        }
    }

    public void Exit()
    {
        Debug.Log("HomeScreen Exit");
    }
}

