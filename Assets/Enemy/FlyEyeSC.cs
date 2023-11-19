using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEyeSC : MonoBehaviour
{
    [SerializeField]
    private int hp = 25;
    [SerializeField]
    private int damage = 90;
    [SerializeField]
    private float speed = 2.5f;

    [SerializeField]
    private EnemyData data;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        FlyEye();
    }
    // Update is called once per frame
    private void FlyEye()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            collision.GetComponent<Health>().Damage(damage);
        }
    }
}
