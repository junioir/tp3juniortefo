using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _MaxHeath = 100;
    [SerializeField] private int _CurrentHealth;
    [SerializeField] HealthBar _HealthBar;

    void Start()
    {
        _CurrentHealth = _MaxHeath;
        _HealthBar.SetMaxHealth(_MaxHeath);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20); 
        }
    }

   public void TakeDamage(int damage)
    {
        _CurrentHealth -= damage;
        _HealthBar.SetHealth(_CurrentHealth);
    }
}
