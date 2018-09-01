using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Vector3 position;
    public int vertexIndex = -1;

    public Node(Vector3 pos)
    {
        position = pos;
    }
}

public class ControlNode : Node
{
    public bool active;
    public Node above, right;

    public ControlNode(Vector3 pos, bool _active, float squareSize) : base(pos)
    {
        active = _active;
        above = new Node(position + Vector3.forward * squareSize / 2f);
        right = new Node(position + Vector3.right * squareSize / 2f);
    }
}