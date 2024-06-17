using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandModelCont : MonoBehaviour
{
    public GameObject handMesh;

    public void ToggleGFX()
    {
        handMesh.SetActive(!handMesh.activeSelf);
    }
}
