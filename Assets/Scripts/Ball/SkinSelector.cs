using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] skinPrefabs;
    void Start()
    {
        SaveData save = new SaveGame().LoadGame();
        int skinId = 0;
        for(int i = 0; i<save.skinsProps.Length; i++)
        {
            if (save.skinsProps[i].selected)
            {
                skinId = save.skinsProps[i].id;
            }
        }
        AllowSkin(skinId);
    }

    private void AllowSkin(int skinId)
    {
        GameObject skin = Instantiate(skinPrefabs[skinId]);
        gameObject.GetComponent<MeshFilter>().mesh = skin.GetComponent<MeshFilter>().mesh;
        gameObject.GetComponent<MeshRenderer>().materials = skin.GetComponent<MeshRenderer>().materials;
        float colliderRadius = GetComponent<CapsuleCollider>().radius;
        colliderRadius *= gameObject.transform.localScale.x;
        Debug.Log(skin.transform.localScale);
        transform.localScale = skin.transform.localScale;
        colliderRadius /= transform.localScale.x;
        GetComponent<CapsuleCollider>().radius = colliderRadius;
        GetComponent<CapsuleCollider>().height = colliderRadius * 2f;

        while (skin.transform.childCount > 0)
        {
            Transform child = skin.transform.GetChild(0);
            Vector3 childPos = child.transform.localPosition;
            child.SetParent(gameObject.transform, true);
            child.transform.localPosition = childPos;
        }
        Destroy(skin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
