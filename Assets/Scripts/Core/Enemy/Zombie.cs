using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public enum ZombieState 
    {
        patrol,
        chase,
        attack,
        dead,
        none
    }
    private ZombieState _zombieState;

    public List<Transform> PatrolPoints = new List<Transform>();

    private Animator _anim;
    private Transform _playerTransform;
    private PlayerStats _playerStats;
    private Transform _currentPoint;
    private NavMeshAgent _agent;

    public AudioSource ZombieSound;
    public AudioSource ZombieAttack;
    public AudioSource ZombieDie;
    public AudioSource ZombieHit;


    public float PatrolSpeed;
    public float ChaseSpeed;

    public float MinDmg;
    public float MaxDmg;

    private int HP;
    private int _currentHP;

    public HPBarZombie ZombieHP;
    

    // Start is called before the first frame update
    void Start()
    {
        

        _agent = gameObject.GetComponent<NavMeshAgent>();
        _playerTransform = GameObject.Find("Player").transform;
        _playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        _anim = gameObject.GetComponent<Animator>();

        _currentPoint = PatrolPoints[0];
        _agent.destination = _currentPoint.position;

        ZombieSound.volume = 0.8f;
        ZombieAttack.volume = 0.8f;
        ZombieDie.volume = 0.5f;
        ZombieHit.volume = 0.2f;

        HP = Random.Range(3, 6);
        _currentHP = HP;
        ZombieHP.SetMaxHPZombie(HP);
    }
    public bool isZombieDead()
    {
        if (_zombieState == ZombieState.dead)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isZombieDead() == true)
        {
            ZombieSound.volume = Mathf.Lerp(ZombieSound.volume, 0f, 5f* Time.deltaTime);
            return;
        }

        if (PlayerStats.IsDead)
        {
            _zombieState = ZombieState.patrol;
            _anim.SetBool("Attack", false);
            _anim.SetBool("Chase", false);
        }

        switch (_zombieState)
        {
            case ZombieState.patrol:

                _agent.speed = PatrolSpeed;
                _agent.destination = _currentPoint.position;

                if (Vector3.Distance(transform.position, _currentPoint.position) < 2.1f)
                {
                    _currentPoint = PatrolPoints[Random.Range(0, PatrolPoints.Count)];
                   
                }

                if (Vector3.Distance(transform.position, _playerTransform.position) < 10f && PlayerStats.IsDead == false)
                {
                    _zombieState = ZombieState.chase;
                    _anim.SetBool("Chase", true);
                }






                break;
            case ZombieState.chase:

                _agent.destination = _playerTransform.position;
                _agent.speed = ChaseSpeed;

                if (Vector3.Distance(transform.position, _playerTransform.position) > 12f)
                {
                    _zombieState = ZombieState.patrol;
                    _anim.SetBool("Chase", false);
                }


                /*if (Vector3.Distance(transform.position, _currentPoint.position) > 20f)
                {
                    _zombieState = ZombieState.patrol;
                    _anim.SetBool("Chase", false);
                }*/
                if (Vector3.Distance(transform.position, _playerTransform.position)< 2)
                {
                    ZombieAttack.Play();
                    _zombieState = ZombieState.attack;
                    _anim.SetBool("Attack", true);
                }


                break;
            case ZombieState.attack:

                transform.LookAt(_playerTransform.position);
                if (Vector3.Distance(transform.position, _playerTransform.position) > 3)
                {
                    if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
                    {

                        _zombieState = ZombieState.chase;
                        _anim.SetBool("Attack", false);
                    }
                }
                
                break;
            case ZombieState.dead:
                break;
            case ZombieState.none:
                break;
            default:
                break;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            _currentHP--;
            ZombieHP.SetHPZombie(_currentHP);
            ZombieHit.Play();

            if (_currentHP <= 0)
            {
                

                ZombieDie.Play();
                ZombieHP.GetComponentInParent<Canvas>().enabled = false;

                _agent.destination = transform.position;
                _agent.enabled = false;

                gameObject.GetComponent<Collider>().enabled = false;

                _anim.SetBool("Death", true);
                _zombieState = ZombieState.dead;

                FindObjectOfType<ZombieCounter>().AddToScore(1);


               

            }
        }
    }
    public void Hit()
    {
        if (Vector3.Distance(transform.position, _playerTransform.position) <2.5f)
        {
            _playerStats.TakeDmg(Random.Range(MinDmg, MaxDmg));
        }
    }
}
