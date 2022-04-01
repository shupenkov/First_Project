using System.Collections;
using UnityEngine;




public class MouseLook : MonoBehaviour
{

    public Light flashlight;
    public float mouseXSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    float _threshold = 0.25f;
    public bool doubleClicked = false;
    public PlayerItems playerItems;
    public GameObject promtFlashlight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DetectTouchInput");
        // Cursor.lockState = CursorLockMode.Locked;
        flashlight.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (playerItems.CheckItemInInventory(ItemType.Flashlight) && Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
            promtFlashlight.SetActive(false);
        }

    }

    IEnumerator DetectTouchInput()
    {
        while (true)
        {
            float duration = 0;
            bool doubleClicked = false;
            if (Input.GetMouseButtonDown(0))
            {
                while (duration < _threshold)
                {
                    duration += Time.deltaTime;
                    yield return new WaitForSeconds(0.005f);
                    if (Input.GetMouseButtonDown(0))
                    {
                        doubleClicked = true;
                        duration = _threshold;
                        // Double click/tap
                        print("Double Click detected");
                    }
                }
                if (!doubleClicked)
                {
                    // Single click/tap
                    print("Single Click detected");
                }
            }
            yield return null;
        }
    }
}
