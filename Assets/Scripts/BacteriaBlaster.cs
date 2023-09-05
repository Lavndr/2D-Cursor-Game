using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacteriaBlaster : MonoBehaviour
{   
    
    private int germPoints;
    public Text germText;

    public Text pointIncrease;
    public Camera cam;
    public GameObject canvasObj;
    private ParticleSystem part;

    public GameObject germBurstPart;
    public GameObject particleHolder;   

    private int lengthOfList;
    private List<ParticleCollisionEvent> collisionList;
    
    public SpriteRenderer spriteInfo;
    // Start is called before the first frame update
    void Start()
    {   
        pointIncrease.text = "1";
        germPoints = 0;
        germText.text = "Points: " + germPoints.ToString();
        part = GetComponent<ParticleSystem>();
        collisionList = new List<ParticleCollisionEvent>();

    }


    void OnParticleCollision(GameObject other)
    {
        lengthOfList = part.GetCollisionEvents(other, collisionList);

        for(int i = 0; i < lengthOfList; i++)
        {
            Vector3 position3D = collisionList[i].intersection;

            Vector3 positionReal = transform.TransformPoint(position3D.x, position3D.y, position3D.z);

            Vector3 positionWorld = cam.WorldToScreenPoint(positionReal);
            if(positionWorld != null)
            {   
                if(spriteInfo.sprite.name == "chopsticks")
                {
                    var germ = Instantiate(pointIncrease.gameObject, positionWorld, Quaternion.identity, canvasObj.transform); 
                    Destroy(germ, 0.3f);
                    germPoints++; 
                    germText.text = "Points: " + germPoints.ToString();
                }
                else{
                    var germBurstNow = Instantiate(germBurstPart, positionReal, Quaternion.identity, particleHolder.transform);
                    Destroy(germBurstNow, 0.5f);
                    var germ = Instantiate(pointIncrease.gameObject, positionWorld, Quaternion.identity, canvasObj.transform); 
                    Destroy(germ, 0.3f);
                    germPoints++; 
                    germText.text = "Points: " + germPoints.ToString();
                }
            
            }
            else 
            {
                break;
            }
            ;
            
            
        }
    }
    
}
