using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    private bool highlighted;
    public bool inRange;
    public Material highlight;
    public MeshRenderer[] highlights;

    private void Awake()
    {
        highlighted = false;
        inRange = false;

        if (gameObject.tag != "Interactable")
            gameObject.tag = "Interactable";
    }

    private void OnMouseOver()
    {
        if (inRange)
            ToggleHighlight(true);
    }

    private void OnMouseExit()
    {
        ToggleHighlight(false);
    }

    private void ToggleHighlight(bool h)
    {
        bool modified = false;
        foreach (MeshRenderer m in highlights)
        {
            List<Material> mats = new List<Material>(m.materials);

            if (h && !highlighted)
            {
                mats.Add(highlight);
                modified = true;
            }
            else if (h == false && highlighted)
            {
                mats.RemoveAt(mats.Count - 1);
                modified = true;
            }

            m.materials = mats.ToArray();
        }

        highlighted = modified ? !highlighted : highlighted;
    }
}
