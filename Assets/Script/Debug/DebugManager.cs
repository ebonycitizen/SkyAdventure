using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameModeInDebugManager
{
    Normal,
    Debug,
}

public class DebugManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> disableGameObjectsInDebug;
    [SerializeField] private GameObject debugPlayer;

    private GameModeInDebugManager nowGameMode;
    private GameModeInDebugManager nextGameMode;

    // Start is called before the first frame update
    void Start()
    {
        nowGameMode = GameModeInDebugManager.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (nextGameMode == GameModeInDebugManager.Normal)
                nextGameMode = GameModeInDebugManager.Debug;
            else if (nextGameMode == GameModeInDebugManager.Debug)
            {
                nextGameMode = GameModeInDebugManager.Normal;
            }


        }

        if (nowGameMode != nextGameMode)
        {
            if (nextGameMode == GameModeInDebugManager.Normal)
            {
                ChangeToNormal();
                nowGameMode = nextGameMode;
            }
            else if (nextGameMode == GameModeInDebugManager.Debug)
            {
                ChangeToDebug();
                nowGameMode = nextGameMode;
            }
        }

        if (nowGameMode == GameModeInDebugManager.Normal)
        {

        }
        else if (nowGameMode == GameModeInDebugManager.Debug)
        {
        }

    }



    private void ChangeToDebug()
    {
        foreach (var VARIABLE in disableGameObjectsInDebug)
        {
            VARIABLE.SetActive(false);
        }

        debugPlayer.SetActive(true);
    }

    private void ChangeToNormal()
    {

        foreach (var VARIABLE in disableGameObjectsInDebug)
        {
            VARIABLE.SetActive(true);
        }

        debugPlayer.SetActive(false);
    }

}
