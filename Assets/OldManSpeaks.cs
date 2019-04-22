using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OldManSpeaks : MonoBehaviour
{
    public bool TalkToggle = false;
    public Button OldMan;
    public Image Background;
    public Text Speech;
    public string Talking = "Words";
    // Start is called before the first frame update
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    private void Update()
    {
    }
    void TaskOnClick()
    {
        TalkToggle = !TalkToggle;
        if (TalkToggle)
        {
            Background.transform.position -= new Vector3(-500f, -500f, -500f);
            Speech.transform.position -= new Vector3(-500f, -500f, -500f);
        }
        else
        {
            Background.transform.position += new Vector3(-500f, -500f, -500f);
            Speech.transform.position += new Vector3(-500f, -500f, -500f);
        }
    }
}
