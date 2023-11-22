using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DairyMenuUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI menuName;
    public DairyUIController dairyUIController;
    public void SetupArtworkList()
    {
        dairyUIController.SetupArtworkList();
    }
}
