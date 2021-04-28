using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroySelf", 5.0f);
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}
