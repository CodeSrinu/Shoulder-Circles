using UnityEngine;

public class ShipInputController : MonoBehaviour
{
    public float orbitRadius = 3f;      
    public float minOrbitRadius = 1f;   
    public float maxOrbitRadius = 5f;   
    public float radiusChangeRate = 1f; 

    public float OrbitSpeed = 1f;
    private float CurrentAngle=0f;
    public float switchDistance =5f;
    public Planet currentPlanet;

    public Planet[] allPlanets;
    void Start()
    {
         currentPlanet = allPlanets[0];
    }
    void Update()
    {
       HandleRadiusInput();
       MoveShip();
       CheckForNearPlanet();

    }

    void HandleRadiusInput()
    {
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

    void MoveShip()
    {
        CurrentAngle+=OrbitSpeed*Time.deltaTime;

        float x = currentPlanet.transform.position.x + Mathf.Cos(CurrentAngle) * orbitRadius;
        float z = currentPlanet.transform.position.z + Mathf.Sin(CurrentAngle) * orbitRadius;
        float y = currentPlanet.transform.position.y;

        transform.position = new  Vector3(x,0,z);
        
    }

    void CheckForNearPlanet()
    {
        Planet nearestPlanet = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Planet planet in allPlanets)
        {
            if (planet == currentPlanet) continue;

            float distance = Vector3.Distance(transform.position, planet.transform.position);

            if (distance < switchDistance && distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPlanet = planet;
            }
        }

        if (nearestPlanet != null)
        {
            SwitchToPlanet(nearestPlanet);
        }
    }
    void SwitchToPlanet(Planet planet)
    {
        currentPlanet = planet;
        orbitRadius = planet.orbitRadius; 
        CurrentAngle = 0f; 
        Debug.Log("Now orbiting: " + planet.gameObject.name);
        CamSwitch.instance.SwitchCamToPlanet(planet);
    }
}