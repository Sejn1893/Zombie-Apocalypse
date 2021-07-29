using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private Transform _player;
    ZombieCounter zombieCounter;
    
    public int ZombiesToKill;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        zombieCounter = FindObjectOfType<ZombieCounter>();
        

    }

    // Update is called once per frame
    void Update()
    {

        

        if (zombieCounter.GetNumberOfZombiesKilled() >= ZombiesToKill)
        {
            
            if ((Vector3.Distance(transform.position, _player.position) < 0.5f))
            {
                SceneManager.LoadScene(0);
            }
        }
        
            
        
    }
   
}
