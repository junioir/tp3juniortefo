using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int _MaxHeath = 100;
    public int _CurrentHealth;
    public static PlayerHealth _Instance;
    [SerializeField] private int _InvincibilityFlashDelay;
    [SerializeField] private float _InvincibilityTimeAfterHit = 3f;
    [SerializeField] private bool _Isinvincible = false;
    [SerializeField] HealthBar _HealthBar;
    [SerializeField] private MeshRenderer _graphics;

    private void Awake()
    {
        if (_Instance != null)
        {

            Debug.Log("The is more player instance in the scene");
            return;
        }
        _Instance = this;
    }
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
    public void HealPlayer(int amount)
    {
        if ((_CurrentHealth + amount) > _MaxHeath)
        {
            _CurrentHealth = _MaxHeath;
        }
        else
        {
            _CurrentHealth += amount;
        }

        _HealthBar.SetHealth(_CurrentHealth);
    }
    public void TakeDamage(int damage)
    {
        if (!_Isinvincible)
        {
            _CurrentHealth -= damage;
            _HealthBar.SetHealth(_CurrentHealth);
            _Isinvincible = true;
            StartCoroutine(Invencibility());
            StartCoroutine(InvicibiltyDelay());
        }
    }

    public IEnumerator Invencibility()
    {
        if (_graphics == null)
        {
            Debug.LogError("MeshRenderer n'est pas assigné.");
            yield break;
        }

        Material material = _graphics.material;
        while (_Isinvincible)
        {
            material.color = new Color(1f, 1f, 1f, 0f); 
            yield return new WaitForSeconds(_InvincibilityFlashDelay);

            material.color = new Color(1f, 1f, 1f, 1f); 
            yield return new WaitForSeconds(_InvincibilityFlashDelay);
        }
    }
  public IEnumerator InvicibiltyDelay()

    {
      yield return new WaitForSeconds(_InvincibilityTimeAfterHit);
        _Isinvincible = false;
     }
}
