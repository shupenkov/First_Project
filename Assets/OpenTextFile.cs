using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenTextFile : MonoBehaviour
{
    private float clickTime = 0.3f;
    [SerializeField] private GameObject displayInfo;
    [SerializeField] private InputField imput1;
    [SerializeField] private InputField imput2;
    [SerializeField] private InputField imput3;
    [SerializeField] private InputField imput4;
    [SerializeField] private InputField imput5;
    [SerializeField] private InputField imput6;
    [SerializeField] private InputField imput7;
    [SerializeField] private InputField imput8;
    [SerializeField] private InputField imput9;
    [SerializeField] private TMP_Text textInfo;
    public void ShowTextFile()
    {

        if (clickTime > 0)
        {
            if ((Time.realtimeSinceStartup - clickTime) < 0.3f)
            {
                displayInfo.SetActive(true);
            }
            clickTime = Time.realtimeSinceStartup;
        }
    }

    public void CloseTextInfo()
    {
        displayInfo.SetActive(false);
    }

    public void ShowKeyCode()
    {
        if (imput1.text == "2" &&
            imput2.text == "7" &&
            imput3.text == "6" &&
            imput4.text == "9" &&
            imput5.text == "5" &&
            imput6.text == "1" &&
            imput7.text == "4" &&
            imput8.text == "3" &&
            imput9.text == "8")
        {
            textInfo.text = "Password: 1703 ";
        }
        else
        {
            imput1.text = string.Empty;
            imput2.text = string.Empty;
            imput3.text = string.Empty;
            imput4.text = string.Empty;
            imput5.text = "?";
            imput6.text = string.Empty;
            imput7.text = "!";
            imput8.text = string.Empty;
            imput9.text = string.Empty;
        }
    }
}


