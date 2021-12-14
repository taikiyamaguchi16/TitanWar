using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal_E : MonoBehaviour
{

    private GameObject startPoint;
    private Vector3 startPos;
    private float intervalTime = 2.0f;
    private float initInterval = 2.0f;

    public RenderTexture renderTexture;
    public Material mat;
    public Shader shader;
    [SerializeField]
    private Camera potalCamera;
  //  private GameObject playerCamera;
    // Start is called before the first frame update
    void Start()
    {

     //   GateOpen();
        //playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
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
            startPoint.GetComponent<Potal_S>().SetIntervalTime(2.0f);
            collision.transform.position = startPoint.transform.position;
            collision.transform.rotation = new Quaternion(transform.rotation.x, startPoint.GetComponent<Potal_S>().GetCamera().transform.rotation.y, transform.rotation.z, 0);

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
    public void SetStartPos(Vector3 _pos)
    {
        startPos = _pos;
    }

    public void SetIntervalTime(float _time)
    {
        intervalTime = _time;
    }

    public void SetOtherPotalCamera(Camera cam)
    {
        potalCamera = cam;
    }
    public Camera GetCamera()
    {
        return potalCamera;
    }
    public void SetStartPoint(GameObject _s)
    {
        startPoint = _s;
    }
}
