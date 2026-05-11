// A redo from memory of the dice roller program from Programming Principles in Uni.

using System;
using System.IO;
using DiceRollerLib;
class DiceRoller{
  
  static void Main(){
    Console.WriteLine(new string('-',10) + "Welcome to DiceRoller.net" + new string('-',10) + "\n\n");
    
    while(true){
      Console.WriteLine("Please insert a dice number and dice dimensions.");
      Console.WriteLine(" input \'h\' for help.");
      Console.WriteLine(" input \'x\' to exit.");
      string? rawInput = Console.ReadLine();

      string input = rawInput == null ? "" : rawInput;

      input = input.Trim().Replace(" ", "");  // remove all whitespace

      if(input == "x"){
        Console.WriteLine(new string('!', 10)+"Exiting program"+new string('!',10));
        Console.WriteLine(new string('-',10) + "Thanks for using DiceRoller.net" + new string('-',10) + "\n\n");
        break;
      }
      else if(input == "h"){
        Console.WriteLine(@"
        Input a number of dice and dice side/dimensions in this format.
        2 dice with 6 sides are represented with the input '2d6'.
        5 20 sided dice are represented with the input '5d20'.
        The total will be talied up at the end.
        ");
        
      }
      else if(DiceRollerLib.DiceRoller.ValidityCheck(input))
      {
        DiceRollerLib.DiceRoller dr = new DiceRollerLib.DiceRoller(input);

        while(true){
          bool res = dr.Run();

          if(res == false){
            break;
          }
        }
      }
      else{
        Console.WriteLine("i don't knwo what you input, but I don't like it");
      }
    }
  }
}