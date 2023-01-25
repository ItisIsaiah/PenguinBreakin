using Cinemachine;
using UnityEngine;

public class SpinFunctionality : MonoBehaviour
{
    CinemachineFreeLook cam;
    Transform lookingAt;
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
   /* void Update()
    {
        if (cam.LookAt != null)
        {
            cam.m_XAxis.
        }
    }*/
}
