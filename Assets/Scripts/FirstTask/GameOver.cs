using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject fighters;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject timeSinceStartGame;

    private bool _isRed;
    private bool _isBlue;
    private Text _text;
    private TimeSinceStartGame _timer;

    private void Start()
    {
        _timer = timeSinceStartGame.GetComponent<TimeSinceStartGame>();
        _text = panel.transform.GetChild(0).GetComponent<Text>();
        _isBlue = true;
        _isRed = true;
    }

    private void Update()
    {
        if (fighters.activeSelf)
        {
            Check();
        }
        if (_isBlue == false)
        {
            fighters.SetActive(false);
            panel.SetActive(true);
            panel.GetComponent<Image>().color = Color.red;
            TimeSpan time = TimeSpan.FromSeconds(_timer.GetGameTime());
            _text.text = "Win Red Team\n" + 
                         time.ToString("hh':'mm':'ss");
        }
        if (_isRed == false)
        {
            fighters.SetActive(false);
            panel.SetActive(true);
            panel.GetComponent<Image>().color = Color.blue;
            TimeSpan time = TimeSpan.FromSeconds(_timer.GetGameTime());
            _text.text = "Win Blue Team\n" + 
                         time.ToString("hh':'mm':'ss");
        }
    }

    /// <summary>
    /// check red and blue tag who destroy
    /// </summary>
    private void Check()
    {
        _isBlue = false;
        _isRed = false;
        for (int i = 0; i < fighters.transform.childCount; i++)
        {
            if (fighters.transform.GetChild(i).CompareTag("Red"))
            {
                _isRed = true;
            }

            if (fighters.transform.GetChild(i).CompareTag("Blue"))
            {
                _isBlue = true;
            }
        }
    }
}
