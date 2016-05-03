using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlaneBehaviourScript : MonoBehaviour {

    private Gyroscope gyro;
    public Text text;
    public Dropdown drop;
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


    public void SetSpeed(int s)
    {
        speed = s;
        text.text = "" + s;
    }

    void Start()
    {
        Input.gyro.enabled = true;

        drop.onValueChanged.AddListener(delegate { SetSpeed(drop.value); });
        Screen.orientation = ScreenOrientation.Portrait;
        //transform.up = -MovAverage(new Vector3(0, 1, 0));
        text.text = ("VAL : ");
        transform.up = new Vector3(0, 1, 0);
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
        Quaternion temp = transform.rotation;
        text.text = ("System = " + SystemInfo.supportsGyroscope + " isEnabled=" +Input.gyro.enabled + "\n\n\n INPUT :x = " + Input.gyro.attitude.x + " y= " + Input.gyro.attitude.y + "  z=" + Input.gyro.attitude.z + " w= " + Input.gyro.attitude.w +"\n\n\n");// +  "VEC:  x=" + vec.x + " y=" + vec.y + " z=" + vec.z);
        Vector3 temp2 = transform.right;
        //float clamp = vec.z - vec.x < 0.0F ? 0.0F : vec.z - vec.x > 1.0F ? 1.0F : -(vec.z - vec.x);
        //transform.Rotate(Vector3.right, -vec.y * speed);
        //transform.Rotate(Vector3.forward, vec.x * speed  );
        //transform.rotation = new Quaternion(transform.rotation.x, vec.y, vec.z, transform.rotation.w);
        //transform.rotation = Quaternion.Slerp(transform.rotation, , Time.deltaTime * speed);
        //transform.forward = -MovAverage(Input.acceleration.normalized);
        //transform.right = new Vector3(vec.x, temp2.y, temp2.z); 
        Vector3 destination = Vector3.zero;
        destination.x = Input.acceleration.normalized.y;
        destination.z = -Input.acceleration.normalized.x;
        transform.rotation = Quaternion.Euler(destination);
        transform.Rotate(destination * Time.deltaTime * 100.0F,Space.World);
            
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
