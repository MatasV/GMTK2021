using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public float maxLength; //6.5
    public float currentLength;

    public Color closestColor;
    public Color farthestColor;
    
    public SharedBool isMaximumDistanceReached;
    public bool isMax; 

    public SpriteRenderer sprite;

    public Transform firstPoint;
    public Transform secondPoint;

    public float farthestScale = 0.04f;
    public float closestScale = 0.08f;
    
    private void Update()
    {
        var midPoint = new Vector3((firstPoint.position.x + secondPoint.position.x) / 2, 
            (firstPoint.position.y + secondPoint.position.y) / 2,
            (firstPoint.position.z + secondPoint.position.z) / 2);

        sprite.transform.position = midPoint;
        
        var heading = secondPoint.position - firstPoint.position;
        
        var distance = heading.magnitude;
        Debug.Log(distance);
        sprite.transform.rotation = Quaternion.LookRotation(
            Vector3.forward, // Keep z+ pointing straight into the screen.
            heading // Point y+ toward the target.
        );
        if (distance > maxLength)
        {
            isMaximumDistanceReached.Value = true;
            return;
        }
        else
        {
            isMaximumDistanceReached.Value = false;
        }

        var percentageTravelled = distance / maxLength;
        
        Debug.Log(percentageTravelled);
        Color newColor = Color.Lerp(closestColor, farthestColor, percentageTravelled);
        sprite.color = newColor;

        double convertedScaleValue = ConvertFrom_Range1_Input_To_Range2_Output(4, 6.5, 0.04, 0.08, distance);
        Debug.Log("converted " + (0.12d - convertedScaleValue) );
        //x = [0.04;0.07]
        sprite.transform.localScale = new Vector3(0.12f-(float)convertedScaleValue, distance / 2.5f,
            sprite.transform.localScale.z);

        
    }
    
    private double ConvertFrom_Range1_Input_To_Range2_Output(double _input_range_min, 
        double _input_range_max, double _output_range_min, 
        double _output_range_max, double _input_value_tobe_converted)
    {
        double diffOutputRange = Math.Abs((_output_range_max - _output_range_min));
        double diffInputRange = Math.Abs((_input_range_max - _input_range_min));
        double convFactor = (diffOutputRange / diffInputRange);
        return (_output_range_min + (convFactor * (_input_value_tobe_converted - _input_range_min)));
    }
    
}
