using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelanoFix : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnpoint;
    private Vector3 location;
    private Quaternion rotation;

    void Start()
    {
        location = spawnpoint.position;
        rotation = spawnpoint.rotation;

        player.position = location;
        player.rotation = rotation;
    }
}
