using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClearPoint : MonoBehaviour
{
    [SerializeField]
    private Transform collection;
    [SerializeField]
    private ParticleSystem effect;
    [SerializeField]
    private GameObject model;

    public delegate void CollectKeyHandler();
    public CollectKeyHandler OnCollectKey;

    public int KeyNum { get; private set; }
    public int MaxKeyNum { get; private set; }

    private void OnDisable()
    {
        OnCollectKey = null;
    }

    // Start is called before the first frame update
    void Awake()
    {
        MaxKeyNum = FindObjectsOfType<Key>().Length;
        KeyNum = 0;

        OnCollectKey += (() => SetKeyNum());
    }

    private void SetKeyNum()
    {
        KeyNum = collection.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ClearEffect()
    {
        model.transform.DORotate(new Vector3(0, 180, 0), 1f).SetLoops(-1).SetEase(Ease.Linear);
        model.GetComponent<MeshRenderer>().material.DOColor(Color.white, 1f);
        yield return new WaitForSeconds(0.5f);

        foreach (Key k in FindObjectsOfType<Key>())
        {
            k.MoveToClearPoint(transform);
            yield return new WaitForSeconds(0.3f);
        }
        GetComponent<Collider>().enabled = false;
        
        yield return new WaitForSeconds(0.3f);
        effect.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && KeyNum >= MaxKeyNum)
            StartCoroutine("ClearEffect");
    }
}
