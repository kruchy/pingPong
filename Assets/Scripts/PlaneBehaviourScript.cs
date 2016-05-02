using UnityEngine;
using System.Collections;

public class PlaneBehaviourScript : MonoBehaviour {

    private Gyroscope gyro;

    private bool enabledGyro = false;

    static float sensitivity = 5.0F;

    private float x;
    private float y;
    public float speed = 1.5F;
    private int sizeFilter = 15;
     private Vector3[] filter;
     private Vector3 filterSum =Vector3.zero ;
    private int posFilter = 0;
     private int qSamples = 0;
    private string string1;
    private string string2;
    private string string3;
    Vector3 vec = Vector3.zero;


    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        //transform.up = -MovAverage(new Vector3(0, 1, 0));
    }

    Vector3 MovAverage(Vector3 sample)
    {
        if (qSamples == 0) filter = new Vector3[sizeFilter];
        filterSum += sample - filter[posFilter];
        filter[posFilter++] = sample;
        if (posFilter > qSamples) qSamples = posFilter;
        posFilter = posFilter % sizeFilter;
        return filterSum / qSamples;
    }

    void Update()
    {
        //transform.localEulerAngles = Input.gyro.attitude.eulerAngles;
        Vector3 vec = -MovAverage(Input.acceleration.normalized);
        
        transform.forward = vec;//-MovAverage(Input.acceleration.normalized);
    }


    void onGUI()
    {
        GUILayout.Label(vec.x + " " + vec.y + " " + vec.z);
    }

    //   float rotx = 0;
    //float roty = 0;
    //float rotz = 0;
    //float rotw = 0;


    //void Start()
    //{
    //    Input.gyro.enabled = true;
    //    Screen.orientation = ScreenOrientation.Portrait;
    //}

    //void Update()
    //{
    //    string1 = Input.gyro.attitude.ToString();
    //    string2 = Input.gyro.enabled + "";
    //    string3 = Input.gyro.gravity.ToString();

    //    rotx = Input.acceleration.x;
    //    roty = Input.acceleration.y;
    //    rotz = Input.acceleration.;
    //}
    //float speed = 10.0F;

    //void Update()
    //{
    //    Vector3 dir =Vector3.zero;

    //    dir.x = -Input.acceleration.y;
    //    dir.z = Input.acceleration.x;

    //    if (dir.sqrMagnitude > 1)
    //        dir.Normalize();

    //    dir *= Time.deltaTime;
    //    transform.Rotate(dir * speed);
    //}

}
