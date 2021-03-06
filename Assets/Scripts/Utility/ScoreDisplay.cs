using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text _scoreText;
    ZombieCounter zombieCounter;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        zombieCounter = FindObjectOfType<ZombieCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = zombieCounter.GetNumberOfZombiesKilled().ToString();
        
    }
}
