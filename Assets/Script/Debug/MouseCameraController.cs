using UnityEngine;
using System.Collections;

/// <summary>
/// マウスでカメラの位置、回転を制御する
/// </summary>
public class MouseCameraController : MonoBehaviour
{
    enum DragType
    {
        Move,
        Rotate,
    }

    private bool _isDragging = false;
    private Vector3 _prevPos = Vector3.zero;
    private DragType _currenType;
    private float _speedLimit = 100f;
    private Quaternion _originalRot;

    private float _x = 0f;
    private float _y = 0f;

    [SerializeField]
    [Range(0f, 10f)]
    private float _moveSpeed = 5f;

    [SerializeField]
    [Range(0f, 10f)]
    private float _rotateSpeed = 5f;

    [SerializeField] [Range(10f, 30f)] private float moveSpeedByKey = 20f;

    [SerializeField]
    private Transform _controlTarget;
    private Transform ControlTarget
    {
        get
        {
            if (!_controlTarget)
            {
                _controlTarget = transform;
            }

            return _controlTarget;
        }
    }


    #region MonoBehaviour
    void Start()
    {
        _originalRot = ControlTarget.rotation;
    }

    void Update()
    {
        float wheelval = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = ControlTarget.position;
        pos += ControlTarget.forward * wheelval * 2f;
        ControlTarget.position = pos;

        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown(DragType.Move);
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnMouseDown(DragType.Rotate);
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            OnMouseUp();
        }

        OnMouseMove();

        MoveCamera();
    }
    #endregion
    private void MoveCamera()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime* moveSpeedByKey;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeedByKey;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * moveSpeedByKey;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeedByKey;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += transform.up * Time.deltaTime * moveSpeedByKey;
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.position -= transform.up * Time.deltaTime * moveSpeedByKey;
        }
    }

    void OnMouseDown(DragType type)
    {
        _isDragging = true;
        _currenType = type;
        _prevPos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        _isDragging = false;
    }

    void OnMouseMove()
    {
        if (!_isDragging)
        {
            return;
        }

        Vector3 delta = Input.mousePosition - _prevPos;
        _prevPos = Input.mousePosition;

        switch (_currenType)
        {
            case DragType.Move:
                delta *= (_moveSpeed / _speedLimit);

                Vector3 pos = ControlTarget.position;
                pos += ControlTarget.up * -delta.y;
                pos += ControlTarget.right * delta.x;

                ControlTarget.position = pos;

                return;

            case DragType.Rotate:
                delta *= (_rotateSpeed / _speedLimit);

                _x += delta.x;
                if (_x <= -180)
                {
                    _x += 360;
                }
                else if (_x > 180)
                {
                    _x -= 360;
                }

                _y -= delta.y;
                _y = Mathf.Clamp(_y, -85f, 85f);

                ControlTarget.rotation = _originalRot * Quaternion.Euler(_y, _x, 0f);

                return;
        }

    }
}