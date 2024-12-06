using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    private static int _collectedCount = 0; // Compteur partag� entre tous les objets
    private static int _totalCollectibles = 3; // Nombre total d'objets � collecter
   [SerializeField] private GameObject victoryPanel; // R�f�rence au panneau de victoire

    private void Start()
    {
        // Assurez-vous que le panneau de victoire est d�sactiv� au d�part
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Le panneau de victoire (victoryPanel) n'est pas assign� !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si le joueur a touch� l'objet
        if (other.CompareTag("Player"))
        {
            // Incr�mente le compteur de collecte
            _collectedCount++;

            // D�sactive ou d�truit cet objet
            Destroy(gameObject);

            // V�rifie si tous les objets ont �t� collect�s
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
