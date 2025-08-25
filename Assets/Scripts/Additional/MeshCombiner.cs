
//using UnityEditor;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//// Copy meshes from children into the parent's Mesh.
//// CombineInstance stores the list of meshes.  These are combined
//// and assigned to the attached Mesh.
//
//[RequireComponent(typeof(MeshFilter))]
//[RequireComponent(typeof(MeshRenderer))]
//public class MeshCombiner : MonoBehaviour
//{
//    [SerializeField] private string meshName = "SomeMesh";
//    [SerializeField] private bool optimize = true;
//    [SerializeField] private bool makeNewInstance = true;
//    [SerializeField] private bool mergeSubMeshes = false;
//    void Start()
//    {
//        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
//        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
//
//        int i = 0;
//        while (i < meshFilters.Length)
//        {
//            combine[i].mesh = meshFilters[i].sharedMesh;
//            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
//            meshFilters[i].gameObject.SetActive(false);
//
//            i++;
//        }
//        transform.GetComponent<MeshFilter>().mesh = new Mesh();
//        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine,mergeSubMeshes,true,false);
//        transform.gameObject.SetActive(true);
//        SaveMesh(transform.GetComponent<MeshFilter>().mesh,meshName,makeNewInstance,optimize);
//    }
//
//    void SaveMesh(Mesh mesh, string name, bool makeNewInstance, bool optimizeMesh){
//        string path = EditorUtility.SaveFilePanel("Save Separate Mesh Asset", "Assets/", name, "asset");
//		if (string.IsNullOrEmpty(path)) return;
//        
//		path = FileUtil.GetProjectRelativePath(path);
//
//		Mesh meshToSave = (makeNewInstance) ? Object.Instantiate(mesh) as Mesh : mesh;
//		
//		if (optimizeMesh)
//		     MeshUtility.Optimize(meshToSave);
//        
//		AssetDatabase.CreateAsset(meshToSave, path);
//		AssetDatabase.SaveAssets();
//    }
//}