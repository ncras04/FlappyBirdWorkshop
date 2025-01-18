using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float _lerpFactor;
    public float _upRotateAngle = 30.0f;
    public float _downRotateAngle;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.freezeRotation = true;
        _rigidbody.rotation = 0;
    }

    private void Update()
    {
        if (_rigidbody.linearVelocityY > 0.01)
            _rigidbody.transform.rotation = RotateTransform(_upRotateAngle, _lerpFactor * 10 * Time.deltaTime);

        if (_rigidbody.linearVelocityY < -0.01)
            _rigidbody.transform.rotation = RotateTransform(-_downRotateAngle, _lerpFactor * Time.deltaTime);

    }
    private Quaternion RotateTransform(float angle, float lerpFactor)
    {
        return Quaternion.Lerp(_rigidbody.transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), lerpFactor);
    }
}
