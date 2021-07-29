using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawner : MonoBehaviour
{

    public List<GameObject> ZombiePrefab;
    public List<Transform> PatrolPoints = new List<Transform>();

    private Zombie _currentZombie;
    private Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        SpawnZombie();

        Renderer[] _allRenderers = gameObject.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < _allRenderers.Length; i++)
        {
            _allRenderers[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentZombie.isZombieDead() == true)
        {
            if (transform.position.z + 12 < _player.position.z)
            {

                SpawnZombie();
            }
        }
    }
    public void SpawnZombie()
    {
        GameObject tmpZombie = Instantiate(ZombiePrefab[Random.Range(0, ZombiePrefab.Count)]);
        Vector3 spawnPos = PatrolPoints[Random.Range(0, PatrolPoints.Count)].position;
        tmpZombie.GetComponent<NavMeshAgent>().Warp(spawnPos);

        tmpZombie.GetComponent<Zombie>().PatrolPoints = PatrolPoints;
        _currentZombie = tmpZombie.GetComponent<Zombie>();
    }
}
