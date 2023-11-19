using System.Collections;
using UnityEngine;

public class MermiDestroys : MonoBehaviour
{
    public GameObject mermi;
    public GameObject normalBlockPrefab;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ozel_block"))
        {
            Debug.Log("Mermi, özel blokla çarptı");

            Destroy(gameObject);

            // Özel bloğu yok et
            Destroy(other.gameObject);

            // Yeni normal blok oluştur ve üzerine yerleştir
            GameObject newNormalBlock = Instantiate(normalBlockPrefab, other.gameObject.transform.position, transform.rotation);

            // 3 saniye sonra normal bloğu sil
            //StartCoroutine(DestroyNormalBlockAfterDelay(newNormalBlock, 3.0f));
        }
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("map"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("ghost"))
        {
            Debug.Log("Hayalete değdi");

            // Hayaletle çarpışma durumunda hayaleti yok et
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}