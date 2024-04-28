using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class GamePauseMenu : MonoBehaviour
{


    public InputActionProperty leftShowButton;
    public InputActionProperty rightShowButton;
    public InputActionProperty keyboardShowButton;

    [Header("")]
    public GameObject menu;
    public Transform head;

    [Header("")]
    public float spawnDistance = 0.45f;

    [Header("Menu Buttons")]
    public Button quitButton;
    public Button restartButton;
    public Button resumeButton;




    void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(RestartGame);
        resumeButton.onClick.AddListener(() => ToggleMenu(false));

    }

    void Update()
    {
        // Toggle menu on and off
        if (leftShowButton.action.WasPressedThisFrame() || rightShowButton.action.WasPressedThisFrame() || keyboardShowButton.action.WasPressedThisFrame())
        {
            ToggleMenu(!menu.activeSelf);
        }


    }

    public void ToggleMenu(bool isActive)
    {
        menu.SetActive(isActive);

        
        if (isActive)
        {
            // Distance of menu
            Vector3 spawnPosition = head.position + head.forward.normalized * spawnDistance;
            menu.transform.position = spawnPosition;



            //Time.timeScale = 0; //add this to "PAUSE" everything in game but it also makes controls studer.

            menu.transform.LookAt(head.position);
            menu.transform.Rotate(0, 180, 0);


        }
        else
        {
            //Time.timeScale = 1;  //add this to "PAUSE" everything in game but it also makes controls studer.
        }

    }


    public void QuitGame()
    {
        Debug.Log("Attempting to quit game...");

        Application.Quit();
    }
    public void RestartGame()
    {
        //Time.timeScale = 1; //add this to "PAUSE" everything in game but it also makes controls studer.
        

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneTransitionManager.singleton.GoToSceneAsync(currentSceneIndex);
    }

    public void ResumeGame()
    {
        ToggleMenu(false);
    }




}
