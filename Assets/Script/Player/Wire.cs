using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Wire : MonoBehaviour
{
    [SerializeField]
    private Grab grab;
    [SerializeField]
    private SteamVR_Action_Boolean grabAction;
    [SerializeField]
    private Transform wireStart;
    [SerializeField]
    private Transform wireEnd;
    [SerializeField]
    private Transform forward;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float breakDistance;//ワイヤーが切断する距離

    private Transform target;
    private Transform defaultParent;
    private CableComponent cable;

    private Transform attachTarget;//ワイヤーを付けたオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        cable = wireStart.GetComponent<CableComponent>();
        defaultParent = wireEnd.parent;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCableLength();

        //グーしたらワイヤー出す
        if (grab.HasGrab() || grabAction.GetStateDown(SteamVR_Input_Sources.RightHand))
            StartCoroutine("Shot");

        if (attachTarget != null)
        {
            //距離長すぎるとワイヤーを切る
            float dis = Vector3.Distance(wireEnd.position, transform.position);
            if (dis >= breakDistance)
                StartCoroutine("Release");

            //パーしたらギミック発動+ワイヤーポイント消す
            if (grab.HasRelease() || grabAction.GetStateUp(SteamVR_Input_Sources.RightHand))
            {
                attachTarget.parent.GetComponentInChildren<DestrcutiveObject>().Excute();
                StartCoroutine("Release");
                Destroy(attachTarget.gameObject);
            }
        }
    }

    private void UpdateCableLength()
    {
        float length = Vector3.Distance(wireStart.position, wireEnd.position) * 0.8f;
        if (length < 0.05f)
            length = 0.05f;
        cable.SetCableLength(length);
    }

    private IEnumerator Shot()
    {
        Vector3 targetPos = forward.position;

        if (target != null)
        {
            //wire pointの裏からはくっつけないように
            float angle = Vector3.Angle(target.forward, (transform.position - target.position).normalized);
            if (angle <= 70)
            {
                targetPos = target.position;
                attachTarget = target;
            }
        }

        //ワイヤーtarget位置まで飛ばす
        Vector3 direction = (targetPos - wireEnd.position).normalized;
        float old = (targetPos - wireEnd.position).magnitude;

        while ((targetPos - wireEnd.position).magnitude <= old)
        {
            Vector3 velocity = direction * speed * Time.deltaTime;
            old = (targetPos - wireEnd.position).magnitude;

            wireEnd.position += velocity;
            yield return null;
        }

        //wire pointなかったらすぐ戻す
        if (attachTarget == null)
        {
            yield return null;
            StartCoroutine("Release");
        }
        else
        {
            wireEnd.position = targetPos;
            wireEnd.parent = target;
        }
    }

    private IEnumerator Release()
    {
        if (attachTarget != null)
            wireEnd.parent = defaultParent;

        float old = (wireStart.position - wireEnd.position).magnitude;

        //ワイヤーを手元まで戻す
        while ((wireStart.position - wireEnd.position).magnitude <= old)
        {
            Vector3 direction = (wireStart.position - wireEnd.position).normalized;
            Vector3 velocity = direction * speed * Time.deltaTime;

            old = (wireStart.position - wireEnd.position).magnitude;

            wireEnd.position += velocity;
            yield return null;
        }
        wireEnd.position = wireStart.position;

        if (attachTarget != null)
            attachTarget = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WirePoint")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(target == other.transform)
        {
            target = null;
        }
    }
}
