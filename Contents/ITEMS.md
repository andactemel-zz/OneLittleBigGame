# ITEMS
## GENERAL INFO
- Every item in the game has general specs.
- Every item can be used as weapon if character can lift the item and hold the item.
- Every item can be used as armor if character can carry the item and also if item meet the character wear limits.
- Every item can be eaten as food but eating time calculated from item's volume and hardness and character's biting volume, And Biting Effect Call the Character Function with Parameter.


## ALL ITEMS
### ADDED ITEMS
### IN DEVELOPMENT ITEMS
### PLANNED ITEMS

## ITEM HIERARCHY

1. ITEMS
	- SPECS:
		- Weight: gr 		(double)
		- Height: cm 		(double)
		- Width: cm	 		(double)
		- Depth: cm	 		(double)	
		- Volume cm3 		(double)
		- Hardness min-max (1-100000)(int)
		- Eating Effect (When eated Call a character Function with parameter)
 		- ATTACK POWER 0-DoubleMax (Double)
		

##FORMULAS

- **Eating Formula**

Eating Time=Volume/Biting Volume*hardness*hardness
	
