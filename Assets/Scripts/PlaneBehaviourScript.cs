using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlaneBehaviourScript : MonoBehaviour {

    private Gyroscope gyro;
    public Text text;
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
        text.text = ("VAL : ");
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
        Vector3 temp = transform.forward;
        text.text = ("INPUT :x = " + Input.acceleration.normalized.x + " y= " + Input.acceleration.normalized.y + "  z=" + Input.acceleration.normalized.z + "\n\n\n" +  "VEC:  x=" + vec.x + " y=" + vec.y + " z=" + vec.z);
        Vector3 temp2 = transform.right;
        transform.forward = -MovAverage(Input.acceleration.normalized);
        //transform.right = new Vector3(vec.x, temp2.y, temp2.z); 
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
