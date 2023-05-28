using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObjects : MonoBehaviour
{
    private int _playerDamage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WhatInCollision(collision);
    }

    void WhatInCollision(Collider2D collision)
    {
        if (collision.gameObject.tag == "DestroyedObjects")
        {
            collision.gameObject.GetComponent<DestroyedObjects>().TakeDamage(_playerDamage);
        }

        if (collision.gameObject.tag == "Enemy" && gameObject.name == "GroundCheck")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_playerDamage);
        }

        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<Trampoline>().PlayAnimation();
        }
    }
}
