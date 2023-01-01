using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] MonsterHP health;
    [SerializeField] Slider slider;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion inverseParentRotation = Quaternion.Inverse(transform.parent.rotation);
        Quaternion rotationToCamera = Camera.main.transform.rotation;

        transform.localRotation = inverseParentRotation * rotationToCamera;

        if (health != null)
        {
            slider.value = health.currentHP / (float) health.maxHP;
        }

    }
}
