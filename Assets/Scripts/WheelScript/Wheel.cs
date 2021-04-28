using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    public int k = 0;
    public Text labelAwards;
    public float rotateSpeed = 360;
    public float rotateDccelerationSpeed = 60;
    public string[] awards;
    float currentSpeed;
    private void Start()
    {
        labelAwards.text = "";
    }
    public void Rotate()
    {
        if (currentSpeed > 0) return;
        currentSpeed = rotateSpeed* Random.Range(0.5f,1);
        labelAwards.text = "";
        k++;
    }
    void Update()
    {
        //Random.Range(60,100)    rotateDccelerationSpeed
        transform.Rotate(0, 0, currentSpeed * Time.deltaTime);
        currentSpeed -= rotateDccelerationSpeed * Time.deltaTime;
        if (currentSpeed < 0)
        {
            
            currentSpeed = 0;
            var sector = transform.rotation.eulerAngles.z * awards.Length / 360;
            var awardIndex = Mathf.RoundToInt(sector);
            if (k>=1)
                labelAwards.text = awards[awardIndex].ToString();

        }

    }
}
