using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 15f; // Vitesse du projectile
    private int _damage;
    private Vector3 _target;

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    void Update()
    {
        // D�placement du projectile vers la cible
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        // D�truire le projectile lorsqu'il atteint la cible
        if (Vector3.Distance(transform.position, _target) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player playerScript = other.GetComponent<player>();
            if (playerScript != null)
            {
                playerScript.ReceiveDamage(_damage);
            }

            Destroy(gameObject);
        }
    }
}
