using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class InputUi : MonoBehaviour
{
    [SerializeField] GraphicRaycaster uiRaycaster;
    [SerializeField] EventSystem eventSystem;
    [SerializeField] Animator sm_UiControl;
    [SerializeField] SO_ObjectMover so_grabAndMove;
    private PointerEventData clickData;
    private List<RaycastResult> clickResults;
    private Camera cam_SideView;
    private Camera cam_TopView;
    private Camera cam_FrontView;
    private void Start() {
        cam_SideView = GameObject.FindWithTag("Cam_SideView").GetComponent<Camera>();
        cam_TopView = GameObject.FindWithTag("Cam_TopView").GetComponent<Camera>();
        cam_FrontView = GameObject.FindWithTag("Cam_FrontView").GetComponent<Camera>();
    }
    private bool RaycastFromCamera(Camera cam){
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawLine(ray.origin, ray.direction * 25, Color.red, 1.25f);
        if (Physics.Raycast(ray, out hit)){
            if(hit.transform.gameObject.tag == "Selectable"){
                so_grabAndMove.selectedObject = hit.transform.gameObject;
                so_grabAndMove.originalPosition.x = so_grabAndMove.selectedObject.transform.position.x;
                so_grabAndMove.originalPosition.y = so_grabAndMove.selectedObject.transform.position.y;
                so_grabAndMove.originalPosition.z = so_grabAndMove.selectedObject.transform.position.z;
                so_grabAndMove.mouseStartPosition = Mouse.current.position.ReadValue();
                return true;
            }
        }
        return false;
    }
    private void Update(){

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            clickData = new PointerEventData(eventSystem);
            clickData.position = Mouse.current.position.ReadValue();
            clickResults = new List<RaycastResult>();
            uiRaycaster.Raycast(clickData, clickResults);
            if(clickResults.Count > 0){
                switch(clickResults[0].gameObject.tag){
                    case "UI_SideView":
                        if(RaycastFromCamera(cam_SideView)){
                            sm_UiControl.SetBool("SideClicked", true);
                        }
                        break;
                    case "UI_TopView":
                        if(RaycastFromCamera(cam_TopView)){
                            sm_UiControl.SetBool("TopClicked", true);
                        }
                        break;
                    case "UI_Frontview":
                        if(RaycastFromCamera(cam_FrontView)){
                            sm_UiControl.SetBool("FrontClicked", true);
                        }
                        break;
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            sm_UiControl.SetBool("SideClicked", false);
            sm_UiControl.SetBool("TopClicked", false);
            sm_UiControl.SetBool("FrontClicked", false);
            so_grabAndMove.selectedObject = null;
        }
    }
}
