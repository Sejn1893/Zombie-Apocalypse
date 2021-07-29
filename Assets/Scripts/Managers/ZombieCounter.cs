using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCounter : MonoBehaviour
{
    private int _score = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        SetUpSingleton();
    }
    private void Update()
    {
        
    }
    private void SetUpSingleton()
    {
        int NumberOfZombieCounters = FindObjectsOfType<ZombieCounter>().Length;
        if (NumberOfZombieCounters > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetNumberOfZombiesKilled()
    {
        return _score;
    }
    public void AddToScore(int scoreValue)
    {
        _score += scoreValue;
    }
    public void ResetLevel()
    {
        Destroy(gameObject);
    }
}
