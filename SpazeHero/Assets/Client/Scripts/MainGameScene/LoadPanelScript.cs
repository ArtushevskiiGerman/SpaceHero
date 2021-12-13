using System;
using UnityEngine;

public class LoadPanelScript : MonoBehaviour
{
    private void Awake()
    {
        PlayerHandler.PlayerDied += PlayerDied;
        gameObject.SetActive(false);
    }

    private void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        PlayerHandler.PlayerDied -= PlayerDied;
    }
}
