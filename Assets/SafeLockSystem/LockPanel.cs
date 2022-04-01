using UnityEngine;
using UnityEngine.UI;

public class LockPanel : MonoBehaviour
{
    [SerializeField] private Text codeText;
    private string codeValue;
    public Animator animator;
    public GameObject panel;
    public bool isSafeOpen;

    private void Awake()
    {
        codeValue = string.Empty;
    }

    private void Update()
    {
        isSafeOpen = false;

        codeText.text = codeValue;
        if (codeValue == "1703")
        {
            animator.Play("OpenSafe");
            panel.SetActive(false);
            isSafeOpen=true;

        }
        if (codeValue.Length >= 4)
        {
            codeValue = string.Empty;
        }
    }

    public void AddNum(string num)
    {
        //print("num pressed");
        codeValue += num;
    }


}
