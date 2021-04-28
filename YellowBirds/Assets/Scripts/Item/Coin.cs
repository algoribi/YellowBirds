using UnityEngine;

public class Coin : Item, IEffact
{
    public override void DestroyAfterTime() {
        Invoke("DestroyThis", 5.0f);
        Invoke("GetOpaque", 3.0f);
    }

    public override void ApplyItem() {
        EventManager.RunCoinEatEvent();
        DestroyThis();
    }

    public void GetOpaque() {
        Color32 color =  GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 60);
    }
}
