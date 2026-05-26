using UnityEngine;

public class ZapiszStaty : MonoBehaviour
{
    public static ZapiszStaty instance;
    public int PlayerHealth = 100;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
}
