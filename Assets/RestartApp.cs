using UnityEngine;
using System.Collections;

public class RestartApp : MonoBehaviour {

    public void Restart()
    {
    }


    public void CreateSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.AddComponent<Rigidbody>();
        sphere.transform.position = new Vector3(Random.Range(-4.0F, 4.0F), 4, Random.Range(-4.0F, 4.0F));
    }

    public void Exit()
    {
        Application.Quit();
    }

}
