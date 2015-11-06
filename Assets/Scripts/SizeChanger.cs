using UnityEngine;
using System.Collections;

public class SizeChanger : MonoBehaviour
{
    private int currentSize = 1;
    public int maxSize;
    public float growingSpeed;
    public float growthFactor;
    private int targetSize;
    private Vector3 originalSize;
    private enum State
    {
        None,
        Growing,
        Shrinking
    }
    private State currentState = State.None;
    // Use this for initialization

    void Start()
    {
        targetSize = currentSize;
        originalSize = new Vector3(
            Mathf.Abs(this.transform.localScale.x),
            Mathf.Abs(this.transform.localScale.y)
        );
        currentState = State.Growing;
    }

    // Update is called once per frame
    void Update()
    {
        switch (this.currentState)
        {
            case State.Growing: { Grow(); return; }
            case State.Shrinking: { Shrink(); return; }
            case State.None: { return; }
        }
    }

    void Grow()
    {
        if (Mathf.Abs(transform.localScale.x) < targetSize * growthFactor * originalSize.x)
        {
            if (transform.localScale.x > 0.0f)
            {
                transform.localScale += new Vector3(growingSpeed, growingSpeed);
            }
            else
            {
                transform.localScale += new Vector3(-growingSpeed, growingSpeed);
            }
        }
        else
        {
            currentState = State.None;
        }
    }

    void Shrink()
    {
        if (Mathf.Abs(transform.localScale.x) > targetSize * growthFactor * originalSize.x)
        {
            if (transform.localScale.x > 0.0f)
            {
                transform.localScale -= new Vector3(growingSpeed, growingSpeed);
            }
            else
            {
                transform.localScale -= new Vector3(-growingSpeed, growingSpeed);
            }
        }
        else
        {
            currentState = State.None;
        }
    }

    public void setTargetSize(int value)
    {
        targetSize = value;
        if (value > currentSize)
        {
            currentState = State.Growing;
        } else {
            currentState = State.Shrinking;
        }
    }


}
