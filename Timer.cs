using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float _lastCheckedTimeStamp = 0f;
    private float _timePassed = 0f; //only updated when function calls are made
    private float _timeSpeed = 1f;
    private bool _paused = false;

    public float timeSpeed { get { return _timeSpeed; } }
    public bool paused { get { return _paused; } }

    public void Start()
    {
        _lastCheckedTimeStamp = Time.time;
        _timePassed = 0f;
        _paused = false;
    }

    public void Pause()
    {
        _timePassed += (Time.time - _lastCheckedTimeStamp) * _timeSpeed;
        _lastCheckedTimeStamp = Time.time;
        _paused = true;
    }
    
    public void Unpause()
    {
        if (!_paused) 
        {
            return;
        }

        _lastCheckedTimeStamp = Time.time;
        _paused = false;
    }

    public void Stop()
    {
        _timePassed = 0f;
        _lastCheckedTimeStamp = Time.time;
        _paused = true;
    }

    public float GetTime()
    {
        if (_paused)
        {
            return _timePassed;
        }

        _timePassed += (Time.time - _lastCheckedTimeStamp) * _timeSpeed;
        _lastCheckedTimeStamp = Time.time;
        return _timePassed;
    }

    public void SetTimeSpeed(float timeSpeed)
    {
        if (!_paused)
        {
            _timePassed += (Time.time - _lastCheckedTimeStamp) * _timeSpeed;
        }
        _lastCheckedTimeStamp = Time.time;
        _timeSpeed = timeSpeed;
    }

    public void SetTime(float time)
    {
        _lastCheckedTimeStamp = Time.time;
        _timePassed = time;
    }
}