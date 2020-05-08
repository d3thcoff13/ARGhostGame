using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    static int playerCount;
    [SerializeField]
    static GameObject[] players;
    static int turnPlayer;
    static public int turnCount;

    private void Awake()
    {
        DontDestroyOnLoad(GameManager.Instance);
        SceneManager.sceneLoaded += onSceneLoaded;
    }

    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       //create players
    }
    static void NextTurn()
    {
        turnCount++;
        if (turnPlayer == players.Length) turnPlayer = 0;
        else turnPlayer++;
    }

    public static void setPlayerCount(int count)
    {
        playerCount = count;
    }
}

