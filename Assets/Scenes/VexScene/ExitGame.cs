using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public void Quit()
    {
        // Quit out of built applications
        Application.Quit();
        // Quit out of Unity Editor
        // UnityEditor.EditorApplication.isPlaying = false;
    }


}
