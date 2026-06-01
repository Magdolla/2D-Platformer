using UnityEngine;


public class GameManager : MonoBehaviour
{
    // Statyczna instancja, która pozwala na dostęp do skryptu z innych obiektów
    public static GameManager instance;

    [Header("Statystyki Gracza")]
    public int lives = 0;
    public int coins = 0;

    private void Awake()
    {
        // Sprawdzamy, czy instancja już istnieje
        if (instance != null)
        {
            // Jeśli tak, niszczymy nowy obiekt, aby zachować tylko ten oryginalny
            Destroy(gameObject);
        }
        else
        {
            // Jeśli to pierwszy obiekt, ustawiamy go jako instancję
            instance = this;
            // Zapewniamy, że obiekt nie zostanie zniszczony przy zmianie sceny
            DontDestroyOnLoad(gameObject);
        }
    }
}
