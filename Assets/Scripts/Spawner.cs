using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    GameObject prefabToSpawn;

    public GameObject Spawn(Vector2? location = null, Transform parent = null) {

        if(location == null) {
            location = gameObject.transform.position;
        }

        return Instantiate(prefabToSpawn, (Vector3) location, quaternion.identity, parent);
    }
}
