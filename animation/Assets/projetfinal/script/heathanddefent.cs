using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heathanddefent : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    //[SerializeField] private Animator animator;

    public void ReceiveDamage(int damage)
    {
        _health -= damage;
       
        Debug.Log("health remaning is:" + _health);

        if (_health==0)
        {
            //   animator.SetBool("die", true);
            Debug.Log("enemy mort");
        }

    }

}