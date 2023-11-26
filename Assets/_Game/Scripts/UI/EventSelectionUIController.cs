
using UnityEngine;
using UnityEngine.UI;
public class EventSelectionUIController : MonoBehaviour
{
    public Image eventImage;
    public TMPro.TextMeshProUGUI eventTitle;
    public GameObject eventOption;
    public GameObject optionList;

    public void SetEventData(EventData eventData = null)
    {
        if (eventData != null)
        {
            Debug.Log("Set option");
            eventTitle.text = eventData.EventDesc;
            foreach(OptionData optionData in eventData.Options)
            {
                OptionUIController currentOption = Instantiate(eventOption, optionList.transform)?.GetComponent<OptionUIController>();
                currentOption?.SetupOption(optionData);
            }
        } else {
            Debug.Log("Test Set option");
            for (int i = 0; i < 3; i++)
            {                
                Instantiate(eventOption, optionList.transform)?.GetComponent<OptionUIController>();
            }
        }
    }
}
