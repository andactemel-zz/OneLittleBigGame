# ITEMS (Unique Id="item")
## GENERAL INFO
- Every item in the game has general specs.
- Every item can be used as weapon if character can lift the item and hold the item.
- Every item can be used as armor if character can carry the item and also if item meet the character wear limits.
- Every item can be eaten as food but eating time calculated from item's volume and hardness and character's biting volume, And Biting Effect Call the Character Function with Parameter.
- Every item represantaion in the game short edges always oriented vertically.

## ALL ITEMS
### ADDED ITEMS
### IN DEVELOPMENT ITEMS
### PLANNED ITEMS

## ITEM HIERARCHY

1. ITEMS
	- SPECS:
		- Weight: gr (double) Unique Id="weight"
		- Height: cm (double) Unique Id="height"
		- Width: cm  (double) Unique Id="width"
		- Depth: cm  (double) Unique Id="depth"
		- Volume cm3 (double) Unique Id="volume"
		- Hardness min-max (1-100000)(int)
		- Eating Effect (When eated Call a character Function with parameter)
 		- ATTACK POWER 0-DoubleMax (Double)
		

## FUNCTIONS

**Eating Function**

- double CalculateEatingTime= (volume/character.bitingVolume)*(hardness*hardness)
	
