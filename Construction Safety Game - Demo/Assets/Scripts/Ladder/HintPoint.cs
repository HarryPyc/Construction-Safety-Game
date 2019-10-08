using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct HintPointStruct
{
    public Vector3 position;
    public Vector3 normal;

    // 1 - Ladder
    public int label;

    // Constructor
    public HintPointStruct(Vector3 p, Vector3 n, int l)
    {
        position = p;
        normal = n;
        label = l;
    }
};

public class HintPoint : MonoBehaviour
{
    #region Fields

    [SerializeField] Material normalMat;
    [SerializeField] Material hoverMat;
    private Vector3 position;
    private Vector3 normal;
    private int label;

    UndecidedLadderAdded undecidedLadderAdded;

    #endregion

    #region Properties

    public void SetNormal(Vector3 value)
    {
        this.normal = value;
    }

    public void SetPosition(Vector3 value)
    {
        this.position = value;
    }

    public void SetLabel(int value)
    {
        this.label = value;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        undecidedLadderAdded = new UndecidedLadderAdded();
        EventManager.AddUndecidedLadderInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material = hoverMat;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material = normalMat;
    }

    void OnMouseUp()
    {
        undecidedLadderAdded.Invoke(position, normal);
    }

    
    public void AddUndecidedLadderListener(UnityAction<Vector3, Vector3> listener)
    {
        undecidedLadderAdded.AddListener(listener);
    }
}
