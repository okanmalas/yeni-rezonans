using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mush : MonoBehaviour
{
    [SerializeField]
    private int damage = 30;
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }
    private void Update()
    {
        mushroom();
    }
    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp , data.hp);
        damage = data.damage;
        speed = data.speed;
    }
    // Update is called once per frame
    private void mushroom()
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
