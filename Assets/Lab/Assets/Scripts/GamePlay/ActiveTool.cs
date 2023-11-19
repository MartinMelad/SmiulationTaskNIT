using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTool : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField] 
    private Transform inatialPos;
    [SerializeField]
    private GameObject activeTool;

    float ratatePreSec = 250.0f;

    bool flagMouseDown = false;
    bool flagMouseUp = false;

  
    void Start()
    {
        /// set dufoult active tool
        activeTool.transform.position = inatialPos.position;
        activeTool.transform.rotation = inatialPos.rotation;
        activeTool.transform.parent = cam.transform;
        activeTool.active = true;
        activeTool.name = "Staaf";

        EventManager.AddListener(EventName.SetActiveTool, SetAcvtiveTool);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTool != null)
        {
            bool mouseButtonDown = Input.GetMouseButtonDown(0);
            bool mouButtonUp = Input.GetMouseButtonUp(0);
            float rotate = Input.GetAxis("Rotate");
            TaskManager.RutateDir = rotate;
            if (mouseButtonDown)
            {
                if (!flagMouseDown)
                {
                    flagMouseDown = true;
                    activeTool.transform.parent = null;
                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition.z = cam.nearClipPlane;
                    Ray ray = cam.ScreenPointToRay(mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 2f))
                    {
                        activeTool.transform.position = hit.point + Vector3.right * .1f;
                        activeTool.transform.eulerAngles = new Vector3(0, 0, 180);
                    }
                    
                }

            }
            else
                flagMouseDown = false;
            
            if (mouButtonUp)
            {
                if (!flagMouseUp)
                {
                    flagMouseUp = true;
                    activeTool.transform.position = inatialPos.position;
                    activeTool.transform.rotation = inatialPos.rotation;
                    activeTool.transform.parent = cam.transform;
                }

            }
            else
                flagMouseUp = false;

            if (activeTool.name != TaskManager.toolNameToDoTask)
            {
                TaskManager.ActiveOutLineTool();
            }
            else
            {
                TaskManager.InActiveOutLineTool();
            }

            if (rotate != 0)
            {
                activeTool.transform.Rotate(Vector3.right * ratatePreSec * Time.deltaTime * rotate);

            }

        }
    }

    private void SetAcvtiveTool (GameObject tool)
    {
        
        activeTool.transform.position = tool.transform.position;
        activeTool.transform.rotation = tool.transform.rotation;
        activeTool.transform.parent = null;
        tool.transform.position = inatialPos.position;
        tool.transform.rotation= inatialPos.rotation;
        tool.transform.parent = cam.transform;
        activeTool = tool;

    }
}
