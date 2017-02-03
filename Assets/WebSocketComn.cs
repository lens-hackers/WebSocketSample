using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Net;

public class WebSocketComn : MonoBehaviour {

    public string IpAddress;
    public PartsSelection PartsSelection = new PartsSelection();
    WebSocket ws;

	void Start () {
        ws = new WebSocket(string.Format("ws://{0}/", IpAddress));
        ws.OnOpen += (sender, e) => {
            print("websocket open");
        };
        ws.OnError += (sender, e) => {
            print("WebSocket Error Message: " + e.Message);
        };
        ws.OnClose += (sender, e) => {
            print("WebSocket Close");
        };
        ws.OnMessage += Ws_OnMessage;
        ws.Connect();
    }

    private void Ws_OnMessage(object sender, MessageEventArgs e) {
        print(e.Data);
        JsonUtility.FromJsonOverwrite(e.Data, PartsSelection);
    }

    void Update () {
		
	}

    void OnDestroy() {
        ws.Close();
        ws = null;    
    }
}
