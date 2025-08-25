using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/FastMobileBloom")]
public class FastMobileBloom : MonoBehaviour
{
	[Range(0.0f, 1.5f)] public float threshold = 0.25f;

	[Range(0.00f, 10.0f)] public float intensity = 1.0f;
	[Range(0.25f, 20f)] public float blurSize = 1.0f;
	[Range(1, 4)] public int blurIterations = 2;

	public Material material = null;

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		int rtW = source.width / 4;
		int rtH = source.height / 4;
		
		//initial downsample
		RenderTexture rt = RenderTexture.GetTemporary(rtW, rtH, 0, source.format);
		rt.DiscardContents();

		material.SetFloat("_Spread", blurSize);
		material.SetVector("_ThresholdParams", new Vector2(1.0f, -threshold));
		Graphics.Blit(source, rt, material, 0);


		//downscale
		for(int i = 0; i < blurIterations - 1; i++)
		{
			RenderTexture rt2 = RenderTexture.GetTemporary(rt.width / 2, rt.height / 2, 0, source.format);
			rt2.DiscardContents();

			material.SetFloat("_Spread", blurSize);
			Graphics.Blit(rt, rt2, material, 1);
			RenderTexture.ReleaseTemporary(rt);
			rt = rt2;
		}
		//upscale
		for(int i = 0; i < blurIterations - 1; i++)
		{
			RenderTexture rt2 = RenderTexture.GetTemporary(rt.width * 2, rt.height * 2, 0, source.format);
			rt2.DiscardContents();

			material.SetFloat("_Spread", blurSize);
			Graphics.Blit(rt, rt2, material, 2);
			RenderTexture.ReleaseTemporary(rt);
			rt = rt2;
		}

		material.SetFloat("_BloomIntensity", intensity);
		material.SetTexture("_BloomTex", rt);
		Graphics.Blit(source, destination, material, 3);

		RenderTexture.ReleaseTemporary(rt);
	}
}
