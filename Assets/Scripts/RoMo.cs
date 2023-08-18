using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class RoMo : MonoBehaviour
{
    // PUBLIC VARABLES
    public float visibleHeight = 0.2f;
    public float hiddenHeight = -0.3f;
    public Vector3 hiddenPosition;
    public Vector3 visiblePosition;
    public float hideTimer = 0f;

    // PRIVATE VARIABLES
    bool isHit = false;
    bool vulnerable = false;
    RoStates state;
    Vector3 targetPosition;
    Animator anim;
 


    // Start is called before the first frame update
    void Start()
    {
      //  targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);
        transform.localPosition = targetPosition;
        RiseMole();
    }

    // Update is called once per frame
    void Update()
    {

        if (targetPosition == visiblePosition) {

            hideTimer -= Time.deltaTime;
            if (hideTimer <= 0f && !isHit)
            {
                HideMole();
            }
        }
    }

    public void RiseMole()
    {
        // TODO: implement animations here
        state = RoStates.VISIBLE;
        isHit = false;
        targetPosition = visiblePosition;
        vulnerable = true;
    }

    void HideMole()
    {
        // TODO: implement animations here
        state = RoStates.HIDING;
        isHit = false;
        targetPosition = hiddenPosition;
        vulnerable = false;
    }

    void onHit()
    {
        isHit = true;
    }


    public enum RoStates
    {
        HIDING,
        VISIBLE,
    }



}
