using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float distanceThreshold = 0f;
    public float moveSpeed = 3f;

    void Update()
    {
        // Player ile Enemy aras�ndaki mesafeyi hesapla
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Mesafe 0'dan b�y�k veya e�itse
        if (distanceToPlayer >= distanceThreshold)
        {
            // Player soldaysa, Enemy'nin scale'ini -1 olarak ayarla
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            // Player sa�daysa, Enemy'nin scale'ini 1 olarak ayarla
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            // Enemy'i Player'e do�ru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Player ile Enemy aras�ndaki mesafe 0'dan k���kse burada gerekli i�lemleri yapabilirsiniz.
            // �rne�in sald�r� ba�latma veya ba�ka bir davran�� sergileme gibi.
        }
    }
}
