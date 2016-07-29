Dropsy is a C# version of the game Drop 7. This was a C# practice exercise that I collaborated on with other engineers during my internship at Enlearn. We were given a series of "stories" that increased in complexity, and we only knew one story at a time, and we often had to rethink our strategies and refactor code to complete each subsequent story.
Stories so far:

Completed Stories:
 1. Build and display an empty 1x1 to 9x9 box
 2. Add Column Labels
 3. Create a chip with a random value less than or equal to 9 and draw the chip at top center of the board
 4. Allow the user to pick which column the chip drops into using a keypress
 5. Allow the user to drop multiple chips, the dropped chips stack on top of each other, attempting to drop a chip into a full column does nothing, and the game ends when all columns are full
 6. Every fifth turn, add a row of blocks to the screen (character 219 █ ), and push the current chips on the screen up one level
 
 Current Story:
 7. If adding blocks to a column causes it to overflow, the game is over.
