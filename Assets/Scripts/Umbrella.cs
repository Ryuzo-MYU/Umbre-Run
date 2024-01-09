using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Umbrella : MonoBehaviour
{
    public bool isOpen; //�P�̊J���
    public string direction; // �P�̕����BUp, Down, Right, Left��4��
    [SerializeField] float threshold; //dir�����肷��ۂ́A�P�̊p�x��臒l

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
    ///     �I�u�W�F�N�g���}�E�X�̕����Ɍ�����
    /// </summary>
    private void LookMouse()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - pos);
        transform.localRotation = rotation;
    }

    /// <summary>
    ///     threshold�ɉ����āAtransform�̊p�x����㉺���E�����肷��
    /// </summary>
    /// <param name="threshold">�ǂ̊p�x�܂łŋ�؂邩��臒l</param>
    /// <returns>Up, Leftm Down, Right �̂�����1��(String)</returns>
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

}
