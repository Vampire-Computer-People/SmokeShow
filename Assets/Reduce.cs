﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reduce : MonoBehaviour
{

    private Material m_Material;    // Used to store material reference.
    private TriggerableElement element;
    [SerializeField]
    private Color unityColor = new Color(0, 0, 0, 0);
    [SerializeField]
    private float reduceAmp = 1;
    [SerializeField]
    private float baseAlpha = .5f;

    // Use this for initialization
    void Start()
    {
        element = GetComponent<TriggerableElement>();
        // Get reference to object's material.
        m_Material = GetComponent<Renderer>().material;

        m_Material.color = unityColor;
    }

    void Update()
    {
        if (element.state == States.ACTIVE)
        {
            float alpha = (baseAlpha - (MessageBus.calcedAlpha * reduceAmp));
            if (alpha < .1f)
            {
                alpha = .1f;
            }
            m_Material.color = new Color(unityColor.r, unityColor.g, unityColor.b, alpha);
        }
    }

    public void IncrementSensitivityDivision()
    {
        if (reduceAmp == -.1f)
        {
            reduceAmp += .2f;
        }
        else if (reduceAmp >= 3)
        {

        }
        else
        {
            reduceAmp += .1f;
        }
    }

    public void DecrementSensitivityDivision()
    {
        if (reduceAmp <= .1f)
        {
            
        }
        else
        {
            reduceAmp -= .1f;
        }
    }

}
