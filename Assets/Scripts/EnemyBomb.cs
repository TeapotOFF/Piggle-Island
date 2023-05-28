using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : Enemy
{
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private AudioSource _explAudio;

    private bool _isActivated = false;
    private Rigidbody2D _rb;
    private Vector3 _enemyScale;

    private void Start()
    { 
        _enemyScale = transform.localScale;
        _rb = GetComponent<Rigidbody2D>();
    }

    public override void MoveInDirection(int _direction)
    {
        transform.localScale = new Vector3(
            Mathf.Abs(_enemyScale.x) * _direction,
            _enemyScale.y,
            _enemyScale.z
            );

        if (CheckGround() && !_isActivated)  
            _rb.velocity = new Vector3(_speed * _direction, _jumpForce);
    }

    bool CheckGround()
    {
        Collider2D collider = Physics2D.OverlapArea(
            transform.position + (new Vector3(0.04f, -0.23f, 0f)),
            transform.position - (new Vector3(0.04f, 0.25f, 0f)),
             _groundMask
            );

        return collider;
    }

    bool PlayerInArea()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f, _playerMask);

       return collider;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !_isActivated)
        {
            TakeDamage(1);
            StartCoroutine(Explosion(collision.gameObject));
            _isActivated = true;   
        }
    }
    IEnumerator Explosion(GameObject _player)
    {
        yield return new WaitForSeconds(1.7f);
        _explAudio.Play();
        if (PlayerInArea())
            _player.GetComponent<Player>().TakeDamage(_damage);
    }
}
