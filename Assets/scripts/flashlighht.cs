using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlighht : MonoBehaviour
{
    [SerializeField]
    Light light;

    [SerializeField]
    Manager manager;
    RaycastHit hit;
    public bool on, didHit;
    public float batteryPower;
    // Start is called before the first frame update
    void Start()
    {
        batteryPower = 100;
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.gameOver)
        {
            if (on)
            {
                if (!light.enabled) light.enabled = true;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
                    didHit = true;
                    //Debug.Log("Did Hit");
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.green);
                    didHit = false;
                    hit = new RaycastHit();
                    //Debug.Log("Did not Hit");
                }
                batteryPower -= 2 * Time.deltaTime;
            }
            if (Input.GetMouseButtonDown(0))
            {
                on = !on;
                light.enabled = false;
                Debug.Log("click.");
            }
        }
    }

    public RaycastHit getHit()
    {
        return hit;
    }
}
