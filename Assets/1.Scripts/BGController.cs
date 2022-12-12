using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGController : MonoBehaviour
{
    [System.Serializable]
    public struct BGUIData
    {
        public GameObject bottom;
        public GameObject middle;
        public GameObject top;
    }

    [SerializeField]
    private List<BGUIData> bgUIDatas = new List<BGUIData>();
   

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bgUIDatas.Count; i++)
        {
            bgUIDatas[i].bottom.transform.position -= new Vector3(0f,Time.deltaTime * 0.3f,0f);
            bgUIDatas[i].middle.transform.position -= new Vector3(0f, Time.deltaTime * 0.7f, 0f);
            bgUIDatas[i].top.transform.position -= new Vector3(0f, Time.deltaTime * 1.2f, 0f);

            if(bgUIDatas[i].bottom.transform.position.y < -12f)
            {
                bgUIDatas[i].bottom.transform.position += new Vector3(0f, 12f, 0f);
                
            }
            if(bgUIDatas[i].middle.transform.position.y < -12f)
            {
                bgUIDatas[i].middle.transform.position += new Vector3(0f, 12f, 0f);
                
            }
            if(bgUIDatas[i].top.transform.position.y < -12f)
            {
                bgUIDatas[i].top.transform.position += new Vector3(0f, 12f, 0f);
            }
        }
    }
}
