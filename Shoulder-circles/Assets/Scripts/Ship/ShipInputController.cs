using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShipInputController : MonoBehaviour
{
    
    public float orbitRadius = 3f;
    public float OrbitSpeed = 10f;
    private float CurrentAngle = 0f;

    private Planet currentPlanet;
    Planet previousPlanet;
    public Planet[] allPlanets;
    public float switchDistance = 5f;

    public float radiusChangeRate = 1f;
    public float minOrbitRadius = 1f;
    public float maxOrbitRadius = 5f;

    float rotationProgress = 0f;
    float lastAngle = 0f;
    bool canLeaveOrbit = false;
    private bool isOrbiting = true;
    bool hasReleased = false;

    
    private Vector3 velocity;

    void Start()
    {
        currentPlanet = allPlanets[0];
    }

    void Update()
    {
        HandleInput();
        MoveShip();
        CheckForNearPlanet();
    }

    
    void HandleInput()
    {
        
        if (isOrbiting)
        {
            float deltaAngle = Mathf.Abs(CurrentAngle - lastAngle);
            rotationProgress += deltaAngle;
            lastAngle = CurrentAngle;


            if (Input.GetKey(KeyCode.W))
            {
                orbitRadius -= radiusChangeRate * Time.deltaTime;
                orbitRadius = Mathf.Clamp(orbitRadius, minOrbitRadius, maxOrbitRadius);
                currentPlanet.SetRadius(orbitRadius);
            }

            if (Input.GetKey(KeyCode.S))
            {
                orbitRadius += radiusChangeRate * Time.deltaTime;
                orbitRadius = Mathf.Clamp(orbitRadius, minOrbitRadius, maxOrbitRadius);
                currentPlanet.SetRadius(orbitRadius);
            }
        }
        
        if (rotationProgress> Mathf.PI * 2f)
        {
            canLeaveOrbit = true;
            Debug.Log("can switch the planet");
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            hasReleased = true;
            if (canLeaveOrbit)
            {
                ReleaseFromOrbit(); 
            }
            else
            {
                velocity = transform.right*OrbitSpeed;
                isOrbiting = false;
                Debug.Log("Game Over");
            }
        }
    }

    
    void MoveShip()
    {
        if (isOrbiting)
        {
            
            CurrentAngle += OrbitSpeed * Time.deltaTime;

            float x = currentPlanet.transform.position.x + Mathf.Cos(CurrentAngle) * orbitRadius;
            float z = currentPlanet.transform.position.z + Mathf.Sin(CurrentAngle) * orbitRadius;

            transform.position = new Vector3(x, 0, z);

            
            transform.LookAt(currentPlanet.transform.position);
            transform.Rotate(0, 90f, 0);
        }
        else
        {
            
            transform.position += velocity * Time.deltaTime;
        }
    }

    
    void ReleaseFromOrbit()
    {
        isOrbiting = false;

        Planet targetPlanet = GetNearestPlanet();

        Vector3 direction = (targetPlanet.transform.position - transform.position).normalized;
        transform.forward = direction;

        velocity = direction*OrbitSpeed;
        
        
    }

    
    void CheckForNearPlanet()
    {
        Planet nearestPlanet = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Planet planet in allPlanets)
        {
            if (planet == currentPlanet || planet == previousPlanet) continue;


            float distance = Vector3.Distance(transform.position, planet.transform.position);

            if (distance < switchDistance && distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPlanet = planet;
            }
        }

        
        if (nearestPlanet != null && !isOrbiting && hasReleased)
        {
            if (canLeaveOrbit)
            {
                SwitchToPlanet(nearestPlanet);
            }
            else
            {
                Debug.Log("Rejected! You didn’t complete 360°");

            }
        }

    }

    
    void SwitchToPlanet(Planet planet)
    {
        currentPlanet = planet;
        orbitRadius = planet.orbitRadius;
        previousPlanet = currentPlanet;

        
        Vector3 dir = transform.position - planet.transform.position;
        CurrentAngle = Mathf.Atan2(dir.z, dir.x);

        isOrbiting = true;

        Debug.Log("Now orbiting: " + planet.name);

        CamSwitch.instance.SwitchCamToPlanet(planet);
    }

    Planet GetNearestPlanet()
    {
        Planet nearestPlanet = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Planet planet in allPlanets)
        {
            if (planet == currentPlanet || planet == previousPlanet) continue;

            float distance = Vector3.Distance(transform.position, planet.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPlanet = planet;
            }
        }

        return nearestPlanet;
    }
}