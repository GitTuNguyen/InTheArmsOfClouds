using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TutorialController : MonoBehaviour
{

    public TMPro.TextMeshProUGUI tutorialText;
    public GameObject closeTutorialButton;
    public GameObject arrow;
    [TextArea(1, 10)]
    public string[] tutorialList;
    public int tutorialIndex;
    // Start is called before the first frame update
    void Start()
    {
        tutorialIndex = 0;
        tutorialText.text = tutorialList[tutorialIndex];
    }

    public void GotoNextTutorial()
    {   
        tutorialIndex += 1;
        if (tutorialIndex < tutorialList.Length)
        {
            tutorialText.text = tutorialList[tutorialIndex];
        } else {
            tutorialText.text = tutorialList[tutorialList.Length - 1];
            arrow.SetActive(false);
            closeTutorialButton.SetActive(true);
        }
    }

    public void CloseTutorial()
    {
        ActionPhaseUIManager.Instance.StartActionPhaseUI();
        Destroy(this.gameObject);
    }
}
