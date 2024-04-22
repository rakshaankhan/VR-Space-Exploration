using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class GamePauseMenu : MonoBehaviour
{

    public GameObject menu;
    public InputActionProperty showButton; //needs to be configured in Unity. set this button to menuButton [LeftHand XR Controller]. Or any input button you like

    public Transform head;
    public float spawnDistance = 2;

    public Button quitButton;
    public Button restartButton;
    public Button resumeButton;




    void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        restartButton.onClick.AddListener(StartGame);
        resumeButton.onClick.AddListener(() => ToggleMenu(false));

    }

    void Update()
    {
        // Toggle menu on and off
        if (showButton.action.WasPressedThisFrame())
        {
            ToggleMenu(!menu.activeSelf);
        }


    }

    public void ToggleMenu(bool isActive)
    {
        menu.SetActive(isActive);

        // If activating the menu, set position
        if (isActive)
        {
            // Distance of menu
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;



            //Time.timeScale = 0; //add this to "PAUSE" everything in game but it also makes controls studer.



            // Always facing camera position
            menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
            menu.transform.forward *= -1;
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
    public void StartGame()
    {
        //Time.timeScale = 1; //add this to "PAUSE" everything in game but it also makes controls studer.
        SceneTransitionManager.singleton.GoToSceneAsync(2);
    }

    public void ResumeGame()
    {
        ToggleMenu(false);
    }




}
