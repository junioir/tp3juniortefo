using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneMessage : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel; // Le panel contenant le message
    [SerializeField] private float messageDuration = 2f; // Dur�e pendant laquelle le message reste affich�

    private bool hasTriggered = false; // Indique si le joueur a d�j� travers� la zone

    private void Start()
    {
        // Assurez-vous que le panneau est d�sactiv� au d�marrage
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Le messagePanel n'est pas assign� !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si le joueur entre dans la zone trigger
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true; // Marque que la zone a �t� d�clench�e une fois
            ShowMessage();
        }
    }

    private void ShowMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(true); // Active le panneau
            Invoke(nameof(HideMessage), messageDuration); // Programme la d�sactivation apr�s la dur�e
        }
    }

    private void HideMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(false); // D�sactive le panneau
        }
    }
}
