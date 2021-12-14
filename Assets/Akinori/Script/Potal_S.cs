using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal_S : MonoBehaviour
{

    private GameObject endPoint;
    private Vector3 endPos;
    public float intervalTime = 2.0f;
    public float initInterval = 2.0f;
    public RenderTexture renderTexture;
    public Material mat;
    public Shader shader;
    [SerializeField]
    private Camera potalCamera;

    //private GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (intervalTime > 0)
        {
            intervalTime -= Time.deltaTime;
        }
        //potalCamera.transform.localRotation = playerCamera.transform.localRotation;


    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.transform.tag == "Player" && intervalTime <= 0)
        {

            endPoint.GetComponent<Potal_E>().SetIntervalTime(2.0f);

            collision.transform.position = endPoint.transform.position;
            collision.transform.rotation = new Quaternion(transform.rotation.x, endPoint.GetComponent<Potal_E>().GetCamera().transform.rotation.y, transform.rotation.z, 0);
        }
    }

    public void GateOpen()
    {
        renderTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        renderTexture.name = "GateTex";

        renderTexture.Create();
        potalCamera.targetTexture = renderTexture;
        mat = new Material(shader);
        mat.name = "renderMaterial";
        mat.SetTexture("tex", renderTexture);
        mat.mainTexture = renderTexture;
        gameObject.GetComponent<Renderer>().material = mat;
    }
    public void SetEndPos(Vector3 _pos)
    {
        endPos = _pos;
    }

    public void SetIntervalTime(float _time)
    {
        intervalTime = _time;
        initInterval = _time;
    }
    public Camera GetCamera()
    {
        return potalCamera;
    }
    public void SetOtherPotalCamera(Camera cam)
    {
        potalCamera = cam;
    }

    public void SetEndPoint(GameObject _e)
    {
        endPoint = _e;
    }
}
