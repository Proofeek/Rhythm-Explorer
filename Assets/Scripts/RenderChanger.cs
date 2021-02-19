using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RenderChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GraphicsSettings.renderPipelineAsset = null;
    }
}
