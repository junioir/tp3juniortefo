using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heathanddefent : MonoBehaviour
{
    [SerializeField] private int _health=100;

   public void ReceiveDamage(int damage)
    {
        _health -= damage;
        Debug.Log("health remaning is:" + _health);
    }

}
