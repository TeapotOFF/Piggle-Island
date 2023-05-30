using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesData : MonoBehaviour
{
    public static int indexOfSavePoint = -1;
    public static Vector3 lastSavePosition = Vector3.zero;

    public static void RefreshGameData()
    {
        indexOfSavePoint = -1;
        lastSavePosition = Vector3.zero;
    }
}
