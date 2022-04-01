using System.Collections;
using UnityEngine;

namespace SojaExiles

{
    [RequireComponent(typeof(AudioSource))]
    public class opencloseDoor : MonoBehaviour
    {

        public Animator openandclose;
        public bool open;
        public Transform Player;
        public ListSounds doorSounds;
        private AudioSource audioSource;
        public bool useKeyToOpen;
        public GameObject endGameMovingTarget;
        public GameObject endGameCamera;
        public GameObject endGameScreen;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }


        void OnMouseOver()
        {
            {
                if (Player)
                {
                    float dist = Vector3.Distance(Player.position, transform.position);
                    if (dist < 3)
                    {
                        print("this is door");

                        if (open == false)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                StartCoroutine(opening());
                            }
                        }
                        else
                        {
                            if (open == true)
                            {
                                if (Input.GetMouseButtonDown(0))
                                {
                                    StartCoroutine(closing());
                                }
                            }

                        }

                    }
                }

            }

        }

        IEnumerator opening()
        {
           
            
            if (useKeyToOpen == true)
            {
                if (SceneEventManager.TriggerOnCheckedItemInInventory(ItemType.Key))
                {
                    TimerController.instance.EndTimer();
                    openandclose.Play("Opening");
                    open = true;
                    print("you are opening the door");
                    

                    audioSource.PlayOneShot(doorSounds.GetAudioClipByType(AudioType.OpenDoor));
                    useKeyToOpen = false;
                    audioSource.clip = (doorSounds.GetAudioClipByType(AudioType.StreetSound));
                    audioSource.Play();
                    endGameScreen.SetActive(true);
                    endGameMovingTarget.SetActive(true);
                    endGameCamera.SetActive(true);
                }
                else
                {
                    audioSource.clip = doorSounds.GetAudioClipByType(AudioType.LockDoor);
                    audioSource.Play();
                }
            }
            else
            {
                openandclose.Play("Opening");
                open = true;
                print("you are opening the door");
                audioSource.clip = doorSounds.GetAudioClipByType(AudioType.OpenDoor);
                audioSource.Play();
            }
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            print("you are closing the door");
            openandclose.Play("Closing");
            open = false;
            audioSource.clip = doorSounds.GetAudioClipByType(AudioType.CloseDoor);
            audioSource.Play();

            yield return new WaitForSeconds(.5f);
        }

       

        //public void CloseDoorSoundEnaible()
        //{
        //    if (openandclose.enabled == false)
        //    {
        //        audioSource.clip = doorSounds.GetAudioClipByType(AudioType.LockDoor);
        //        audioSource.Play();
        //    }
        //    else
        //    {

                
        //    }
        //}


    }
}