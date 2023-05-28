using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private int _indexSavePoint = 0;
    [SerializeField] private GameObject _saveAlert;
    [SerializeField] private Transform _startPlayerPosition;


    private Player _playerScript;

    private void Awake()
    {
        _playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && GamesData.indexOfSavePoint < _indexSavePoint)
        {
            GamesData.indexOfSavePoint = _indexSavePoint;
            GamesData.lastSavePosition = gameObject.transform.position;
            StartCoroutine(SaveAlert());
        }
    }

    private IEnumerator SaveAlert()
    {
        _saveAlert.SetActive(true);
        yield return new WaitForSeconds(1); 
        _saveAlert.SetActive(false);
    }
}
