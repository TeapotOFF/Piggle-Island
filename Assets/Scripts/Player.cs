using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _reboundForce = 3f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private int _health = 100;
    [SerializeField] private int _coin = 0;
    [SerializeField] private int _extraJump;

    private int _startHealth;
    private int _extraJumpStartValue;
    private float _reboundForceStartValue;
    private bool _facingRight = true;
    private float _inputHorizontal;
    private bool _isMoving = true;

    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();

        _startHealth = _health;
        _extraJumpStartValue = _extraJump;
        _reboundForceStartValue = _reboundForce;
    }

    private void FixedUpdate()
    {
        if (_inputHorizontal != 0 && _isMoving)
        {
            _animator.SetBool("isRun", true);
            Move();
        }
        else _animator.SetBool("isRun", false);

        switch (CheckGround())
        {
            case 7:
                _extraJump = _extraJumpStartValue;
                Jump(_reboundForce);
                break;

            case 9:
                _extraJump = _extraJumpStartValue;
                TrampolineJump(_reboundForce);
                break;

            case 6:
                _extraJump = _extraJumpStartValue;
                _reboundForce = _reboundForceStartValue;
                _animator.SetBool("isFalling", false);
                break;

            default:
                _animator.SetBool("isFalling", true);
                break;
        }
    }

    void Update()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckGround() == 6)
            {
                Jump(_jumpForce);
            }

            else if (_extraJump > 0)
            {
                Jump(_jumpForce);
                _extraJump--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Coin":
                CollectCoin(1, collision.gameObject);
                break;
            case "Medkit":
                RestoreHealth(collision.gameObject);
                break;
        }
    }

    void Move()
    {
        _rb.velocity = new Vector3(_inputHorizontal * _maxSpeed, _rb.velocity.y);

        if (_inputHorizontal > 0 && _facingRight == false)
            Flip();

        else if (_facingRight == true && _inputHorizontal < 0)
            Flip();
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Jump(float _jumpForce)
    {
        _animator.SetTrigger("isJump");
        _audioManager.PlayJumpSound();
        _rb.velocity = Vector2.up * _jumpForce;
    }

    void TrampolineJump(float _reboundForce)
    {
        if (_reboundForce < 7f) 
            this._reboundForce += 1;

        _audioManager.PlayJumpSound();
        Jump(this._reboundForce);
    }

    public IEnumerator JumpFromEnemy()
    {
        _audioManager.PlayJumpSound();
        _isMoving = false;
        _rb.velocity = new Vector3(-_inputHorizontal * 2, 3f);
        yield return new WaitForSeconds(.5f);
        _isMoving = true;
    }

    int CheckGround()
    {
        Collider2D collider = Physics2D.OverlapArea(
            _groundCheck.position + (new Vector3(0.2f, 0f, 0f)),
            _groundCheck.position - (new Vector3(0.2f, 0.01f, 0f)),
            _layerMask
            );

        return collider != null ? collider.gameObject.layer : -1;
    }

    private void CollectCoin(int coinsCount, GameObject coinObject) 
    {
        _audioManager.PlayCoinSound();
        _coin += coinsCount;
        GlobalEventMangaer.updateGameUIEvent.Invoke(_health, _coin);
        Destroy(coinObject);
    }

    private void RestoreHealth(GameObject medkitObject)
    {
        if (_health < _startHealth)
        {
            if ((_health + 30) > _startHealth) _health = _startHealth;
            else _health += 30;
        }
        GlobalEventMangaer.updateGameUIEvent.Invoke(_health, _coin);
        Destroy(medkitObject);
    }

    public void UpdateStats() 
    {
        _health = 100;
        _coin = 0;
        GlobalEventMangaer.updateGameUIEvent.Invoke(_health, _coin);
    }

    private void PlayerDeath()
    {
        Respawn();
    }

    public void TakeDamage(int damage) 
    {
        _health -= damage;
        GlobalEventMangaer.updateGameUIEvent.Invoke(_health, _coin);
        if (_health > 0)
        {
            StartCoroutine(JumpFromEnemy());
        }
        else PlayerDeath();
    }

    public void Respawn()
    {
        if (GamesData.lastSavePosition != Vector3.zero)
        {
            transform.position = GamesData.lastSavePosition;
        }
        else transform.position = _startPoint.position;

        UpdateStats();
    }
}
