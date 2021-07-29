using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPFlask : MonoBehaviour
{
    public float Speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, Speed * Time.deltaTime);
    }
    
}
