using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRestrictionArea : MonoBehaviour
{
    public static SpawnRestrictionArea instance;
    private List<Collider> restrictionArea;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            var col = transform.GetComponentsInChildren<Collider>();
            restrictionArea = new List<Collider>(col);
        }
    }
    
    /// <summary>
    /// �֎~�G���A����
    /// �֎~�G���A�ł͓G���X�|�[�������Ȃ�
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public bool IsRestrictionArea(Vector3 position)
    {
        foreach(Collider area in restrictionArea)
        {
            if(area.bounds.Contains(position))
            {
                return false;
            }
        }
        return true;
    }
}
