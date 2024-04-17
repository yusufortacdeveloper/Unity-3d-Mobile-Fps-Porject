using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway ayarlarý")]
    [SerializeField] private float smooth;
    [SerializeField] private float sway_multiplier;

    public FloatingJoystick joystick; 


    private void Update()
    {

        float mouseX = joystick.Horizontal * sway_multiplier;
        float mouseY = joystick.Vertical * sway_multiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }

}
