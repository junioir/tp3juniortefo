using System;
using System.Collections;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    private const bool V = false;
    [SerializeField] private int _damageOnCollision = 5;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _attackRange = 2f;
    // [SerializeField] private Animator _animator;

    private Transform _player; // Référence au joueur
    // private bool _isAttacking;

    void Start()
    {
        // Trouver le joueur par son tag
        _player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (_player == null)
        {
            Debug.LogError("Aucun joueur trouvé dans la scène !");
        }
    }

    void Update()
    {
        if (_player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (distanceToPlayer <= _attackRange)
        {
            // Mode attaque
            //  _isAttacking = true;
            //  _animator.SetBool("IsWalking", false);
            // _animator.SetBool("IsAttacking", true);
            AttackPlayer();
        }
        else
        {
            // Mode suivi
            //  _isAttacking = V;
            //   _animator.SetBool("IsAttacking", false);
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        // _animator.SetBool("IsWalking", true);

        Vector3 direction = (_player.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);

        // Orienter l'ennemi vers le joueur
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
    }

    private void AttackPlayer()
    {
        // Logique d'attaque (par exemple, infliger des dégâts)
        PlayerHealth playerHealth = _player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(_damageOnCollision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(_damageOnCollision);
            }
        }
    }

    internal void ChangeColor(Color color)
    {
        throw new NotImplementedException();
    }
}
