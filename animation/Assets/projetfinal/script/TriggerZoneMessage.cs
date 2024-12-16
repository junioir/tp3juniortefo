using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneMessage : MonoBehaviour
{
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private float messageDuration = 2f;

    private bool hasTriggered = false;

    private void Start()
    {

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
            messagePanel.SetActive(true);
            Invoke(nameof(HideMessage), messageDuration);
        }
    }
    private void HideMessage()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(false);
        }
    }
}
