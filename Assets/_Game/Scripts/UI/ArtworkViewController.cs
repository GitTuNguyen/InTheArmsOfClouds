using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtworkViewController : MonoBehaviour
{
    public void CloseArtworkView()
    {
        ActionPhaseUIManager.Instance?.CloseCurrentPopup();
    }
}
