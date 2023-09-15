using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CutoutMaskImage : Image
{
    public override Material materialForRendering {
        
        get {
            Material material = base.materialForRendering;
            material.SetFloat("_StencilComp", (float) CompareFunction.NotEqual);
            return material;
        }

    }
}
