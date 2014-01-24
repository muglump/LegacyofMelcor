
// Use this for initialization
function Start () {
}

// Update is called once per frame
function Update () {
}

function OnTriggerEnter(object : Collider){
	var h = gameObject.AddComponent("Halo");
}

function OnTriggerExit(object : Collider){
	//gameObject.AddComponent("Halo");
	var h = gameObject.GetComponent("Halo").destroy;
}
