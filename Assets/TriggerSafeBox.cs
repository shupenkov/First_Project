using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSafeBox : MonoBehaviour
{

    public LockPanel safeBox;
    public GameObject canvas;
    public MouseLook mousePlayerCamera;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mousePlayerCamera.enabled = true;
            canvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!safeBox.isSafeOpen && other.CompareTag("Player"))
        {
               mousePlayerCamera.enabled = false; 
                canvas.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        mousePlayerCamera.enabled = true;
        canvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
