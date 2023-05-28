using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySandbug : Enemy
{
    private Vector3 _enemyScale;

    private void Start()
    {
        _enemyScale = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Attack(collision);
        } 
    }

    private void Attack(Collision2D collision)
    {
        Player gameobjectScript = collision.gameObject.GetComponent<Player>();

        ContactPoint2D contactPoint = collision.contacts[0];

        if (contactPoint.normal.y == 0)
        {
            gameobjectScript.TakeDamage(_damage);
        }
    }

    public override void MoveInDirection(int _direction)
    {
        transform.localScale = new Vector3(Mathf.Abs(_enemyScale.x) * _direction, _enemyScale.y, _enemyScale.z);

        transform.position = new Vector3(
            transform.position.x + Time.deltaTime * _direction * _speed,
            transform.position.y,
            transform.position.z);
    }
}
