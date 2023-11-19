using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float distanceThreshold = 0f;
    public float moveSpeed = 3f;

    void Update()
    {
        // Player ile Enemy arasýndaki mesafeyi hesapla
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Mesafe 0'dan büyük veya eþitse
        if (distanceToPlayer >= distanceThreshold)
        {
            // Player soldaysa, Enemy'nin scale'ini -1 olarak ayarla
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            // Player saðdaysa, Enemy'nin scale'ini 1 olarak ayarla
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            // Enemy'i Player'e doðru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Player ile Enemy arasýndaki mesafe 0'dan küçükse burada gerekli iþlemleri yapabilirsiniz.
            // Örneðin saldýrý baþlatma veya baþka bir davranýþ sergileme gibi.
        }
    }
}
