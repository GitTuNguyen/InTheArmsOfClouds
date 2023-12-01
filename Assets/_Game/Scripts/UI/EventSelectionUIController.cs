
using Unity.VisualScripting;
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
            eventImage.sprite = eventData.EventArtwork;
            for (int i = 0; i < eventData.Options.Count; i++)
            {
                OptionUIController currentOption = Instantiate(eventOption, optionList.transform)?.GetComponent<OptionUIController>();
                if (currentOption != null)
                {
                    currentOption?.SetupOption(eventData.Options[i], i + 1);
                }
            }
        }
    }
}
