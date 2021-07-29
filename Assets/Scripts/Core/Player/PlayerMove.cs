using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");

        _animator.SetFloat("Forward", forward);
        _animator.SetFloat("Side", side);
    }

    private void OnAnimatorMove()
    {
        _agent.velocity = _animator.deltaPosition / Time.deltaTime;
    }

}
