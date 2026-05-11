using System.Net;
using System.Collections;

namespace DiceRollerLib;

public class DiceRoll
{
  int diceNumber;
  int diceDims;

  public static bool ValidityCheck(string strIn){
    if(strIn.Contains("d")){
      string[] chStr = strIn.Split('d');

      if(chStr.Length == 2){
        return chStr.All(str => str.All(char.IsDigit));
      }
    
      return false;      
    }
    return false;
  }
  public DiceRoll(string strIn){

    // Input should have been checked by now
    string[] numbers = strIn.Split('d');

    try{
      diceNumber = int.Parse(numbers[0]);
      diceDims = int.Parse(numbers[1]);
    }
    catch{
      Console.WriteLine();
    }
    

  }
}
