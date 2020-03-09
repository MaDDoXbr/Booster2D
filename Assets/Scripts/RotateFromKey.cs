using UnityEngine;
using UnityEngine.Serialization;

public class RotateFromKey : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float RotationForce = 100f;
    public KeyCode RotateLeft = KeyCode.A;
    public KeyCode RotateRight = KeyCode.D;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.freezeRotation = true;    //controle manual da rotação
        if (Input.GetKey(RotateLeft))
        {
            //print("Rotating Right");
            transform.Rotate(Vector3.forward * RotationForce * Time.deltaTime);
        }
        else if (Input.GetKey(RotateRight))
        {
            //print("Rotating Left");
            transform.Rotate(-Vector3.forward * RotationForce * Time.deltaTime);
        }
        _rb.freezeRotation = false; //controle físico da rotação
    }
}
