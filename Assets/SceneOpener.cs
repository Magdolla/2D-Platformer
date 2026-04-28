using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
    public string sceneName;
  public void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
