using UnityEngine;

public abstract class Item : MonoBehaviour
{
    void Start() {
        DestroyAfterTime();
    }

    public abstract void DestroyAfterTime();
    public abstract void ApplyItem();

    public void DestroyThis() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Player"))
            ApplyItem();
    }
}

public interface IEffact{
    void GetOpaque();
}
