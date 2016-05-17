using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlaneBehaviourScript : MonoBehaviour {

    public Text text;
    public int tiltSpeed = 30;
    private int sizeFilter = 15;
    private Vector3[] filter;
    private Vector3 filterSum =Vector3.zero ;
    private int posFilter = 0;
    private int qSamples = 0;



    void Start()
    {
        Input.gyro.enabled = true;
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
        Vector3 vec = -MovAverage(Input.acceleration.normalized);
        transform.rotation = Quaternion.Euler(-vec.y * tiltSpeed, 0, vec.x* tiltSpeed);
    }


  

}
