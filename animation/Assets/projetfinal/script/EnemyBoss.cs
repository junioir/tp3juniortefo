using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private SpriteRenderer _graphics;
    [SerializeField] private GameObject _gameOverPanel; // Référence au panel de Game Over
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private AudioClip _Sound;
    [SerializeField] private AudioClip _AudioClipdefeat;
    [SerializeField] private AudioSource _Audiosource;

    private Transform _target;
    private int _despoint;



    void Start()
    {
        _target = _waypoints[0];

        _gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) < 0.3f)
        {
            _despoint = (_despoint + 1) % _waypoints.Length;
            _target = _waypoints[_despoint];
            _graphics.flipX = !_graphics.flipX;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(_Sound, transform.position);

            Destroy(collision.gameObject);

            ShowGameOver();
        }
    }
    private void ShowGameOver()
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
}
