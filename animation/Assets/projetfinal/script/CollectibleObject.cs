using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    private static int _collectedCount = 0; // Compteur partagé entre tous les objets
    private static int _totalCollectibles = 3; // Nombre total d'objets à collecter
   [SerializeField] private GameObject victoryPanel; // Référence au panneau de victoire

    private void Start()
    {
        // Assurez-vous que le panneau de victoire est désactivé au départ
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Le panneau de victoire (victoryPanel) n'est pas assigné !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur a touché l'objet
        if (other.CompareTag("Player"))
        {
            // Incrémente le compteur de collecte
            _collectedCount++;

            // Désactive ou détruit cet objet
            Destroy(gameObject);

            // Vérifie si tous les objets ont été collectés
            if (_collectedCount >= _totalCollectibles)
            {
                DisplayVictoryPanel();
            }
        }
    }

    private void DisplayVictoryPanel()
    {
        // Affiche le panneau de victoire
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
    }
}
