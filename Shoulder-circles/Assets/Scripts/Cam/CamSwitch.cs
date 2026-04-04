using UnityEngine;
public class CamSwitch : MonoBehaviour
{
    public static CamSwitch instance;
    public Vector3 offset = new Vector3(0, 3, -6);
    private void Awake()
    {
        instance = this;
    }
    public void SwitchCamToPlanet(Planet planet)
    {
        Transform planetTf = planet.transform;
        transform.position = planetTf.position + offset;
        transform.LookAt(planetTf.position);
    }
}