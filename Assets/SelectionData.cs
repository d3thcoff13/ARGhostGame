using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionData : MonoBehaviour
{
    [SerializeField]
    public int sizeX, sizeY, sizeZ;
    [SerializeField]
    InputField l, w, h;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (sizeX != 0) w.text = sizeX.ToString();
        if (sizeY != 0) h.text = sizeY.ToString();
        if (sizeZ != 0) l.text = sizeZ.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBounds()
    {
        sizeZ = int.Parse(l.text);
        sizeX = int.Parse(w.text);
        sizeY = int.Parse(h.text);
    }
}
