using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class transmover : MonoBehaviour
{
    public Transform Player;
    public PathType pathsystem = PathType.CatmullRom;

    public Vector3[] pathval = new Vector3[4];
    public Tween t;
    //public GameObject endpos;
    // Start is called before the first frame update
    void Start()
    {
        //DOMove
        //Player.transform.DOMoveX(15, 2.0f);

        //DOJump
        // Player.transform.DOJump(new Vector3(endpos, jump_power, no_of_jumps, duration, snapping true or false);

        //Player.transform.DOJump(new Vector3(endpos.transform.position.x, endpos.transform.position.y + 0.1f, endpos.transform.position.z), 5, 5, 5, false);

        //Player.transform.DORotate(new Vector3(0, 159.7f, 0), 4, RotateMode.Fast);

        //Player.transform.DOLookAt(new Vector3(endpos.transform.rotation.x, endpos.transform.rotation.y, endpos.transform.rotation.z), 1, AxisConstraint.None, Vector3.zero);
        t = Player.transform.DOPath(pathval, 8, pathsystem);
        t.SetEase(Ease.Linear).SetLoops(2);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
