using System.Collections;
using UnityEngine;

public class MermiDestroys : MonoBehaviour
{
    public GameObject mermi;
    public GameObject normalBlockPrefab;
    private GameObject newNormalBlock;
    public float time = 3f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ghost"))
        {
            Debug.Log("Hayalete de�di");

            // Hayaletle �arp��ma durumunda hayaleti yok et
            Destroy(other.gameObject);
            Destroy(mermi);
        }
        else if (other.CompareTag("ozel_block"))
        {
            Debug.Log("Mermi, �zel blokla �arpt�");

            Destroy(mermi);

            // �zel blo�u yok et
            Destroy(other.gameObject);

            // Yeni normal blok olu�tur ve �zerine yerle�tir
            GameObject newNormalBlock = Instantiate(normalBlockPrefab, other.gameObject.transform.position, transform.rotation);

            // 3 saniye sonra normal blo�u sil
            StartCoroutine(DestroyNormalBlockAfterDelay(newNormalBlock, time));
        }
    }

    private IEnumerator DestroyNormalBlockAfterDelay(GameObject normalBlock, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Normal block'u sil
        Destroy(normalBlock);
    }
}
