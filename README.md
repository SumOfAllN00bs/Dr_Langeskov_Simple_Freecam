# Dr_Langeskov_Simple_Freecam

Dr. Langeskov, The Tiger, and The Terribly Cursed Emerald: A Whirlwind Heist Modified Files

## Instructions

1. Install dnSpy from https://github.com/0xd4d/dnSpy/releases
2. Open dnSpy and then click on File -> Open
3. Navigate to your copy of Dr. Langeskov <Steam Install>\steamapps\common\Dr. Langeskov...
4. Then navigate to DrLangeskov_Data\Managed
5. Click on Assembly-CSharp.dll
6. In the assembly explorer, open up the tree like so:
 - Assembly-CSharp (0.0.0.0)
   - Assembly-CSharp.dll
     - - (this is near References and is just a dash)
       - CoolGame
7. Click on CoolGame and then in the code view to the right, right click and click on Edit Class (C#)...
8. Ctrl+a, delete all the code
9. Copy in the code from https://github.com/SumOfAllN00bs/Dr_Langeskov_Simple_Freecam/blob/main/CoolGame.cs
10. Click on Compile (if there are errors I can't help here)
11. Click on File -> Save Module... and then OK

## Usage

If everything worked then when you start Dr. Langeskov will have the following bindings:

F5 = Toggle freecam
F6 = Enable the disabled rooms
  
IJKL to fly
U to go up (except when you're looking down because I'm bad at programming)
U to go down (except the same)
shift to add speed to flying
