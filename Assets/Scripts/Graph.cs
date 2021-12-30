using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graph : MonoBehaviour
{
    public Image pointPrefab;
    public RectTransform graphPanel;
    private int storedQuality;
    public List<Image> points = new List<Image>();

    public void createPoints(List<double> startingValues, int quality) //The value at index 0 will be the rightmost point.
    {
        if (startingValues.Count != quality)
        {
            Debug.Log("Wrong amount of values in initialValues!");
        }
        else
        {
            storedQuality = quality;
            for (int i = 0; i < quality; i++)
            {
                var point = Instantiate(pointPrefab);
                point.transform.SetParent(graphPanel.transform, worldPositionStays:false);
                var pointRT = point.transform as RectTransform;
                pointRT.sizeDelta = new Vector2(pointRT.sizeDelta.x, (float)startingValues[storedQuality-i-1]); ///Change the height instead of the scale which was causing problems
                points.Add(point);
            }
        }
    }

    public void updatePoints(List<double> newValues, double dividingScale) //Same thing here, leftmost values of array go to the right most point.
    {
        if (newValues.Count != storedQuality)
            Debug.Log("newValues length does not match the stored quality!");
        for (int i = 0; i < storedQuality; i++)
        {
            var point = points[i];
            var pointRT = point.transform as RectTransform;
            pointRT.sizeDelta = new Vector2(pointRT.sizeDelta.x, (float)newValues[storedQuality-i-1]/(float)dividingScale);
        }
    }
    
}
