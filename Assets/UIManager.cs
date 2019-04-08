using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider Speed;
    public int SpeedBought = 0;
    bool paused = false;
    public string []Inventory;
    public int[] Amount;
    public GameObject Player;
    void Update()
    {
        Movement Motion = Player.GetComponent<Movement>();
        Speed.value = Motion.speed;
        if (Input.GetButtonDown("pauseButton"))
            paused = togglePause();
    }

    void OnGUI()
    {
        Movement Motion = Player.GetComponent<Movement>();
        if (paused)
        {
            GUILayout.Label("Game is paused!");
            GUILayout.Label("Inventory = " + Inventory[0] + " Amount: " + Amount[0] + " " + Inventory[1] + " Amount: " + Amount[1]);
            if (GUILayout.Button("Click me to unpause"))
                paused = togglePause();

            if (GUILayout.Button("Balls for Speed!!!"))
            {
                if (Amount[0] > 0)
                {
                    SpeedBought += 1;
                    Amount[0] -= 1;
                    Motion.speed += 50;
                }
            }
            if (GUILayout.Button("EXIT"))
            {
                Application.Quit();
              //  UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
}