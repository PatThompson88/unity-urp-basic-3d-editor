using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectMover", menuName = "ScriptableObjects/ObjectMover", order = 1)]
public class SO_ObjectMover : ScriptableObject
{
    public Vector3 originalPosition;
    public Vector2 mouseStartPosition;
    public Vector2 mouseCurrentPosition;
    public Vector3 newPosition;
    public GameObject selectedObject;
    public void RepositionObject(){
        Debug.Log($"original: {originalPosition}, new: {newPosition}");
        selectedObject.transform.position = newPosition;
    }
    public void MoveObjectYZ()
    {
        Debug.Log($"Mouse delta: {(mouseCurrentPosition - mouseStartPosition)/80}");
        // mouse position - start position = change
        // scale factor?
        newPosition.y = originalPosition.y + (mouseCurrentPosition.y - mouseStartPosition.y)/80;
        newPosition.z = originalPosition.z + (mouseCurrentPosition.x - mouseStartPosition.x)/100;
        newPosition.x = originalPosition.x;
        RepositionObject();
    }
    public void MoveObjectXY()
    {
        Debug.Log($"Mouse delta: {(mouseCurrentPosition - mouseStartPosition)/80}");
        // mouse position - start position = change
        // scale factor?
        newPosition.y = originalPosition.y + (mouseCurrentPosition.y - mouseStartPosition.y)/80;
        newPosition.x = originalPosition.x + (mouseCurrentPosition.x - mouseStartPosition.x)/100;
        newPosition.z = originalPosition.z;
        RepositionObject();
    }
    public void MoveObjectXZ()
    {
        Debug.Log($"Mouse delta: {(mouseCurrentPosition - mouseStartPosition)/80}");
        // mouse position - start position = change
        // scale factor?
        newPosition.z = originalPosition.z + (mouseCurrentPosition.y - mouseStartPosition.y)/80;
        newPosition.x = originalPosition.x + (mouseCurrentPosition.x - mouseStartPosition.x)/100;
        newPosition.y = originalPosition.y;
        RepositionObject();
    }
}
