using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform _playerTrans;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        _playerTrans = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = _playerTrans.position + offset;
        transform.position = Vector3.Lerp(transform.position, _playerTrans.position + offset, 5f * Time.deltaTime);
        
    }
}
