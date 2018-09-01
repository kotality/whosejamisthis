using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{
    public ControlNode topLeft, topRight, bottomRight, bottomLeft;
    public Node centerTop, centerRight, centerBottom, centerLeft;
    public int configuration;

    public Square(ControlNode topL, ControlNode topR, ControlNode bottomR, ControlNode bottomL)
    {
        topLeft = topL;
        topRight = topR;
        bottomRight = bottomR;
        bottomLeft = bottomL;

        centerTop = topLeft.right;
        centerRight = bottomRight.above;
        centerBottom = bottomLeft.right;
        centerLeft = bottomLeft.above;

        if (topLeft.active)
        {
            configuration += 8;
        }
        if (topRight.active)
        {
            configuration += 4;
        }
        if (bottomRight.active)
        {
            configuration += 2;
        }
        if (bottomLeft.active)
        {
            configuration += 1;
        }
    }
}