using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePoin : MonoBehaviour
{
    [SerializeField] private GameObject _endGameMenu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = 0;
            _endGameMenu.SetActive(true);
        }
    }
}
