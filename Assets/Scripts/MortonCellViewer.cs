﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MortonCellViewer : MonoBehaviour
{
    public float Width;
    public float Height;
    public float Depth;
    public int Division;

    private float _unitWidth;
    private float _unitHeight;
    private float _unitDepth;

    private Color _normalColor = new Color(1f, 0, 0, 0.5f);
    private Color _centerColor = new Color(0, 0, 1f, 1f);

    void Start()
    {
        // ひとつの区間の単位
        _unitWidth = Width / Division;
        _unitHeight = Height / Division;
        _unitDepth = Depth / Division;
    }

    /// <summary>
    /// On draw gizomos.
    /// </summary>
    void OnDrawGizmos()
    {
        Vector3 tow = transform.right * Width;
        Vector3 toh = transform.up * Height;
        Vector3 tod = transform.forward * Depth;

        int halfDivision = Division / 2;

        for (int i = 0; i <= Division; i++)
        {
            for (int j = 0; j <= Division; j++)
            {
                if (i == halfDivision || j == halfDivision)
                {
                    Gizmos.color = _centerColor;
                }
                else
                {
                    Gizmos.color = _normalColor;
                }
                Vector3 offset = (transform.right * _unitWidth * i) + (transform.up * _unitHeight * j);
                Vector3 from = transform.position + offset;
                Vector3 to = from + tod;
                Gizmos.DrawLine(from, to);
            }
        }

        for (int i = 0; i <= Division; i++)
        {
            for (int j = 0; j <= Division; j++)
            {
                if (i == halfDivision || j == halfDivision)
                {
                    Gizmos.color = _centerColor;
                }
                else
                {
                    Gizmos.color = _normalColor;
                }
                Vector3 offset = (transform.forward * _unitDepth * i) + (transform.up * _unitHeight * j);
                Vector3 from = transform.position + offset;
                Vector3 to = from + tow;
                Gizmos.DrawLine(from, to);
            }
        }

        for (int i = 0; i <= Division; i++)
        {
            for (int j = 0; j <= Division; j++)
            {
                if (i == halfDivision || j == halfDivision)
                {
                    Gizmos.color = _centerColor;
                }
                else
                {
                    Gizmos.color = _normalColor;
                }
                Vector3 offset = (transform.forward * _unitDepth * i) + (transform.right * _unitWidth * j);
                Vector3 from = transform.position + offset;
                Vector3 to = from + toh;
                Gizmos.DrawLine(from, to);
            }
        }
    }
}