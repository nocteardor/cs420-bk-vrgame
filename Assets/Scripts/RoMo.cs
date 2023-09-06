using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class RoMo : MonoBehaviour
{
    // PUBLIC VARABLES
   // public Vector3 hiddenPosition = new(0, 0, 0);
    //public Vector3 visiblePosition = new(0, 3, 0);
    public float visibleHeight = 0.2f;
    public float hiddenHeight = -0.3f;
    public float hideTimer = 300f;
    public float speed = 0.1f;

    // PRIVATE VARIABLES
    bool isHit = false;
    bool vulnerable = false;
    RoStates state;
    Vector3 targetPosition;
    Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.speed = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        //RiseMole();
        StartCoroutine(Peek());
        //  targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);
        // transform.localPosition = targetPosition;
        //  RiseMole();
    }

    // Update is called once per frame
    void Update()
    {   
        //if (targetPosition == visiblePosition)
        //  {
       // hideTimer -= Time.deltaTime
        
        

       
    }

    public void RiseMole()
    {
        // TODO: implement animations here
        anim.SetBool("Roll_Anim", false);
        anim.SetBool("Open_Anim", true);
        //
        state = RoStates.VISIBLE;
        targetPosition = new Vector3(transform.localPosition.x, visibleHeight, transform.localPosition.z);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed);
        vulnerable = true;
    }

    void HideMole()
    {
        // TODO: implement animations here
        anim.SetBool("Open_Anim", false);
        anim.SetBool("Roll_Anim", true);
        //
        state = RoStates.HIDING;
        targetPosition = new Vector3(transform.localPosition.x, hiddenHeight, transform.localPosition.z);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, speed);
        vulnerable = false;
        
    }

    void onHit()
    {
        if (vulnerable == true)
        {
            isHit = true;
        }
        
        HideMole();
    }


    public enum RoStates
    {
        HIDING,
        VISIBLE,
    }

    IEnumerator Peek()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        while (true)
        {
            yield return new WaitForSeconds(6);
            RiseMole(); 
            Debug.Log("Mole visible");
            yield return new WaitForSeconds(6);
            HideMole(); 
            Debug.Log("Mole hidden");
        }
    }
}

