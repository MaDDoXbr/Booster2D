using UnityEngine;

public class RotateFromKey : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float rotationForce = 100f;
    public KeyCode rotateCwKey = KeyCode.A;
    public KeyCode rotateCcwKey = KeyCode.D;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.freezeRotation = true;    //controle manual da rotação
        if (Input.GetKey(rotateCwKey))
        {
            //print("Rotating Right");
            transform.Rotate(Vector3.forward * rotationForce * Time.deltaTime);
        }
        else if (Input.GetKey(rotateCcwKey))
        {
            //print("Rotating Left");
            transform.Rotate(-Vector3.forward * rotationForce * Time.deltaTime);
        }
        _rb.freezeRotation = false; //controle físico da rotação
    }
}
