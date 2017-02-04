using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate : MonoBehaviour {

    WebSocketComn webSocketComn;
    List<string> parts = new List<string>();
    List<GameObject> displayingParts = new List<GameObject>();

	void Start () {
        webSocketComn = GetComponent<WebSocketComn>();
        GameObject prefab = (GameObject)Resources.Load("Prefabs/hige");
    }
		
	void Update () {
        if (isChanged(webSocketComn.Parts)) {
            parts = webSocketComn.Parts;

            foreach (var obj in displayingParts) {
                Destroy(obj);
            }
            displayingParts.Clear();

            foreach (var p in parts) {
                GameObject prefab = (GameObject)Resources.Load("Prefabs/" + p);
                if (prefab != null) {
                    var obj = Instantiate(prefab);
                    displayingParts.Add(obj);
                }
            }
        }
	}

    bool isChanged(List<string> currentParts) {
        if (currentParts.Count != parts.Count) {
            return true;
        }
        for (int i = 0; i < currentParts.Count; ++i) {
            if (currentParts[i] != parts[i]) {
                return true;
            }
        }
        return false;
    }
}
