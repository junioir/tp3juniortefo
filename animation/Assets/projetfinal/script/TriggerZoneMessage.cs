using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneMessage : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel; // Le panel contenant le message
    [SerializeField] private float messageDuration = 2f; // Durée pendant laquelle le message reste affiché

    private bool hasTriggered = false; // Indique si le joueur a déjà traversé la zone

    private void Start()
    {
        // Assurez-vous que le panneau est désactivé au démarrage
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Le messagePanel n'est pas assigné !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre dans la zone trigger
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true; // Marque que la zone a été déclenchée une fois
            ShowMessage();
        }
    }

    private void ShowMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(true); // Active le panneau
            Invoke(nameof(HideMessage), messageDuration); // Programme la désactivation après la durée
        }
    }

    private void HideMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(false); // Désactive le panneau
        }
    }
}
