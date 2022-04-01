using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class TransitionGameCamera : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject PlayerCamera;
    public GameObject MenuCamera;
    public Canvas MainMenu;
    public ListSounds Sounds;
    public GameObject Player;
    private CharacterController keyboard;
    public GameObject Camera;
    private MouseLook MouseLookScript;
    public TimerController timerController;
    [SerializeField] public AudioSource nightSounds;
    private bool GameStarted;
    [SerializeField] private TMP_InputField playerName;
    public string PlayerName;




    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Sounds.GetAudioClipByType(AudioType.MainMenu);
        audioSource.Play();
        keyboard = Player.GetComponent<CharacterController>();
        keyboard.enabled = false;
        MouseLookScript = Camera.GetComponent<MouseLook>();
        MouseLookScript.enabled = false;



    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SwapCameraToMenu();
        }
    }
    public void SwapCameraToGame()
    {

        if (playerName.text == string.Empty)
            PlayerName = "Player";
        else PlayerName = playerName.text;

        GameStarted = true;
        Cursor.lockState = CursorLockMode.Locked;
        MainMenu.enabled = false;
        MenuCamera.SetActive(false);
        PlayerCamera.SetActive(true);
        timerController.BeginTimer();
        audioSource.clip = Sounds.GetAudioClipByType(AudioType.GameSound);
        audioSource.Play();
        keyboard.enabled = true;
        StartCoroutine(StartLookMouse());
    }

    public void SwapCameraToMenu()
    {

        timerController.EndTimer();
        Cursor.lockState = CursorLockMode.Confined;
        MainMenu.enabled = true;
        PlayerCamera.SetActive(false);
        MenuCamera.SetActive(true);
        nightSounds.Stop();
        audioSource.clip = Sounds.GetAudioClipByType(AudioType.MainMenu);
        audioSource.Play();
        keyboard.enabled = false;
        MouseLookScript.enabled = false;
    }

    private IEnumerator StartLookMouse()
    {
        yield return new WaitForSeconds(2.5f);
        MouseLookScript.enabled = true;
    }

    public void ResetGame()
    {
        if (GameStarted)
            SceneManager.LoadScene("Game");
        else
            SwapCameraToGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }



}
