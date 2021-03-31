using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSinceStartGame : MonoBehaviour
{
    private float _startTime;
    private float _endTime;
    
    public void StartTimer()
    {
        _startTime = Time.time;
    }
    
    public float GetGameTime()
    {
        if (_endTime == 0)
            _endTime = Time.time - _startTime;
        return _endTime;
    }
    
}
