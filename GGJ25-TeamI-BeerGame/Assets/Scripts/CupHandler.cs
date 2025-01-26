using Unity.Mathematics;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Collections;

public class CupHandler : MonoBehaviour
{
    public Transform canTransform;
    public Transform cupEdgeL;
    public Transform cupEdgeR;
    public Transform pourPoint;

    private float maxVolume = 200000f;
    private float curBubble = 0f;
    private float curFluid = 0f;

    public Transform fluid;
    public Transform bubble;
    private float maxFluidHeight;
    public Sprite drip;
    public Sprite stream;
    private float fluidSpeed = 0f;
    private float bubbleSpeed = 0f;
    public SpriteRenderer streamRenderer;
    private float streamThreshold = 30f;

    private Bottles chosenBottle;

    public SpriteRenderer dotLineRenderer;
    public Cups chosenCup;
    public GameObject spill;
    [SerializeField] private bool spilled = false;

    // private float bubbleDecayRate = 0.01f;

    private void Start() {
        Restart();
    }

    private void Update() {
        List<float> getSpeed = GetPouringSpeed(canTransform.eulerAngles.z);
        fluidSpeed = getSpeed[0];
        bubbleSpeed = getSpeed[1];
        //Debug.Log((fluidSpeed+bubbleSpeed));
        if((fluidSpeed+bubbleSpeed) > streamThreshold){
            streamRenderer.sprite = stream;
        }
        else if((fluidSpeed+bubbleSpeed) > 0){
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
        // Debug.Log((curFluid+curBubble)/maxVolume);
        // DecayBubbles();
    }

    private void AdjustScale(){
        float fluidScale = curFluid/maxVolume*maxFluidHeight;
        fluid.localScale = new Vector3(1, fluidScale, 1);
        float bubbleScale = curBubble/maxVolume*maxFluidHeight;
        if(fluidScale!=0) bubbleScale/=fluidScale;
        bubble.localScale = new Vector3(1, bubbleScale, 1);
    }

    private List<float> GetPouringSpeed(float tiltAngle)
    {
        List<float> returnVal = new List<float> { 0f, 0f };
        if(spilled) return returnVal;
        tiltAngle-=90f;
        tiltAngle = math.max(tiltAngle, 0f);
        returnVal[0] = tiltAngle * chosenBottle.speedFactor * chosenBottle.beerPercentage[0];
        returnVal[1] = tiltAngle * chosenBottle.speedFactor * chosenBottle.foamPercentage[0];
        for (int i = chosenBottle.thresholdAngle.Count-1; i >= 0 ; i--) {
            if (tiltAngle > chosenBottle.thresholdAngle[i]) {
                returnVal[0] = (tiltAngle) * chosenBottle.speedFactor * chosenBottle.beerPercentage[i+1];
                returnVal[1] = (tiltAngle) * chosenBottle.speedFactor * chosenBottle.foamPercentage[i+1];
                break;
            }
        }
        return returnVal;
    }

    // private void DecayBubbles()
    // {
    //     if (curBubble > 0)
    //     {
    //         curBubble -= curBubble * bubbleDecayRate * Time.deltaTime;
    //         curBubble = math.max(curBubble, 0);
    //         AdjustScale();
    //     }
    // }

    public bool IsFull(){
        return curBubble+curFluid > maxVolume;
    }

    public float GetPercentage(){
        if((curBubble+curFluid)/maxVolume < 0.8f) return -1f;
        return curBubble/(curBubble+curFluid);
    }
    public float GetSkillPercentage(){
        return curBubble/(curBubble+curFluid);
    }
    public bool GetPouringStatus(){
        return fluidSpeed+bubbleSpeed > streamThreshold;
    }

    public void DeactivateSpill(){
        spilled = false;
        spill.SetActive(false);
    }
    public void ActivateSpill(){
        spilled = true;
        spill.SetActive(true);
    }

    public void Restart(){
        DeactivateSpill();
        curBubble = 0f;
        curFluid = 0f;
        SetSprites();
        AdjustScale();
    }

    private void SetSprites(){
        chosenBottle = canTransform.gameObject.GetComponent<BeerHandler>().chosenBottle;
        streamRenderer.transform.localPosition = chosenBottle.offset;
        pourPoint.localPosition = chosenBottle.offset;
        drip = chosenBottle.dripSprite;
        stream = chosenBottle.streamSprite;

        cupEdgeL.transform.localPosition = chosenCup.offsetL;
        cupEdgeR.transform.localPosition = chosenCup.offsetR;
        maxFluidHeight = chosenCup.maxHeight;
        bubble.localPosition = new Vector3(0, chosenCup.bubbleHeight, 0);
        fluid.localPosition = new Vector3(0, chosenCup.fluidHeight, 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = chosenCup.cupSprite;
        bubble.gameObject.GetComponent<SpriteRenderer>().sprite = chosenCup.foamSprite;
        fluid.gameObject.GetComponent<SpriteRenderer>().sprite = chosenCup.fluidSprite[chosenBottle.fluidID];
        maxVolume = chosenCup.maxVolume;
        dotLineRenderer.sprite = chosenCup.fillSprite;
        dotLineRenderer.gameObject.transform.localPosition = new Vector3 (0, chosenCup.fillLine, 0);
        spill.GetComponent<SpriteRenderer>().sprite = chosenCup.spillSprite;
        spill.transform.localPosition = new Vector3(0, chosenCup.spillHeight, 0);
    }

    private void ChangeCupPosition(float moveSpeed, float durationTime)
    {
        StartCoroutine(ChangeCupPositionCoroutine(moveSpeed, durationTime));
    }

    private IEnumerator ChangeCupPositionCoroutine(float moveSpeed, float durationTime)
    {
        float elapsedTime = 0f;
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + Vector3.right * moveSpeed;
        bool movingRight = true;

        while (elapsedTime < durationTime)
        {
            if (movingRight)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            if (elapsedTime % 2f < Time.deltaTime)
            {
                movingRight = !movingRight;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }

    public void MoveCupSkill(float MoveSpeed){
        // Move the cup to the right for 1 second using ChangeCupPosition
        ChangeCupPosition(MoveSpeed, 4f);
        // Debug.Log("Cup moved");
    }

    public class CupData
    {
        public float curBubble;
        public float curFluid;
        public float fluidSpeed;
        public float bubbleSpeed;
        public Bottles chosenBottle;
    }

    public CupData GetData()
    {
        return new CupData
        {
            curBubble = this.curBubble,
            curFluid = this.curFluid,
            fluidSpeed = this.fluidSpeed,
            bubbleSpeed = this.bubbleSpeed,
            chosenBottle = this.chosenBottle
        };
    }

    public void SetData(CupData data)
    {
        this.curBubble = data.curBubble;
        this.curFluid = data.curFluid;
        this.fluidSpeed = data.fluidSpeed;
        this.bubbleSpeed = data.bubbleSpeed;
        this.chosenBottle = data.chosenBottle;
        AdjustScale();
    }
    
}
