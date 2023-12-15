using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Umbrella : MonoBehaviour
{
    public bool isOpen; //傘の開閉状態
    [SerializeField] float threshold; //dirを判別する際の閾値
    public string dir; //傘の向き。Up, Down, Right, Leftの4パターン

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isOpen = !isOpen;
            if (isOpen) { Debug.Log("Umbrella is Open"); }
            else { Debug.Log("Umbrella is Close"); }
        }
    }

    private void FixedUpdate()
    {
        LookMouse();
        dir = GetDirWithDeg(threshold);
        Debug.Log("Direction: " + transform.rotation.eulerAngles + " dir: " + dir);
    }

    private void LookMouse()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;
    }

    private string GetDirWithDeg(float threshold)
    {
        string umbrellaDir = "";
        float angle = transform.rotation.eulerAngles.z;
        var t = threshold / 2;
        //角度を判定
        if (angle < t) { umbrellaDir = "Up"; }
        else if (angle < 3 * t) { umbrellaDir = "Left"; }
        else if (angle < 5 * t) { umbrellaDir = "Down"; }
        else if (angle < 7 * t) { umbrellaDir = "Right"; }
        else { umbrellaDir = "Up"; }

        return umbrellaDir;
    }

}
