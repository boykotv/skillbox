using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    //при выходе за границы текущего объекта
    private void OnTriggerExit(Collider other) 
    {
        Destroy(other.gameObject);
    }
}
