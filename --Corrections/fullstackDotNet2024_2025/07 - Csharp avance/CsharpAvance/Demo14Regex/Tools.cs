using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo14Regex;

internal static class Tools
{

    /*
     *  Pattern REGEX
     *  ^ = Commence
     *  $ = Termine
     *  \d = nombre
     *  \w = Lettre , Nombre, _undercore
     *  \s = White-space(tabs, espacement, retour à la ligne, ...etc)
     *  \D = Tout sauf les \d
     *  \W = Tout sauf les \w
     *  \S = Tout sauf les \s
     *  [a-z] = Range de valeur => Autoriser les lettres minuscule
     *  [a-zA-Z] = Range de valeur => Autoriser les lettres minuscule et majuscule
     *  | = OU
     *  * = 0 ou +
     *  + = 1 ou +
     *  ? = 0 ou 1
     *  {1} = répétition ( repete 1 fois les instructions )
     *  {2,4} = répétition ( repete entre 2 et 4 fois les instructions )
     */

    public static bool IsName(string name)
    {
        //string pattern = @"^[A-Z][a-zA-Z éèëàê\-]*$";
        return Regex.IsMatch(name, @"^[A-Z][a-zA-Z éèëàê\-]*$");
    }

    // Créer Une méthode pour vérifier une adresse email:
    public static bool IsEmail(string email)
    {
        //string pattern = @"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$";
        return Regex.IsMatch(email, @"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$");
    }


    // Créer une méthode pour vérifier le téléphone
    public static bool IsPhone(string phone)
    {
        // +33659786532 => Le Bon Format
        // 33 6 59 78 65 32
        // 03 20 45 69 87
        // 06-23-45-69-87
        // 06.23.45.69.87
        // 0723456987
        // 0623-45.69 87
        string pattern = @"^([0|\+33|33]?)(\.|\-|\s)?([1-9]{1})((\.|\-|\s)?[0-9]{2}){4}$";
        return Regex.IsMatch(phone, @"^([0|\+33|33]?)(\.|\-|\s)?([1-9]{1})((\.|\-|\s)?[0-9]{2}){4}$");
    }
    public static bool IsNumeric(string chaine)
    {
        string pattern = @"^([0-9]+)(\,)?([0-9]*)$";
        return Regex.IsMatch(chaine, pattern);
    }

    public static bool IsAlphabetic(string chaine)
    {
        string pattern = @"^[A-Z]{1}[a-zA-Z éèë\-_\s]*$";
        return Regex.IsMatch(chaine, pattern);
    }

    public static string ClearMultipleSpace(string chaine, string remplacement)
    {
        string pattern = @"\s+";
        string cleanedString = Regex.Replace(chaine, pattern, remplacement);

        return cleanedString;
    }

    public static string FormatPhone(string phone) // renvoie un téléphone sous la forme +33659786532 => Le Bon Format
    {
        string pattern = @"[\.\-\s]+";
        string FormatedString = Regex.Replace(phone, pattern, "");

        pattern = @"^(0|33)";
        FormatedString = Regex.Replace(FormatedString, pattern, "+33");

        return ClearMultipleSpace(FormatedString, "");
    }

}
