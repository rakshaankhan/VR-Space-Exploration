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
    public GameObject menuGameObject;
    public Transform XROriginMainCamera;

    [Header("")]
    public float spawnDistance = 0.9f;

    [Header("Menu Buttons")]
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
        // Toggle menuGameObject on and off
        if (leftShowButton.action.WasPressedThisFrame() || rightShowButton.action.WasPressedThisFrame() || keyboardShowButton.action.WasPressedThisFrame())
        {
            ToggleMenu(!menuGameObject.activeSelf);
        }


    }

    public void ToggleMenu(bool isActive)
    {
        menuGameObject.SetActive(isActive);

        
        if (isActive)
        {
            // Distance of menuGameObject
            menuGameObject.transform.position = XROriginMainCamera.position + new Vector3(XROriginMainCamera.forward.x, 0, XROriginMainCamera.forward.z).normalized * spawnDistance;



            //Time.timeScale = 0; //add this to "PAUSE" everything in game but it also makes controls studer.



            // Always facing camera position
            menuGameObject.transform.LookAt(new Vector3(XROriginMainCamera.position.x, menuGameObject.transform.position.y, XROriginMainCamera.position.z));
            menuGameObject.transform.forward *= -1;
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
