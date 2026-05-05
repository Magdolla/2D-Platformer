using UnityEngine;
using UnityEngine.SceneManagement;

public class killvolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
