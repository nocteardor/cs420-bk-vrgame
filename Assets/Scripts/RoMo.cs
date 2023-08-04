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
    public string difficulty;
    public float hideSpeed;

    // PRIVATE VARIABLES
    bool isHit = false;
    bool vulnerable = false;
    float hideTimer = 0f;
    Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);
        transform.localPosition = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        hideTimer -= Time.deltaTime;
        if (hideTimer <= 0f && !isHit)
        {
            HideMole();
        }
    }

    public void RiseMole()
    {   
        // TODO: implement animations here
        isHit = false;
        targetPosition = new Vector3(transform.localPosition.x, visibleHeight, transform.localPosition.z);
        vulnerable = true;
        hideTimer = hideSpeed;
    }

    void HideMole()
    {
        // TODO: implement animations here
        isHit = false;
        vulnerable = false;
    }

    void onHit()
    {
        isHit = true;
    }
}
