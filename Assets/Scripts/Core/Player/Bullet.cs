using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAfterSeconds", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (-1) * Speed * Time.deltaTime;
    }
    public void DestroyAfterSeconds()
    {
        GameObject.Destroy(gameObject);
    }
    public void SetSpeed(Vector3 playerSpeed)
    {
        Speed += playerSpeed.magnitude;
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(gameObject);
    }
}
