using Unity.Mathematics;
using UnityEngine;

public class CupHandler : MonoBehaviour
{
    public Transform canTransform;
    public Transform cupEdgeL;
    public Transform cupEdgeR;
    public Transform pourPoint;

    private float maxVolume = 1500f;
    private float curBubble = 0f;
    private float curFluid = 0f;

    //temp
    private float fluidSpeed = 10f;
    private float bubbleSpeed = 5f;

    public Transform fluid;
    public Transform bubble;
    private float maxFluidHeight = 5f;

    private float thresholdAngle = 100f;
    private float speedFactor = 0.2f;

    private void Start() {
        AdjustScale();
    }

    private void FixedUpdate() {
        // Debug.Log(cupEdgeL.position.x);
        float fluidSpeed = GetPouringSpeed(canTransform.eulerAngles.z);
        float bubbleSpeed = GetPouringSpeed(canTransform.eulerAngles.z)/2;
        if(pourPoint.position.x >= cupEdgeL.position.x && pourPoint.position.x <= cupEdgeR.position.x){
            curFluid += fluidSpeed;
            curBubble += bubbleSpeed;
            //over-pour should trigger some stuff in game manager, this is temp solution
            curFluid = math.min(maxVolume, curFluid);
            curBubble = math.min(maxVolume, curBubble);
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
        if (tiltAngle <= thresholdAngle){
            return 0f;
        }
        else{
            return (tiltAngle - thresholdAngle) * speedFactor;
        }
    }
}
