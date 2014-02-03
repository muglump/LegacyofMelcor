using UnityEngine;
using System.Collections;

public delegate void TurnEnded(TurnInfo tI);

public class TurnBasedCombat : MonoBehaviour {
	
	public event TurnEnded enemyTurnEnded;
	public event TurnEnded playerTurnEnded;
	public event TurnEnded allyTurnEnded;
	public Stack turnOrder;
	public GameObject player;
	public ArrayList<GameObject> allies;
	public ArrayList<GameObject> enemies;
	public GameObject currentActor;

	// Use this for initialization
	void Start () {
		player = Game.Player();
		FindObjectsOfType(PartyMembers) as allies;
		FindObjectsOfType(Enemies) as enemies;
		DetermineInitativeState();
		StartCombat(Update());
		
	}
	
	// Update is called once per frame
	IEnumerator Update () {
		for(;;){
			currentActor = turnOrder.Pop();
			switch(currentActor.Type){
				case "Player": yield return CombatRoutine(PlayerTurn());
				case "Ally": yield return CombatRoutine(AllyTurn());
				case "Enemy": yield return CombatRoutine(EnemyTurn());
				default: return;
			}
		}
	}
	
	IEnumerator PlayerTurn(){
		GameObject target = null;
		bool objectSelected = false;
		TurnInfo turn = new TurnInfo();
		yield return CombatRoutine(SelectObject(target));
		if(target != null){
			yield return CombatRoutine(Attack(target);
		}
		Debug.Log("Player Attacking");
		playerTurnEnded(turn);
	}

	IEnumerator AllyTurn(){
		GameObject target = null;
		bool objectSelected = false;
		TurnInfo turn = new TurnInfo();
		yield return CombatRoutine(SelectObject(target));
		if(target != null){
			yield return CombatRoutine(Attack(target);
		}
		Debug.Log("Ally Attacking");
		allyTurnEnded(turn);
	}
	
	IEnumerator EnemyTurn(){
		GameObject target = null;
		bool objectSelected = false;
		TurnInfo turn = new TurnInfo();
		yield return CombatRoutine(SelectObject(target));
		if(target != null){
			yield return CombatRoutine(Attack(target);
		}
		Debug.Log("Enemy Attacking");
		allyTurnEnded(turn);
	
	}

	IEnumerator SelectObject (GameObject target){
		bool targetSelected = false;
		
		while(!targetSelected){
			target = Targeting();
			if(target != null){
				targetSelected = true;
				Debug.Log("Target");
			}

		yield return null;
		}
	}

	GameObject Targeting(){
		return currentActor.DetermineTarget();
	}

	void DetermineInitativeState(){
		ArrayList<GameObject> tempInitative = new ArrayList<GameObject>();
		player.rollInitative();
		tempInitative.add(player);
		foreach (GameObject ally in allies){
			ally.rollInitative();
			tempInitative.add(ally);
		}
		foreach (GameObject enemy in enemies){
			enemy.rollInitative();
			tempInitative.add(enemy);
		}
		while(!tempInitative.IsEmpty())
		GameObject tempLowestInitative = tempInitative[0];
		foreach(GameObject combatant in tempInitative){
			if(combatant.Initative < tempLowestInitative.Initative){
				tempLowestInitative = combatant;
			}
		}
		turnOrder.Push(tempLowestInitative);
		tempInitative.Remove(tempLowestInitative);
		
	}
}
