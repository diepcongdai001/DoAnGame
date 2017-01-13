using UnityEngine;
using System.Collections;

public class BaseGameCTL : MonoBehaviour {

    public static BaseGameCTL Current;

    private EGameState _gameState;

    public EGameState GameState
    {
        get
        {
            return _gameState;
        }

        set
        {
            _gameState = value;
        }
    }

    void Awake()
    {
        Current = this;
        GameState = EGameState.PLAYING;
    }
}
