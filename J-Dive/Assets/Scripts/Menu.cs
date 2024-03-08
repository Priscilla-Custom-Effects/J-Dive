using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public GameObject menu;
    private bool isMenuActive = false;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;
            menu.SetActive(isMenuActive);

            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            menu.SetActive(isPaused);
        }
    }

    void OnGUI()
    {
        if (isMenuActive)
        {
            Time.timeScale = 0;
            GUI.Box(new Rect(10, 10, 100, 90), "Menu");

            if (GUI.Button(new Rect(20, 40, 80, 20), "Resume"))
            {
                isPaused = false;
                Time.timeScale = 1; // Возобновляем время в игре
                menu.SetActive(false);
            }

            if (GUI.Button(new Rect(20, 70, 80, 20), "Quit"))
            {
                Application.Quit();
            }
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
