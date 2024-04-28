using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PopupUI : MonoBehaviour
{
    public Canvas canvasToToggle; // Assign this in the inspector
    public Transform cameraTarget;
    [SerializeField] public XRGrabInteractable interactable; // Assign this in the inspector as well


    private void Start()
    {
        // this adds main camera to inspector at start

        Camera xrCamera = Camera.main;
        if (xrCamera != null)
        {
            cameraTarget = xrCamera.transform;
        }
        else
        {
            Debug.LogError("XR Camera not found in the scene!");
        }
    }

    private void Awake()
    {
        canvasToToggle.enabled = false;

        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrabbed);
            interactable.selectExited.AddListener(OnReleased);
            interactable.hoverEntered.AddListener(ShowCanvas);

        }
    }



    private void ShowCanvas(HoverEnterEventArgs arg)
    {
        transform.LookAt(transform.position + cameraTarget.rotation * Vector3.forward, cameraTarget.rotation * Vector3.up); // canvas face camera
        canvasToToggle.enabled = true;

        StartCoroutine(DisableCanvasAfterDelay(5.0f)); // Disables the canvas after 5 second

    }

    private IEnumerator DisableCanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canvasToToggle.enabled = false;
    }

    private void OnGrabbed(SelectEnterEventArgs arg)
    {
        gameObject.SetActive(false); // Disable the canvas when grabbing the object
        
    }

    private void OnReleased(SelectExitEventArgs arg)
    {
        gameObject.SetActive(true); // Enabling object when dropping the object
    }

}
