using Unity.Mathematics;
using UnityEngine;
using TMPro;

public class CupHandler : MonoBehaviour
{
    public Transform canTransform;
    public Transform cupEdgeL;
    public Transform cupEdgeR;
    public Transform pourPoint;

    private float maxVolume = 1500f;
    private float curBubble = 0f;
    private float curFluid = 0f;

    public Transform fluid;
    public Transform bubble;
    private float maxFluidHeight = 5f;

    private float thresholdAngle = 105f;
    private float speedFactor = 0.05f;

    public Sprite drip;
    public Sprite stream;
    public SpriteRenderer streamRenderer;
    private float streamThreshold = 1f;

    private void Start() {
        Restart();
    }

    private void Update() {
        float fluidSpeed = GetPouringSpeed(canTransform.eulerAngles.z);
        float bubbleSpeed = GetPouringSpeed(canTransform.eulerAngles.z)/2;
        //Debug.Log(fluidSpeed);
        if(fluidSpeed > streamThreshold){
            streamRenderer.sprite = stream;
        }
        else if(fluidSpeed > 0){
            streamRenderer.sprite = drip;
        }
        else{
            streamRenderer.sprite = null;
        }
        if(pourPoint.position.x >= cupEdgeL.position.x && pourPoint.position.x <= cupEdgeR.position.x){
            curFluid += fluidSpeed;
            curBubble += bubbleSpeed;
            AdjustScale();
        }
    }

    private void AdjustScale(){
        float fluidScale = curFluid/maxVolume*maxFluidHeight;
        fluid.localScale = new Vector3(1, fluidScale, 1);
        float bubbleScale = curBubble/maxVolume*maxFluidHeight;
        if(fluidScale!=0) bubbleScale/=fluidScale;
        bubble.localScale = new Vector3(1, bubbleScale, 1);
    }

    private float GetPouringSpeed(float tiltAngle)
    {
        if (tiltAngle <= thresholdAngle) return 0f;
        else{
            return (tiltAngle - thresholdAngle) * speedFactor;
        }
    }

    public bool IsFull(){
        return curBubble+curFluid > maxVolume;
    }

    public float GetPercentage(){
        if((curBubble+curFluid)/maxVolume < 0.8f) return -1f;
        return curBubble/(curBubble+curFluid);
    }

    public void Restart(){
        curBubble = 0f;
        curFluid = 0f;
        AdjustScale();
    }
}
