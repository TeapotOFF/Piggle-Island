using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player gameobjectScript = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.tag == "Player")
        {
            gameobjectScript.TakeDamage(_damage);
        }
    }
}