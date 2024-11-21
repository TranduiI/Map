using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDronScene : MonoBehaviour
{
    public void OnMouseDown()
    {
        DataStorage.cubeClicked = true;
        SceneManager.LoadScene("DroneScene");
    }
}
public static class DataStorage
{
    // Переменная для хранения информации о нажатии на куб
    public static bool cubeClicked = false;
}
