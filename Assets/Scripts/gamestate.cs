using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamestate : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameState state;
    public enum GameState
    {
        PressStart = 1,
        StartingPlay = 2,
        GamePlay = 3,
        Dying = 4,
        GameOver = 5,
        NextLevel = 6
    }
    private void Start()
    {
        state = GameState.PressStart;
    }
}
