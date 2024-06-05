using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDataContainer : MonoBehaviour
{

    public static ElevatorDataContainer Instance;
    
    public struct ElevatorStartData
    {
        public Vector3 location;
        public MovingCube.ElevatorState state;
    }

    public ElevatorStartData startData;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startData.location = GameManager.Instance.platform.gameObject.transform.position;
        startData.state = GameManager.Instance.platform.currentState;
    }
    
}
