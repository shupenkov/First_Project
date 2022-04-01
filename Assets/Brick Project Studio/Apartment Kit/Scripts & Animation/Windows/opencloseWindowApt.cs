using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

namespace SojaExiles

{
	public class opencloseWindowApt : MonoBehaviour
	{
		public AudioSource nightSound;
		public Animator openandclosewindow;
		private bool open = false;
		public Transform Player;
		public BreakableWindow breakableWindow;
		private bool isBreakable = false;
		private bool isBroken = false;
		public GameObject textMesh;
		public Animator NoteHandler;
		

        private void Awake()
        {
			SceneEventManager.OnPickItem += BreakWindow;
				
		}

		void OnMouseOver()
		{
			{
				if (Player)
				{

					
					float dist = Vector3.Distance(Player.position, transform.position);
					if (dist < 3)
					{
						if (isBreakable == true && !isBroken)

							textMesh.SetActive(true);

						if (open == false)
							{
								if (Input.GetMouseButtonDown(0) && isBroken == false)
								{
									StartCoroutine(opening());
										if (open == true)
											nightSound.Play();
								}
							
								if (Input.GetKey(KeyCode.R) && isBreakable == true && !isBroken)
								{	
									breakableWindow.breakWindow();
									isBroken = true;
									NoteHandler.Play("NoteHandlerAnim");
									nightSound.Play();
								
								}
							}
						else
						{
							if (open == true)
							{
								if (Input.GetMouseButtonDown(0) && isBroken == false)
								{
									StartCoroutine(closing());
										if (open == false)
											nightSound.Pause();
								}
							}

						}

					}
				}

			}

		}

		
		

        void OnMouseExit()
        {
            textMesh.SetActive(false);
        }

        IEnumerator opening()
		{
			print("you are opening the Window");
			openandclosewindow.Play("Openingwindow");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the Window");
			openandclosewindow.Play("Closingwindow");
			open = false;
			yield return new WaitForSeconds(.5f);
		}

		void BreakWindow(ItemType item)
		{
			switch (item)
			{
				case ItemType.Hammer:
					isBreakable = true;
					break;
			}
		}
        
	}
}