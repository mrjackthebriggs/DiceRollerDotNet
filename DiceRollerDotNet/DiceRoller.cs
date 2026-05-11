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
        // print help
      }
      else if(DiceRoll.ValidityCheck(input)){
        DiceRoll dr = new DiceRoll(input);

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