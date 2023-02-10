using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectMover", menuName = "ScriptableObjects/ObjectMover", order = 1)]
public class SO_ObjectMover : ScriptableObject
{
    public Vector3 newPosition = Vector3.zero;
    public GameObject selectedObject;
    public void RepositionObject(){
        selectedObject.transform.position = newPosition;
    }
}
