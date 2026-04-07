using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public float orbitRadius = 3f;
    private LineRenderer orbitRing;
    private int LineSegments = 64;

    public float rotationSpeed = 0.05f;
    private float defaultRadius;

    void Start()
    {
        defaultRadius = orbitRadius; 

        orbitRing = GetComponent<LineRenderer>();

        //LineRenderer
        orbitRing.loop =true;
        orbitRing.startWidth = 0.05f;
        orbitRing.endWidth = 0.05f;
        orbitRing.positionCount = LineSegments+1;
        orbitRing.useWorldSpace = true;

        //white Color
        orbitRing.startColor = new Color(1f, 1f, 1f, 0.8f);
        orbitRing.endColor = new Color(1f, 1f, 1f, 0.8f);



        DrawnRing();
    }
    void Update()
    {
        transform.Rotate(0,-rotationSpeed,0);
    }
    public void DrawnRing()
    {
        for( int i =0; i<=LineSegments; i++)
        {
            float angle = (i/(float)LineSegments)*360f*Mathf.Deg2Rad;
            float x = transform.position.x + Mathf.Cos(angle) * orbitRadius;
            float z = transform.position.z + Mathf.Sin(angle) * orbitRadius;

            orbitRing.SetPosition(i,new Vector3(x,transform.position.y,z));
        }
    }
    public void SetRadius(float radius)
    {
        orbitRadius = radius;
        DrawnRing();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpaceShip"))
        {
            ResetRadius();
            Debug.Log(" Reset radius");
        }
    }
    void ResetRadius()
    {
        orbitRadius = defaultRadius;
        DrawnRing();
    }
        

}
