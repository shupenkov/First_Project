using UnityEngine;

[RequireComponent(typeof(Outline))]
public class PickableItems : MonoBehaviour
{
    public Transform Player;
    private Outline outline;
    public GameObject item;
    public ItemType itemType;
    public GameObject promt;
    

    private void Awake()
    {
        outline = GetComponent<Outline>();

    }


    void OnMouseOver()
    {
        if (Player)
        {
            float dist = Vector3.Distance(Player.position, transform.position);

            if (dist < 2)
            {
                outline.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    SceneEventManager.TriggerOnPickItem(itemType);
                    Destroy(item);
                    promt.SetActive(true);

                }
            }
            else
                outline.enabled = false;
        }
    }
    private void OnMouseExit()
    {
        if (Player)
        {
            float dist = Vector3.Distance(Player.position, transform.position);

            if (dist < 2)
                outline.enabled = false;
        }
    }




}


