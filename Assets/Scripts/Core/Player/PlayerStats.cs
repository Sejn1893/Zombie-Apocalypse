using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float HP;
    private float _currentHP;
    public static bool IsDead;
    private Animator _anim;

    public HPBar HpBar;
    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
        _anim = gameObject.GetComponent<Animator>();
        _currentHP = HP;
        HpBar.SetMaxHealrt(HP);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void TakeDmg(float dmg)
    {
        if (IsDead)
            return;

        _currentHP -= dmg;
        HpBar.SetHealth(_currentHP);    
        if (_currentHP <= 0)
        {
            IsDead = true;
            _anim.SetBool("Death", true);
            


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Flask")
        {
            if (_currentHP != HP)
            {
                _currentHP = _currentHP +2f;
                HpBar.SetHealth(_currentHP);
                if (_currentHP > HP)
                {
                    _currentHP = HP;
                    HpBar.SetMaxHealrt(_currentHP);
                }
            }
            Destroy(other.gameObject);
        }

    }


}
