using UnityEngine;

public class SpeedUp : Item, IEffact
{
    public override void DestroyAfterTime()
    {
        Invoke("DestroyThis", 3.0f);
        Invoke("GetOpaque", 3.0f);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Player"))
            ApplyItem();
    }

    public override void ApplyItem() {
        GameObject player = GameObject.Find("Player");
        PlayerController controller = player.GetComponent<PlayerController>();
        controller.speed *= 1.1f;

        DestroyThis();
    }

    public void GetOpaque() {
        Color32 color =  GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 60);
    }
}
