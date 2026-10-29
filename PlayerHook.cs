using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHook : MonoBehaviour

{
    public float LineLength = 10;
    private float RemainingLine;
    private bool IsFishing = false;
    private PlayerController controls;
    private Rigidbody2D rb;
    public FishInventory fishInventory;
    private float thrust = 0.5f; 
    //private bool returning = false;
    public bool returnCheck1 = false;
    public float hookDamage = 25f;
     
    private void Awake()
    {
        controls = new PlayerController();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
    public void Start()
    {
        //Load Stats
        using (StreamReader reader = new StreamReader("Assets/Resources/savestate.txt"))
        {

        }

            //
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        RemainingLine = LineLength;
    }

    //Save Code
    public void OnApplicationQuit()
    {
        //Save Stats
        string saveData =
            "LineLength, " + LineLength.ToString() + "\n" +
            "hookDamage, " + hookDamage.ToString() + "\n" +
            "balance, " + fishInventory.balance.ToString();
        //Write it
        using (StreamWriter writer = new StreamWriter("Assets/Resources/savestate.txt", false))
        {
            writer.Write(saveData);
            Debug.Log("yo");
        }
        
    }

    void Update()
    {
        //Update Money Counter
        
        if (IsFishing == false && controls.Hook.Cast.IsPressed() && returnCheck1 == false)
        {
            IsFishing = true;
            RemainingLine = LineLength;
            Debug.Log("Hook Cast");
        }
        if (RemainingLine <= 0)
        {
            IsFishing = false;
            if (returnCheck1 == false)
            {
                returnCheck1 = true;
            }
            //Debug.Log("Stopped Fishing");
        }
        //if (returning == true && transform.position.y <= 3.0f && returnCheck1 == false)
        //{
        //    rb.AddForce(transform.up * thrust * 10);
        //    Debug.Log("Hook Returning");
        //}
        //if (returning == true && transform.position.y >= 3.0f && returnCheck1 == false)
        //{
        //    returnCheck1 = true;
        //}
        if (returnCheck1 == true)
        {
            if (transform.position == new Vector3(0.0f, 0.0f, 0.0f))
            {
                //returning = false;
                returnCheck1 = false;
                Debug.Log("Hook Returned");
                RemainingLine = LineLength;
            }
            if (transform.position.y >= -1.0f && transform.position.y <= 1.0f && transform.position.x >= -1.0f && transform.position.x <= 1.0f)
            {
                rb.velocity = Vector3.zero;
                transform.position = new Vector3(0.0f, 0.0f, 0.0f);

                //returning = false;
                returnCheck1 = false;
                RemainingLine = LineLength;
            }
            else
            {
                Vector3 target = new Vector3(0.0f, 0.0f, 0.0f);
                Vector3 direction = target - transform.position;
                rb.AddForce(direction * thrust * 0.3f);
            }
            if (transform.position.y > 0)
            {
                thrust = 10f;
                Debug.Log("0.25");
            }
            else
            {
                thrust = 0.5f;
            }

        }
        /*if (!IsFishing && transform.position != new Vector3(transform.position.x, transform.position.y, 0.0f))
        {
            if (returning == false)
            {
                rb.AddForce(transform.up * thrust * 10);
                returning = true;
                Debug.Log("Hook Retracted");
            }
            else if (returning == true && transform.position == new Vector3(0.0f, 0.0f, 0.0f))
            {
                returning = false;
            }
        }*/

        if (IsFishing)
        {
            Movement();
        }

    }
    private void Movement()
    {
        if (RemainingLine > 0)
        {
            IsFishing = true;
            rb.AddForce(transform.up * thrust * -1);
            //Debug.Log("Moved");
            RemainingLine -= 0.005f;
            //Debug.Log(RemainingLine);
            float movement = controls.Hook.Move.ReadValue<float>();
            if (movement < 0)
            {
                rb.AddForce(transform.right * movement * thrust);
            }
            else if (movement > 0)
            {
                rb.AddForce(transform.right * movement * thrust);
            }

        }

    }

}