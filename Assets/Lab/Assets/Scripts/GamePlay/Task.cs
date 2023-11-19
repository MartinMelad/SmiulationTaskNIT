using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    string ToolName = null;

    bool isTurn = false;
    bool isRutateRight = false;
    float totalToolLiftRutate = 0;
    float maxTotalToolLiftRutate = 2f;
    float totalToolRightRutate = 0;
    float maxTotalToolRightRutate = 2f;

    Animator animator;


    public void initializeTask(string toName, bool isruRight)
    {
        ToolName = toName;
        isTurn = true;
        isRutateRight = isruRight;
    }

    private void Start()
    {
        GetComponent<Outline>().enabled = false;
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (ToolName == other.name && isTurn)
        {
            
            if (isRutateRight)
            {
                if (TaskManager.RutateDir == -1)
                    totalToolRightRutate += Time.deltaTime;
                if (totalToolRightRutate > maxTotalToolRightRutate)
                {
                    isTurn = false;
                    totalToolRightRutate = 0;
                    GetComponent<Outline>().enabled = false;
                    TaskManager.GotToNextStep();

                }
                
            }
            else
            {
                if (TaskManager.RutateDir == 1)
                    totalToolLiftRutate += Time.deltaTime;
                if (totalToolLiftRutate > maxTotalToolLiftRutate)
                {
                    isTurn = false;
                    totalToolLiftRutate = 0f;
                    GetComponent<Outline>().enabled = false;
                    animator.SetBool("Drop",true);
                    TaskManager.GotToNextStep();

                }
            }

        }
    }

    private void OnMouseDown()
    {
        if ((TaskManager.toolNameToDoTask == "Set2" && gameObject.name == "Bakra") || (TaskManager.toolNameToDoTask == "Set1" && gameObject.name == "Nut"))
        {
            animator.SetBool("Set", true);
            GetComponent<Outline>().enabled = true;
            TaskManager.GotToNextStep();
        }

    }
}
