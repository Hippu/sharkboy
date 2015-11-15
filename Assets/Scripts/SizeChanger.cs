using UnityEngine;
using System.Collections;

public class SizeChanger : MonoBehaviour
{
    public float growingSpeed;
    public float growthFactor = 1.0f;
    public float incrementAmount;
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

    private void Grow()
    {
        if (Mathf.Abs(transform.localScale.x) < growthFactor * originalSize.x)
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

    private void Shrink()
    {
        if (Mathf.Abs(transform.localScale.x) > growthFactor * originalSize.x)
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

    public void setGrowthFactor(float value)
    {
        if (value > growthFactor)
        {
            currentState = State.Growing;
        } else {
            currentState = State.Shrinking;
        }
        growthFactor = value;
    }

    public void Increment()
    {
        setGrowthFactor(growthFactor + incrementAmount);
    }

    public void Decrement()
    {
        setGrowthFactor(growthFactor - incrementAmount);
    }


}
