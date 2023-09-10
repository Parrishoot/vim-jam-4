using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    [field:SerializeReference]
    public Shaker Shaker { get; set; }
}
