using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerSetter : MonoBehaviour
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
