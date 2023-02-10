using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public class Smb_TopViewControl : StateMachineBehaviour
{
    private Vector2 mousePosition;
    private Vector3 objectDisplacement;
    [SerializeField] SO_ObjectMover so_grabAndMove;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mousePosition = Mouse.current.position.ReadValue();
        objectDisplacement.z = mousePosition.y/200;
        objectDisplacement.x = mousePosition.x/200;
        objectDisplacement.y = so_grabAndMove.selectedObject.transform.position.y;
        so_grabAndMove.newPosition = objectDisplacement;
        so_grabAndMove.RepositionObject();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
