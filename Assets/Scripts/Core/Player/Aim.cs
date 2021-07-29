using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    Ray _cameraRay;
    RaycastHit _groundResult;
    LayerMask _groundLayer = 1 << 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.IsDead)
            return;

        _cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_cameraRay, out _groundResult,100f, _groundLayer))
        {
            if (Vector3.Distance(transform.position, _groundResult.point) > 1f)
            {
                transform.LookAt(_groundResult.point);
            }

            
        }
    }
}
