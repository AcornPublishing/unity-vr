using UnityEngine;
using System.Collections;

public class PopulateArtFrames : MonoBehaviour {
	public Texture[] images;

	void Start () {
		int imageIndex = 0;
		foreach (Transform artwork in transform) {
			GameObject art = artwork.FindChild("Image").gameObject;
			Renderer rend = art.GetComponent<Renderer>();
			Shader shader = Shader.Find("Standard");
			Material mat = new Material( shader );
			mat.mainTexture = images[imageIndex];
			rend.material = mat; // will clone the material 
			imageIndex++;
			if (imageIndex == images.Length) imageIndex = 0;
		}
	}
}
