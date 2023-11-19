using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayaletAtack : MonoBehaviour
{
    public Transform hedef; // Oyuncunun Transform bileþeni

    public float takipMesafesi = 5f;
    public float hareketHizi = 5f;

    void Update()
    {
        // Hedef ile hayalet arasýndaki mesafeyi kontrol et
        float mesafe = Vector2.Distance(transform.position, hedef.position);

        // Mesafe 5 birimden küçükse oyuncuyu takip et
        if (mesafe < takipMesafesi)
        {
            // Hayaletin oyuncuya doðru hareket etmesi
            transform.position = Vector2.MoveTowards(transform.position, hedef.position, hareketHizi * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncuya saldýrma iþlemleri burada yapýlabilir.
            Debug.Log("Oyuncuya saldýr!");
            
        }
    }
}
