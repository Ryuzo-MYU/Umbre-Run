using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Umbrella : MonoBehaviour
{
    private bool isOpen; //傘の開閉状態
    private string direction; // 傘の方向。Up, Down, Right, Leftの4種
    [SerializeField] float threshold; //dirを決定する際の、傘の角度の閾値

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
        direction = GetDirWithDeg(threshold);
        //Debug.Log("Direction: " + transform.rotation.eulerAngles + " dir: " + direction);
    }

    /// <summary>
    ///     オブジェクトをマウスの方向に向ける
    /// </summary>
    private void LookMouse()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;
    }

    /// <summary>
    ///     thresholdに応じて、transformの角度から上下左右を決定する
    /// </summary>
    /// <param name="threshold">どの角度までで区切るかの閾値</param>
    /// <returns>Up, Leftm Down, Right のうちの1つ(String)</returns>
    private string GetDirWithDeg(float threshold)
    {
        string umbrellaDir = "";
        float angle = transform.rotation.eulerAngles.z;
        var t = threshold;
        if (angle < t) { umbrellaDir = "Up"; }
        else if (angle < 3 * t) { umbrellaDir = "Left"; }
        else if (angle < 5 * t) { umbrellaDir = "Down"; }
        else if (angle < 7 * t) { umbrellaDir = "Right"; }
        else { umbrellaDir = "Up"; }

        return umbrellaDir;
    }

    public string GetDirection()
    {
        return direction;
    }

    public bool GetIsOpen()
    {
        return isOpen;
    }

}
