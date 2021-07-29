using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shooting : MonoBehaviour
{
    public float ShootInterval;
    public Transform Barrel;
    public GameObject Bullet;


    private AudioSource _shootAudio;
    private NavMeshAgent _agent;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.transform.root.gameObject.GetComponent<Animator>();
        _agent = gameObject.transform.root.gameObject.GetComponent<NavMeshAgent>();
        _shootAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("ShootingBullet", 0f, ShootInterval);
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
        }
    }
    public void ShootingBullet()
    {
        if (PlayerStats.IsDead)
            return;

        GameObject tmpBullet = Instantiate(Bullet, Barrel.position, Quaternion.identity);
        _shootAudio.Play();
        _shootAudio.pitch = 1f + Random.Range(0, 0.5f);







        tmpBullet.transform.up = Barrel.right;
        tmpBullet.GetComponent<Bullet>().SetSpeed(_agent.velocity);

        _animator.Play("Shoot", 1, 0);
        
    }
    
    
      
}
