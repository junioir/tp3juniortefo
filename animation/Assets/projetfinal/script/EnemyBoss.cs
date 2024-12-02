using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private MeshRenderer _graphics;
   // [SerializeField] private GameObject _gameOverPanel; // Référence au panel de Game Over
   // [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
   // [SerializeField] private AudioClip _Sound;
   // [SerializeField] private AudioClip _AudioClipdefeat;
   // [SerializeField] private AudioSource _Audiosource;

    private Transform _target;
    private int _despoint;



    void Start()
    {
        if (_waypoints.Length > 0)
        {
            _target = _waypoints[0]; // Initialiser la cible avec le premier waypoint
        }
        else
        {
            Debug.LogError("Aucun waypoint assigné !");
        }

        // _gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null) return;

        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) < 0.3f)
        {
            _despoint = (_despoint + 1) % _waypoints.Length;
            _target = _waypoints[_despoint];

            // Rotation pour orienter l'ennemi vers le prochain waypoint
            Vector3 directionToTarget = _target.position - transform.position;
            if (directionToTarget != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            }
        }
    }
    /* private void OnTriggerEnter(Collider collision)
     {

         if (collision.CompareTag("Player"))
         {
             AudioSource.PlayClipAtPoint(_Sound, transform.position);

             Destroy(collision.gameObject);

             ShowGameOver();
         }
     }*/
    /* private void ShowGameOver()
     {
         _gameOverPanel.SetActive(true);

         _textMeshProUGUI.text = "Game Over";

         AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();

         foreach (AudioSource audioSource in allAudioSources)
         {
             audioSource.Stop();
         }

         AudioSource.PlayClipAtPoint(_AudioClipdefeat, transform.position);
     }
    */
   /* private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"));
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(20);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.transform.GetComponent<PlayerHealth>();
            if (playerHealth != null) 
            {
                playerHealth.TakeDamage(20);
            }
        }
    }

}