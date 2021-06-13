using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState State;
    private void OnEnable()
    {
        State = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDisable()
    {
        State = null;
    }
}
