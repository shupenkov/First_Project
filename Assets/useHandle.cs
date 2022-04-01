using UnityEngine;

public class useHandle : MonoBehaviour
{
    public Transform Player;
    public Animator useHandleAnimator;
    void OnMouseOver()
    {
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 15)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        useHandleAnimator.Play("useHandle");
                    }
                }

            }
        }

    }

}

