using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    private int _seconds = 0;

    private int n = 0;
    
    private int _minutes = 0;
    
    private Text _text;

    private bool playerAlive = true;

    private void Start()
    {
        _text = GetComponent<Text>();

        _text.text = "00:00";

        PlayerHandler.PlayerDied += PlayerDied;
    }

    private void FixedUpdate()
    {
        n++;

        if (n == 60)
        {
            _seconds++;
            n = 0;
        }
        
        GetTime();
    }

    private void PlayerDied()
    {
        playerAlive = false;
    }
    
    private void GetTime()
    {
        if (!playerAlive) return;
        
        _minutes = _seconds / 60;

        if (_minutes > 0)
        {
            _text.text = $"{GetMinutes(_minutes)}:{GetSeconds(_seconds)}";
        }
        else
        {
            _text.text = $"00:{GetSeconds(_seconds)}";
        }
    }

    private string GetSeconds(int seconds)
    {
        if (seconds - _minutes * 60 <= 9) return $"0{seconds - _minutes * 60}";
        else return $"{seconds - _minutes * 60}";
    }
    
    private string GetMinutes(int minutes)
    {
        if (minutes <= 9) return $"0{minutes}";
        else return $"{minutes}";
    }
}
