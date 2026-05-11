using System.Net;
using System.Collections;

namespace DiceRollerLib;

public class DiceRoller
{
  private int? _diceNumber;
  private int? _diceDims;
  private bool _explodingDice = false;
  private Random diceRand = new Random();

  public static bool ValidityCheck(string strIn){
    
    // remove the "exploding" x at the end if its there.
    if(strIn.Last() == 'x'){
      strIn = strIn.Substring(0,strIn.Length - 1);
    }

    if(strIn.Contains("d")){
      string[] chStr = strIn.Split('d');

      if(chStr.Length == 2){
        return chStr.All(str => str.All(char.IsDigit));
      }
    
      return false;      
    }
    return false;
  }
  public DiceRoller(string strIn){

    // Input should have been checked by now
    if(strIn.Last() == 'x'){
      _explodingDice = true;
      strIn = strIn.Substring(0, strIn.Length - 1);
    }

    string[] numbers = strIn.Split('d');

    try{
      _diceNumber = int.Parse(numbers[0]);
      _diceDims = int.Parse(numbers[1]);
    }
    catch{
      throw new FormatException("Invalid numbers input");
    }
  }

  private int _RollDice(int? diceNumber){

    if(_diceDims != null){
      Console.Write("Rolling");
      if(_explodingDice) Console.Write(" explosive");
      Console.Write($" d{_diceDims}");
      Console.Write(diceNumber!= null ? $" {diceNumber + 1}..." : "...");
      int diceVal = diceRand.Next(1,1 + _diceDims ?? 0);

      Console.Write($"Rolled a {diceVal}!\n");

      return diceVal;
    }
    else{
      throw new FormatException("Invalid Dice Dimensions");
    }
    
  }

  // bool returns whether or not you want to roll again.
  public bool Run(){

    Console.WriteLine(new string('*',10)+"  Rolling dice  "+new string('*',10));

    List<int> totalList = new List<int>();

    // for exploding dice logic, if nothing happens just runs once
    for(int explosions = 0; explosions < 1; explosions++){
      for(int i= 0; i < _diceNumber; i++){
        totalList.Add(this._RollDice(i));
      }

      if(totalList.All(val => totalList.First() == val)){
        Console.WriteLine(new string('!',10)+"BOOOM"+new string('!',10));
        explosions--;
      }
    }

    Console.WriteLine($"Dice Total = {totalList.Sum()}");

    Console.WriteLine("\n"); // Formatting space

    while(true){
      Console.WriteLine("Would you like to roll again?(y/N)");
      string? rollagain = Console.ReadLine();

      if(rollagain != null && rollagain.Trim() == "y"){
        return true;
      }
      else if(rollagain != null && rollagain.Trim() == "N"){
        return false;
      }
      else{
        Console.WriteLine("Invalid input, try again!");
      }
    }
  }
}
