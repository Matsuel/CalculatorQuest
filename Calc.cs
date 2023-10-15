using System;
using System.Linq;

namespace CalculatorQuest;

public class Calc
{
    private readonly string[] _sings = new[] { "+", "-", "*", "/", "%" };

    public Calc() {}

    public string Operator(string ope)
    {
        if (ope == "" || ope[0]=='*' || ope[0]=='+' || ope[0]=='/' || ope[0]=='%')
        {
            return "Please enter an operation";
        }
        int nbOperator=0;
        string sign="";
        string oper = "";
        string[] numbers = ope.Split(_sings, StringSplitOptions.RemoveEmptyEntries); //split l'operatin en fonction des différents signes
        
        if (ope[0]=='-'){//si ope est négatif on supprime le - du cébut pour effectuer les calculs plus simplement
            sign="-";
            ope=ope.Substring(1);
        }  

        for (int i=0; i<_sings.Length;i++){
            for (int j=0; j<ope.Length;j++){
                //conditon si c'est une addition ou une soustraction par exemple si c'est -6-6 ou 6--6
                if(ope[j]=='-'&& sign=="-" && (ope[j-1]!= '*' || ope[j-1]=='/')){
                    nbOperator++;
                    ope= ope.Replace("-","+");
                    oper="+";
                    j+=2;
                }else if (ope[j] == _sings[i][0] && ope[j + 1] == '-')
                {
                    oper = _sings[i];
                    nbOperator=1;
                    sign += "-";
                    ope = ope.Substring(0, j + 1)+ope.Substring(j+2);
                    j+=2;
                }else if (ope[j]==_sings[i][0]){
                    nbOperator++;
                    oper=_sings[i];
                }
            }
        }
        
        if (nbOperator!=1 || numbers.Length!=2){// s'il y a plus d'un opéraeur ou bien plus de 2 nombres on renvoie une erreur
            return "Only one operation please";
        }
        else
        {
            float rep=0;
            float number1 = float.Parse(numbers[0]);
            float number2 = float.Parse(numbers[1]);
            //Si l'opération est + mais que le signe est - on effectue une addition des 2 nombres après avoir sorti les -
            if (sign == "-" && oper == "+"){ rep = number2 + number1; }
            // Si l'opération est une addition
            else if (oper=="+"){rep= number1+number2;}
            // Si l'opération est une soustraction
            else if (oper=="-"){rep= number1-number2;}
            // Si l'opération est une multiplication
            else if (oper=="*"){rep= number1*number2;}
            // Si l'opération est une division
            else if (oper=="/"){
                //Si le deuxième nombre est 0 on renvoie une erreur
                if (number2==0){return "Division by 0 is IMPOSSIBLE";}
                //Sinon on renvoie la division des 2 bombres
                rep= float.Parse(numbers[0])/float.Parse(numbers[1]);
            }else if(oper =="%"){
                //Si le deuxième nombre est 0 on renvoie une erreur
                if (number2==0){return "Modulo by 0 is IMPOSSIBLE";}
                //Sinon on renvoie le résultat de la divison euclidienne des 2 nombres
                rep= number1%number2;
            }
            
            // si il y a 2 signes - ou bien 0 le nombre est positif 
            if (sign.Length % 2 == 0) { return rep.ToString(); } 
            // sinon le nombre est négatif on renvoie '-' + la reponse
            return sign+rep.ToString();
        }
    }

    public string Sqrt(string ope)
    {
        if (ope == "" || ope=="Please enter an operation" || ope=="Only one operation please"){ return "Please enter an operation"; }
        if (float.Parse(ope) >= 0) { return Math.Sqrt(float.Parse(ope)).ToString(); }
        return "No sqrt for negative number";
    }

    public string Square(string ope)
    {
        if (ope == "" || ope=="Please enter an operation" || ope=="Only one operation please") { return "Please enter an operation"; }
        return Math.Pow(double.Parse(ope), 2).ToString();
    }

    public string Invert(string ope)
    {
        if (ope == "" || ope=="Please enter an operation" || ope=="Only one operation please") { return "Please enter an operation"; }
        return (1 / double.Parse(ope)).ToString();
    }
    
}