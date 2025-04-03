1. # Chaîne commençant par p
   ^p
La Signification du Glyphe ^p :

^ (Le Gardien du Seuil) : Cette rune est une ancre. Elle ne correspond pas à un caractère, mais à une position : le tout début de la chaîne de caractères (ou de la ligne, selon les options choisies). Elle décrète : "La vérification commence ici, au commencement absolu !".
p (La Rune Littérale) : Ceci représente simplement le caractère littéral 'p' minuscule.
Donc, l'incantation ^p dans son ensemble vérifie si une chaîne de caractères commence exactement par la lettre 'p' minuscule.

<La Transcription en C# :

Voici comment manier ce sortilège dans le langage C# en utilisant la puissante bibliothèque System.Text.RegularExpressions :

```cs
using System;
using System.Text.RegularExpressions; // N'oubliez pas d'invoquer cet espace de noms !

public class StartingGlyphChecker
{
    // Méthode pour vérifier si un texte commence par 'p'
    public static void DoesItStartWithP(string scrollText)
    {
        // Notre incantation Regex : simple, directe.
        string pattern = "^p";

        // Méthode 1: Utilisation directe de Regex.IsMatch (concis pour un usage unique)
        // Lance le sort directement sur le texte.
        bool isMatchStatic = Regex.IsMatch(scrollText, pattern);

        Console.WriteLine($"Vérification (statique) pour '{scrollText}': Commence par 'p' ? {isMatchStatic}");

        // Méthode 2: Création d'un objet Regex (préférable si le pattern est réutilisé)
        // Forger l'outil magique une fois pour toutes.
        Regex startingP_Regex = new Regex(pattern);

        // Utiliser l'outil forgé pour lancer le sort.
        bool isMatchInstance = startingP_Regex.IsMatch(scrollText);

        // Les résultats devraient être identiques, bien sûr !
        // Console.WriteLine($"Vérification (instance) pour '{scrollText}': Commence par 'p'? {isMatchInstance}");
    }

    // Exécutons quelques tests pour observer la magie à l'œuvre
    public static void TestTheGlyph()
    {
        Console.WriteLine("--- Test de l'Incantation '^p' ---");
        DoesItStartWithP("potion");          // Devrait être True
        DoesItStartWithP("parchemin");       // Devrait être True
        DoesItStartWithP("Paladin");         // Devrait être False (sensible à la casse par défaut)
        DoesItStartWithP(" épée");         // Devrait être False (commence par un espace)
        DoesItStartWithP("arpenteur");       // Devrait être False (ne commence pas par 'p')
        DoesItStartWithP("p");               // Devrait être True

        // Pour une vérification insensible à la casse :
        Console.WriteLine("\n--- Test avec l'Option IgnoreCase ---");
        string patternIgnoreCase = "^p";
        bool startsWithPorP = Regex.IsMatch("Paladin", patternIgnoreCase, RegexOptions.IgnoreCase);
        Console.WriteLine($"Vérification (ignore case) pour 'Paladin': Commence par 'p' ou 'P' ? {startsWithPorP}"); // Devrait être True
    }
}
```
// Pour lancer les tests depuis votre méthode Main ou ailleurs :
// StartingGlyphChecker.TestTheGlyph();
Explication du Code C# :

using System.Text.RegularExpressions;: Vous importez l'arsenal nécessaire pour manier les Regex en C#.
string pattern = "^p";: Vous définissez votre sortilège comme une simple chaîne de caractères.
Regex.IsMatch(scrollText, pattern): C'est la méthode statique la plus directe. Vous lui donnez le texte à examiner (scrollText) et le sort (pattern), elle vous renvoie true si le texte correspond, false sinon.
Regex startingP_Regex = new Regex(pattern);: Ici, vous créez un objet Regex. C'est comme forger un artefact magique spécifique à ce pattern. C'est plus efficace si vous comptez utiliser le même sortilège de nombreuses fois (par exemple, dans une boucle).
startingP_Regex.IsMatch(scrollText): Vous utilisez ensuite votre artefact (startingP_Regex) pour lancer le sort IsMatch sur le texte.
RegexOptions.IgnoreCase: Comme montré dans le dernier exemple, vous pouvez ajouter des options pour modifier le comportement du sort. IgnoreCase est très courant pour ignorer la différence entre majuscules et minuscules (p ou P).
Ce code C# est la traduction fidèle de votre simple mais puissant glyphe ^p, prêt à vérifier l'initiale de n'importe quelle chronique textuelle dans vos projets .NET !

#############################################################################################################

2. # Chaîne commençant par p mais suivi d'exactement 4 caractères
   ^p.{4}

<La Signification du Sortilège ^p.{4} :

^ (Le Gardien du Seuil) : Toujours notre ancre, exigeant que la correspondance commence au tout début de la chaîne.
p (La Première Rune Requise) : Le caractère littéral 'p' minuscule doit être le premier caractère.
. (Le Joker Universel) : Cette rune correspond à n'importe quel caractère unique (à l'exception notable du caractère de nouvelle ligne \n, sauf si une option spécifique est activée). C'est un symbole passe-partout.
{4} (Le Compteur Précis) : Ce quantificateur s'applique à la rune précédente (.). Il signifie que le caractère joker doit apparaître exactement quatre fois. Ni plus, ni moins.
Donc, l'incantation ^p.{4} recherche une chaîne qui :

Commence par 'p' minuscule.
Est suivie par exactement quatre autres caractères (peu importe lesquels).
Ce qui implique que la chaîne doit avoir une longueur totale de 5 caractères (le 'p' initial + les 4 caractères suivants).

<La Transcription en C# :

Voici comment vous utiliseriez ce sortilège de longueur fixe en C# :
```cs
using System;
using System.Text.RegularExpressions; // L'arsenal Regex est requis !

public class PreciseLengthChecker
{
    // Méthode pour vérifier si un texte correspond au pattern ^p.{4}
    public static void CheckStartPAndExactLength(string arcaneText)
    {
        // L'incantation : commence par 'p', suivi d'exactement 4 caractères quelconques.
        string pattern = "^p.{4}";

        // Méthode 1: Lancer le sort directement (efficace pour un seul test)
        bool isMatchDirect = Regex.IsMatch(arcaneText, pattern);
        Console.WriteLine($"Vérification directe pour '{arcaneText}': Correspond à '^p.{{4}}' ? {isMatchDirect}");

        // Méthode 2: Forger un outil Regex dédié (mieux pour des vérifications répétées)
        // Notez que .NET peut mettre en cache les Regex utilisées statiquement,
        // mais créer l'objet explicitement reste une bonne pratique pour la clarté et le contrôle.
        Regex preciseLengthRegex = new Regex(pattern);
        bool isMatchInstance = preciseLengthRegex.IsMatch(arcaneText);
        // Console.WriteLine($"Vérification via instance pour '{arcaneText}': Correspond? {isMatchInstance}");
    }

    // Déployons nos tests pour valider l'efficacité du sort
    public static void TestThePreciseSpell()
    {
        Console.WriteLine("--- Test de l'Incantation '^p.{4}' (Longueur Totale 5) ---");
        CheckStartPAndExactLength("pelle");     // True: 'p' + 4 caractères = 5 total
        CheckStartPAndExactLength("potio");     // True: 'p' + 4 caractères = 5 total
        CheckStartPAndExactLength("p1A Z");     // True: 'p' + 4 caractères (chiffre, majuscule, espace, majuscule) = 5 total
        CheckStartPAndExactLength("p!?.*");     // True: 'p' + 4 caractères (symboles) = 5 total

        Console.WriteLine("\n--- Cas où le sort devrait échouer ---");
        CheckStartPAndExactLength("port");      // False: Longueur 4 ('p' + 3)
        CheckStartPAndExactLength("potion");    // False: Longueur 6 ('p' + 5)
        CheckStartPAndExactLength("paladin");   // False: Longueur 7 ('p' + 6)
        CheckStartPAndExactLength("Pierre");    // False: Commence par 'P' (majuscule)
        CheckStartPAndExactLength(" dragon");   // False: Ne commence pas par 'p'
        CheckStartPAndExactLength("p");         // False: Longueur 1 ('p' + 0)
        CheckStartPAndExactLength("p    ");     // True: 'p' + 4 espaces = 5 total (l'espace est un caractère !)

        // Test avec option IgnoreCase si nécessaire
        Console.WriteLine("\n--- Test avec IgnoreCase ---");
        bool startsWithPorPAndLength5 = Regex.IsMatch("Pierre", "^p.{4}", RegexOptions.IgnoreCase);
        Console.WriteLine($"Vérification (ignore case) pour 'Pierre': Correspond à '^p.{{4}}' (ignore case)? {startsWithPorPAndLength5}"); // True
    }
}
```
// Pour exécuter les tests dans votre programme principal :
// PreciseLengthChecker.TestThePreciseSpell();
Points Clés du Code C# :

string pattern = "^p.{4}";: Définit le sortilège exact.
Regex.IsMatch(arcaneText, pattern): La méthode la plus simple pour obtenir un true ou false indiquant si le texte correspond au pattern.
new Regex(pattern): Crée l'objet Regex pour une utilisation potentiellement répétée.
Importance de la longueur: Le code et les tests mettent en évidence que le pattern ne correspond que si la longueur totale est exactement de 5 caractères, commençant par 'p'.
RegexOptions.IgnoreCase: Montre comment rendre le test insensible à la casse pour la lettre 'p' initiale si nécessaire.
Ce fragment de code C# est maintenant prêt à être intégré dans vos scripts pour vérifier si des textes respectent cette structure précise de cinq runes commençant par 'p' !

#############################################################################################################

3. # Pareil mais uniquement avec des caractère alphabétiques
   ^p[a-z]{4}

<La Signification du Sortilège ^p[a-z]{4} :

^ (Le Gardien du Seuil) : Comme toujours, la vérification doit débuter au commencement exact de la chaîne.
p (La Première Rune Imposée) : Le caractère 'p' minuscule est obligatoire en première position.
[a-z] (Le Sceau Alphabétique Mineur) : Cette fois, au lieu du joker universel (.), nous utilisons [a-z]. Ce sceau ne correspond qu'à une seule lettre minuscule de l'alphabet latin (de 'a' à 'z'). Les chiffres, symboles, espaces ou lettres majuscules sont exclus par ce sceau.
{4} (Le Compteur Précis) : Ce quantificateur s'applique toujours à l'élément précédent, qui est maintenant [a-z]. Il exige donc qu'il y ait exactement quatre lettres minuscules après le 'p' initial.
En combinant ces éléments, l'incantation ^p[a-z]{4} recherche une chaîne qui :

Commence par 'p' minuscule.
Est suivie par exactement quatre lettres minuscules.
Implique, comme précédemment, une longueur totale de 5 caractères, mais avec une restriction stricte sur la nature des 4 derniers caractères.

<La Transcription en C# :

Voici le code C# pour manier ce sortilège plus restrictif :
```cs
using System;
using System.Text.RegularExpressions; // N'oubliez jamais d'invoquer la guilde des Regex !

public class SpecificAlphabetChecker
{
    // Méthode pour vérifier si un texte correspond au pattern ^p[a-z]{4}
    public static void CheckStartPAndFourLowercaseLetters(string arcaneWord)
    {
        // L'incantation : commence par 'p', suivi d'exactement 4 lettres minuscules.
        string pattern = "^p[a-z]{4}";

        // Forgeons l'outil magique pour cette vérification spécifique
        // (La mise en cache par .NET peut optimiser les appels statiques répétés,
        // mais l'instanciation reste pédagogique et offre un contrôle fin).
        Regex specificLettersRegex = new Regex(pattern);

        // Appliquons le sort sur le mot fourni
        bool doesMatch = specificLettersRegex.IsMatch(arcaneWord);

        // Proclamons le verdict
        if (doesMatch)
        {
            Console.WriteLine($"'{arcaneWord}': Conforme ! Ce mot sacré commence par 'p' et est suivi de quatre lettres minuscules.");
        }
        else
        {
            Console.WriteLine($"'{arcaneWord}': Non conforme. Ce mot ne respecte pas la structure 'p' suivie d'exactement quatre lettres minuscules.");
        }
    }

    // Procédons aux épreuves rituelles
    public static void TestTheAlphabetSpell()
    {
        Console.WriteLine("--- Test de l'Incantation '^p[a-z]{4}' ---");
        CheckStartPAndFourLowercaseLetters("pelle");   // True: p + 4 lettres minuscules
        CheckStartPAndFourLowercaseLetters("plume");   // True: p + 4 lettres minuscules
        CheckStartPAndFourLowercaseLetters("porte");   // True: p + 4 lettres minuscules
        CheckStartPAndFourLowercaseLetters("patin");   // True: p + 4 lettres minuscules

        Console.WriteLine("\n--- Mots qui devraient échouer au rituel ---");
        CheckStartPAndFourLowercaseLetters("p1a2");    // False: Contient des chiffres
        CheckStartPAndFourLowercaseLetters("pAtte");   // False: Contient une majuscule 'A'
        CheckStartPAndFourLowercaseLetters("p.ote");   // False: Contient un symbole '.'
        CheckStartPAndFourLowercaseLetters("p lus");   // False: Contient un espace
        CheckStartPAndFourLowercaseLetters("port");    // False: Longueur 4 (p + 3 lettres)
        CheckStartPAndFourLowercaseLetters("potion");  // False: Longueur 6 (p + 5 lettres)
        CheckStartPAndFourLowercaseLetters("Pierre");  // False: Commence par 'P'
        CheckStartPAndFourLowercaseLetters(" appel");  // False: Commence par un espace

        // Option IgnoreCase (Attention : affecte UNIQUEMENT le 'p' initial ici, pas le [a-z])
        Console.WriteLine("\n--- Test avec IgnoreCase (pour le 'p'/'P' initial) ---");
        // Le pattern devient "commence par p ou P, suivi de 4 lettres *minuscules*"
        bool startsWithPorPAnd4Lower = Regex.IsMatch("Patte", pattern, RegexOptions.IgnoreCase);
        Console.WriteLine($"Vérification (ignore case) pour 'Patte': Correspond? {startsWithPorPAnd4Lower}"); // False (à cause du 't' majuscule)

        bool startsWithPorPAnd4LowerOk = Regex.IsMatch("Plume", pattern, RegexOptions.IgnoreCase);
        Console.WriteLine($"Vérification (ignore case) pour 'Plume': Correspond? {startsWithPorPAnd4LowerOk}"); // True
    }
}
// Pour lancer les épreuves depuis votre code principal :
// SpecificAlphabetChecker.TestTheAlphabetSpell();
```
Ce qu'il faut retenir du Code C# :

string pattern = "^p[a-z]{4}";: La définition précise du sortilège.
Regex.IsMatch ou new Regex(pattern).IsMatch: Les deux méthodes pour appliquer le sort.
La Distinction Clé: La différence fondamentale avec ^p.{4} est que [a-z] est beaucoup plus restrictif que .. Seules les lettres minuscules sont acceptées pour les quatre caractères suivant le 'p'.
RegexOptions.IgnoreCase: Notez bien que cette option, si appliquée à ce pattern, ne rendrait que le p initial insensible à la casse. Elle ne changerait pas le comportement de [a-z], qui continuerait d'exiger des lettres minuscules. Pour accepter majuscules et minuscules après le 'p', il faudrait modifier le pattern lui-même (par exemple, en ^p[a-zA-Z]{4}).

#############################################################################################################

4. # Chaîne commençant par p et finissant par t
   p.*t

<La Signification du Sortilège p.*t :

p (La Rune Initiale) : Cherche le caractère littéral 'p' minuscule. C'est le point de départ de notre recherche.
.* (La Consommation Gourmande) : C'est la partie la plus intéressante et parfois la plus délicate !
. (Le Joker Universel) : Correspond à n'importe quel caractère unique (sauf le saut de ligne par défaut).
* (Le Multiplicateur Infini) : Correspond à l'élément précédent (.) zéro ou plusieurs fois.
La Gourmandise (Greediness) : Par défaut, le quantificateur * est gourmand. Cela signifie qu'il essaie de correspondre au plus grand nombre de caractères possible tout en permettant au reste du pattern (ici, le t) de correspondre à la fin. Il va "manger" autant de texte que possible.
t (La Rune Finale) : Cherche le caractère littéral 't' minuscule. C'est le point d'arrivée que la partie .* doit laisser accessible.
Donc, l'incantation p.*t recherche :

Un 'p' minuscule.
Suivi par la plus longue séquence possible de n'importe quels caractères (.*).
Se terminant par un 't' minuscule.
À cause de la gourmandise du .*, s'il y a plusieurs 't' après un 'p', la correspondance s'étendra jusqu'au dernier 't' possible dans la chaîne examinée, en partant du premier 'p' trouvé.

<La Transcription en C# :

Voici comment implémenter et utiliser ce sortilège gourmand en C# :
```cs
using System;
using System.Text.RegularExpressions; // N'oubliez pas d'importer la magie Regex !

public class GreedySegmentFinder
{
    // Méthode pour trouver des segments de 'p' à 't'
    public static void FindPToTGreedy(string scrollContent)
    {
        // L'incantation gourmande : p.*t
        // Cherche un 'p', consomme avidement tout jusqu'au dernier 't' possible.
        string pattern = "p.*t";

        // Forgeons notre outil de recherche Regex
        Regex greedyFinderRegex = new Regex(pattern);

        Console.WriteLine($"Analyse du manuscrit: '{scrollContent}'");

        // --- Vérifions d'abord si une telle séquence existe ---
        bool sequenceExists = greedyFinderRegex.IsMatch(scrollContent);
        Console.WriteLine($"  Contient une séquence 'p...t' ? : {sequenceExists}");

        // --- Trouvons la première (et souvent la seule à cause de la gourmandise) correspondance ---
        Match foundMatch = greedyFinderRegex.Match(scrollContent);
        if (foundMatch.Success)
        {
            // Affiche la totalité du texte capturé par la gourmandise
            Console.WriteLine($"  -> Correspondance trouvée (gourmande): '{foundMatch.Value}'");
            Console.WriteLine($"     (S'étend de l'index {foundMatch.Index} à {foundMatch.Index + foundMatch.Length})");
        }
        else if (sequenceExists) // Si IsMatch est true mais Match échoue (ne devrait pas arriver ici)
        {
             Console.WriteLine("  -> Étrange... IsMatch a réussi mais Match a échoué.");
        }
        else
        {
             Console.WriteLine("  -> Aucune séquence 'p...t' n'a été trouvée.");
        }

        // --- Pour illustrer la différence avec non-gourmand (lazy) ---
        string nonGreedyPattern = "p.*?t"; // Ajout du '?' pour rendre '*' non-gourmand
        Regex lazyFinderRegex = new Regex(nonGreedyPattern);
        MatchCollection lazyMatches = lazyFinderRegex.Matches(scrollContent);
        if (lazyMatches.Count > 0)
        {
            Console.WriteLine($"  -> Comparaison : Correspondances non-gourmandes ('p.*?t'):");
            foreach (Match lazyMatch in lazyMatches)
            {
                Console.WriteLine($"     - '{lazyMatch.Value}'");
            }
        }
         Console.WriteLine("-----------------------------------------"); // Séparateur
    }

    // Lançons les tests rituels
    public static void TestTheGreedySpell()
    {
        Console.WriteLine("--- Test de l'Incantation Gourmande 'p.*t' ---");

        FindPToTGreedy("A potent potion protects the patient.");
        // Attendu (gourmand) : "potent potion protects the patient" (du 'p' de potent au dernier 't' de patient)
        // Attendu (non-gourmand): "potent", "protects the patient" (s'arrête au premier 't' possible à chaque fois)

        FindPToTGreedy("prepare the potent part");
        // Attendu (gourmand) : "prepare the potent part" (du 'p' de prepare au 't' de part)
        // Attendu (non-gourmand): "prepare the potent", "part"

        FindPToTGreedy("typescript is great");
        // Attendu (gourmand) : "typescript is great"
        // Attendu (non-gourmand): "typescript", "great" (ne commence pas par 'p') -> Correction: "typescript" seulement

        FindPToTGreedy("path");
        // Attendu : Aucune correspondance

        FindPToTGreedy("test");
        // Attendu : Aucune correspondance

        FindPToTGreedy("prompt");
        // Attendu (gourmand) : "prompt"
        // Attendu (non-gourmand): "prompt"

        FindPToTGreedy("p\nt"); // '.' ne correspond pas à \n par défaut
        // Attendu : Aucune correspondance

        // Pour faire correspondre à travers les lignes (si nécessaire)
        Console.WriteLine("\n--- Test avec RegexOptions.Singleline ---");
        string multiLineText = "part one\npart two is present";
        Regex singlelineRegex = new Regex("p.*t", RegexOptions.Singleline);
        Match singlelineMatch = singlelineRegex.Match(multiLineText);
        Console.WriteLine($"Analyse de '{multiLineText.Replace("\n", "\\n")}' avec Singleline:");
        if (singlelineMatch.Success)
        {
            Console.WriteLine($"  -> Correspondance Singleline trouvée: '{singlelineMatch.Value.Replace("\n", "\\n")}'");
            // Attendu : "part one\npart two is present" (le '.' correspond maintenant à \n)
        }
        else
        {
             Console.WriteLine("  -> Aucune correspondance Singleline trouvée.");
        }

    }
}
// Pour exécuter les tests depuis votre code principal :
// GreedySegmentFinder.TestTheGreedySpell();
```
Éléments Clés du Code C# :

string pattern = "p.*t";: Déclare le sortilège gourmand.
Regex greedyFinderRegex = new Regex(pattern);: Forge l'outil Regex.
IsMatch: Vérifie simplement l'existence d'une correspondance.
Match: Trouve la première occurrence. À cause de la gourmandise de .*, cette première occurrence s'étendra souvent très loin, jusqu'au dernier t possible.
Comparaison avec p.*?t: L'ajout du ? après le * le rend non-gourmand (ou "paresseux"). Il essaiera alors de correspondre au plus petit nombre de caractères possible tout en permettant au reste du pattern (t) de correspondre. Matches utilisé avec p.*?t trouvera typiquement plusieurs correspondances courtes là où p.*t n'en trouverait qu'une longue.
RegexOptions.Singleline: Une option importante si vous voulez que le . corresponde également aux caractères de nouvelle ligne (\n), permettant à votre recherche de traverser les lignes.
Ce code C# vous permet de rechercher ces segments de texte délimités par 'p' et 't', en étant bien conscient de la nature expansive et gourmande du .* par défaut. Utilisez-le sagement !

#############################################################################################################

5. # Toutes les chaînes de 10 caractères suivant "<item>"
   <item>[a-zA-Z0-9]{10}

<La Signification du Sortilège <item>[a-zA-Z0-9]{10} :

<item> (Le Sigle d'Invocation) : Ceci correspond à la chaîne de caractères littérale <item>. Il ne s'agit pas d'une balise HTML au sens technique pour la Regex, mais simplement de cette séquence précise de 6 caractères.
[a-zA-Z0-9] (Le Sceau Alphanumérique) :
a-z : Correspond à n'importe quelle lettre minuscule.
A-Z : Correspond à n'importe quelle lettre majuscule.
0-9 : Correspond à n'importe quel chiffre.
Ensemble, [a-zA-Z0-9] correspond donc à un unique caractère alphanumérique (lettre ou chiffre). Notez que cela exclut les symboles, les espaces, et les underscores (_).
{10} (Le Décompte Sacré) : Ce quantificateur s'applique au sceau précédent [a-zA-Z0-9]. Il impose qu'il y ait exactement dix de ces caractères alphanumériques juste après <item>.
Donc, cette incantation recherche très précisément :

La chaîne littérale <item>.
Suivie immédiatement par dix caractères alphanumériques (et rien d'autre entre les deux).
Important : Ce pattern ne vérifie pas ce qui suit ces 10 caractères. Il trouvera une correspondance si cette séquence existe, même si elle est suivie par d'autres caractères (comme </item> ou du texte).

<La Transcription en C# :

Voici comment utiliser cette formule magique en C# pour dénicher ces codes spécifiques :
```cs
using System;
using System.Text.RegularExpressions; // Toujours invoquer le pouvoir Regex !

public class ItemIdentifier
{
    // Méthode pour rechercher la séquence d'item spécifique
    public static void FindItemCodeSequence(string dataStream)
    {
        // L'incantation : le sigle <item> suivi d'exactement 10 runes alphanumériques.
        string pattern = "<item>[a-zA-Z0-9]{10}";

        // Forgeons l'outil de détection
        Regex itemCodeRegex = new Regex(pattern);

        Console.WriteLine($"Analyse du flux de données: \"{dataStream}\"");

        // --- Vérification simple de présence ---
        bool patternFound = itemCodeRegex.IsMatch(dataStream);
        Console.WriteLine($"  Le pattern '<item> + 10 alphanum' existe ? : {patternFound}");

        // --- Recherche de la première occurrence ---
        // Note: La correspondance s'arrêtera après les 10 caractères alphanumériques.
        Match foundItem = itemCodeRegex.Match(dataStream);
        if (foundItem.Success)
        {
            Console.WriteLine($"  -> Séquence trouvée: '{foundItem.Value}'");
        }
        else if (patternFound)
        {
            Console.WriteLine("  -> Mystère... IsMatch dit oui, mais Match dit non ?!");
        }
        else
        {
            Console.WriteLine("  -> Aucune séquence correspondante trouvée.");
        }
        Console.WriteLine("---------------------------------------------");
    }

    // Méthode optionnelle pour extraire SEULEMENT le code de 10 caractères
    public static void ExtractItemCode(string dataStream)
    {
        // Incantation modifiée avec des parenthèses pour CAPTURER le code
        string extractingPattern = "<item>([a-zA-Z0-9]{10})";
        Regex extractingRegex = new Regex(extractingPattern);

        Console.WriteLine($"Tentative d'extraction sur: \"{dataStream}\"");
        Match match = extractingRegex.Match(dataStream);
        if (match.Success)
        {
            // match.Value contient toute la correspondance (<item>CODE)
            // match.Groups[0] aussi.
            // match.Groups[1] contient ce qui a été capturé par les parenthèses.
            string extractedCode = match.Groups[1].Value;
            Console.WriteLine($"  -> Code extrait (Groupe 1): '{extractedCode}' (depuis la correspondance complète '{match.Value}')");
        }
        else
        {
            Console.WriteLine("  -> Impossible d'extraire un code correspondant.");
        }
        Console.WriteLine("---------------------------------------------");
    }


    // Testons notre sortilège sur divers fragments de savoir
    public static void TestItemIdentification()
    {
        Console.WriteLine("--- Test de l'Incantation '<item>[a-zA-Z0-9]{10}' ---");

        FindItemCodeSequence("Log entry: <item>SWORD12345 found."); // True
        FindItemCodeSequence("<item>POTION0001 is empty");          // True
        FindItemCodeSequence("<item>abc123XYZ9");                  // False (9 caractères)
        FindItemCodeSequence("<item>SHIELD789012");                // True
        FindItemCodeSequence("<item>WAND_12345");                 // False (contient '_')
        FindItemCodeSequence("<item> AXE678901");                 // False (contient un espace)
        FindItemCodeSequence("<ITEM>HELMET0001");                 // False (casse de <item>)
        FindItemCodeSequence("<item>BOOK54321a</item>");          // True (matchera '<item>BOOK54321a')
        FindItemCodeSequence("no item here");                     // False

        Console.WriteLine("\n--- Test d'Extraction du Code ---");
        ExtractItemCode("Received: <item>GOLD999999. Sender: Guild.");
        ExtractItemCode("<item>RINGabcdef needs identification");
        ExtractItemCode("<item>toolong1234567890"); // N'extraira rien car le pattern de base ne match pas
        ExtractItemCode("<item>short"); // N'extraira rien
    }
}

// Pour lancer les tests :
// ItemIdentifier.TestItemIdentification();
```
Points Essentiels du Code C# :

string pattern = "<item>[a-zA-Z0-9]{10}";: La définition précise de ce que l'on cherche.
Regex itemCodeRegex = new Regex(pattern);: Création de l'outil Regex.
IsMatch: Pour une réponse rapide oui/non sur la présence du pattern.
Match: Pour obtenir la première occurrence trouvée. Notez que Match.Value contiendra la chaîne complète trouvée (ex: <item>SWORD12345).
Extraction avec Groupe (): Comme montré dans ExtractItemCode, si vous voulez isoler seulement les 10 caractères alphanumériques, vous devez les entourer de parenthèses dans votre pattern ("<item>([a-zA-Z0-9]{10})"). La partie capturée sera alors accessible via match.Groups[1].Value.
Ce code C# vous permet désormais de scanner vos textes à la recherche de ces identifiants <item> formatés de manière très stricte !
#############################################################################################################

Niveau difficile :

6. # Chaîne qui ressemble à une date écrite sous la forme 00/00/0000
   \d{2}\/\d{2}\/\d{4}
Ah, une formule pour déchiffrer les chronologies ! L'incantation \d{2}\/\d{2}\/\d{4} est un sortilège classique pour identifier des dates dans un format numérique spécifique, tel qu'on pourrait en trouver gravées sur d'anciennes stèles ou dans des registres poussiéreux. Voyons comment le manier en C#.

<La Signification du Sortilège \d{2}\/\d{2}\/\d{4} :

\d (La Rune Numérique) : Correspond à n'importe quel chiffre unique (de 0 à 9).
{2} (Le Duo Obligatoire) : Ce quantificateur exige que la rune précédente (\d) apparaisse exactement deux fois. Donc, \d{2} cherche une séquence de deux chiffres.
\/ (Le Séparateur Gravé) : Cette partie recherche le caractère littéral de la barre oblique /. Le \ est un caractère d'échappement ici. Dans de nombreux environnements Regex (comme JavaScript avec les littéraux /.../), la barre oblique a une signification spéciale et doit être échappée pour être traitée littéralement. En C#, dans une chaîne standard, \ est aussi un échappement, mais la barre oblique / n'a généralement pas besoin d'être échappée pour le moteur Regex lui-même. Cependant, l'utiliser (\/) est une pratique courante et sans danger pour assurer la portabilité ou si l'on a des doutes. Dans une chaîne verbatim C# (@""), \/ n'est pas nécessaire, un simple / suffit. Nous utiliserons la chaîne verbatim pour la clarté.
\d{2} : Encore une séquence de deux chiffres.
\/ : Encore une barre oblique littérale.
\d{4} : Une séquence de quatre chiffres.
Assemblées, ces runes recherchent un motif qui ressemble exactement à une date au format DD/MM/YYYY ou MM/DD/YYYY (comme la date d'aujourd'hui, 02/04/2025), où jour, mois et année sont représentés par un nombre fixe de chiffres.

<La Transcription en C# :

Voici le code C# pour utiliser cette formule de datation :
```cs
using System;
using System.Text.RegularExpressions; // Ne jamais oublier l'invocation Regex !

public class DateFormatFinder
{
    // Méthode pour trouver des dates au format XX/XX/XXXX
    public static void FindDateInFormat(string ancientScroll)
    {
        // L'incantation pour trouver les dates type DD/MM/YYYY.
        // Utilisation d'une chaîne verbatim (@"...") en C# :
        // C'est la méthode recommandée car elle évite les doubles échappements (\d devient \\d).
        // Le moteur Regex C# interprète \d correctement. La barre oblique / n'a
        // pas besoin d'être échappée ici.
        string pattern = @"\d{2}/\d{2}/\d{4}";

        // Alternative avec une chaîne C# standard (moins lisible) :
        // string patternEscaped = "\\d{2}\\/\\d{2}\\/\\d{4}"; // \ devient \\, / devient \/ (par habitude/portabilité)
        // Ou plus simplement en C# standard car / n'est pas spécial pour le moteur :
        // string patternStandard = "\\d{2}/\\d{2}/\\d{4}";

        // Créons notre outil de détection de dates
        Regex dateRegex = new Regex(pattern);

        Console.WriteLine($"Examen du parchemin: \"{ancientScroll}\"");

        // --- Vérifions la présence du format ---
        bool formatFound = dateRegex.IsMatch(ancientScroll);
        Console.WriteLine($"  Contient une date au format XX/XX/XXXX ? : {formatFound}");

        // --- Extrayons toutes les occurrences trouvées ---
        MatchCollection foundDates = dateRegex.Matches(ancientScroll);

        if (foundDates.Count > 0)
        {
            Console.WriteLine($"  -> {foundDates.Count} date(s) trouvée(s) dans ce format:");
            foreach (Match dateMatch in foundDates)
            {
                Console.WriteLine($"     - '{dateMatch.Value}' (Position: {dateMatch.Index})");
            }
            // Note : Cette Regex valide le *format*, pas la *validité* de la date.
            // '99/99/9999' correspondrait au format, mais n'est pas une date réelle.
            // Une validation supplémentaire serait nécessaire pour cela.
        }
        else if (formatFound)
        {
            Console.WriteLine("  -> Curieux, IsMatch est positif mais aucune correspondance retournée ?!");
        }
        else
        {
            Console.WriteLine("  -> Aucune date dans ce format spécifique n'a été trouvée.");
        }
        Console.WriteLine("--------------------------------------------------");
    }

    // Procédons à quelques tests temporels
    public static void TestDateFormatFinder()
    {
        Console.WriteLine("--- Test de l'Incantation de Date '\\d{2}/\\d{2}/\\d{4}' ---");
        string todayStr = DateTime.Now.ToString("dd/MM/yyyy"); // Ex: 02/04/2025

        FindDateInFormat($"Rapport daté du {todayStr}, Metz."); // True
        FindDateInFormat("Événements clés: 14/07/1789 et 11/11/1918."); // True (trouve les deux)
        FindDateInFormat("Validité : 01/01/2023 au 31/12/2025 inclus."); // True (trouve les deux)
        FindDateInFormat("Date limite : 1/5/2024");             // False (jour/mois à 1 chiffre)
        FindDateInFormat("Format US : 04/02/2025");             // True (correspond au format)
        FindDateInFormat("Format ISO : 2025-04-02");            // False (utilise des tirets)
        FindDateInFormat("Année courte : 02/04/25");              // False (année à 2 chiffres)
        FindDateInFormat("Date invalide mais format OK : 35/15/2000"); // True (le format est bon !)
        FindDateInFormat("Juste des chiffres : 1234567890");      // False
    }
}

// Pour lancer les tests depuis votre code principal :
// DateFormatFinder.TestDateFormatFinder();
```
Explication des Points Clés en C# :

string pattern = @"\d{2}/\d{2}/\d{4}";: L'utilisation de la chaîne verbatim @"" est cruciale pour la lisibilité en C#. Elle indique au compilateur C# de ne pas interpréter les barres obliques inverses \ comme des caractères d'échappement de la chaîne. Ainsi, \d est passé tel quel au moteur Regex, qui le comprend correctement comme "un chiffre". La barre oblique / n'ayant pas de signification spéciale pour le moteur Regex C#, elle n'a pas besoin d'être échappée (\/).
Regex dateRegex = new Regex(pattern);: Création de l'objet Regex spécialisé dans la recherche de ce format de date.
IsMatch: Pour vérifier rapidement si le texte contient au moins une correspondance.
Matches: Pour obtenir toutes les occurrences de dates correspondant au format dans le texte. Utile si un texte contient plusieurs dates.
Validation du Format vs. Validité de la Date: Il est important de noter que cette Regex valide uniquement si la chaîne ressemble à une date XX/XX/XXXX. Elle ne vérifie pas si c'est une date calendaire valide (par exemple, 31/02/2025 correspondrait au format mais est impossible). Pour une validation complète, vous devriez extraire la date correspondante et utiliser les fonctions DateTime.TryParseExact de C#.
#############################################################################################################

7. # Chaîne qui ressemble à un nombre qui peut éventuellement être négatif, et éventuellement être décimal (avec une virgule donc)
   -?\d+(\.\d+)?

<La Signification du Sortilège -?\d+(\.\d+)? :

-? (Le Signe Optionnel du Froid) :
- : Correspond au caractère littéral du tiret (signe moins).
? : Ce quantificateur rend le tiret optionnel (il peut y être zéro ou une fois). Cela permet de trouver aussi bien les nombres positifs que négatifs.
\d+ (Le Cœur Numérique) :
\d : La rune numérique, correspondant à n'importe quel chiffre (0-9).
+ : Ce quantificateur signifie "une ou plusieurs fois". Il garantit qu'il y a au moins un chiffre, formant la partie entière du nombre.
(\.\d+)? (La Poussière Fractionnaire Optionnelle) :
(...) : Définit un groupe.
\. : Correspond au caractère littéral du point (.). Il doit être échappé avec \ car le point seul est un joker en Regex. C'est notre séparateur décimal ici.
\d+ : Une ou plusieurs runes numériques après le point, formant la partie décimale.
? : Ce quantificateur final rend tout le groupe (\.\d+) optionnel. Le nombre peut donc être un entier (sans partie décimale) ou un nombre décimal.
En résumé, cette incantation recherche :

Un éventuel signe moins (-).
Suivi d'au moins un chiffre (partie entière).
Suivi éventuellement d'un point (.) et d'au moins un chiffre (partie décimale).
Elle est donc capable de trouver des nombres entiers ou décimaux, positifs ou négatifs, utilisant le point comme séparateur décimal.

<La Transcription en C# :

Voici le code C# pour déployer ce sortilège de détection numérique :
```cs
using System;
using System.Text.RegularExpressions; // L'arsenal magique des Regex
using System.Globalization;          // Pour la gestion des formats numériques (culture)

public class NumericValueExtractor
{
    // Méthode pour trouver des valeurs numériques (entières ou décimales avec '.')
    public static void FindNumbersInText(string arcaneManuscript)
    {
        // L'incantation pour dénicher les nombres : -?\d+(\.\d+)?
        // Utilisation de la chaîne verbatim @"" pour une meilleure lisibilité en C#.
        // Le \. est correctement interprété comme un point littéral par le moteur Regex.
        string pattern = @"-?\d+(\.\d+)?";

        // Forgeons notre outil de détection numérique
        Regex numberRegex = new Regex(pattern);

        Console.WriteLine($"Fouille du manuscrit: \"{arcaneManuscript}\"");

        // --- Vérification de la présence de nombres ---
        bool numbersFound = numberRegex.IsMatch(arcaneManuscript);
        Console.WriteLine($"  Contient des valeurs numériques (format '.') ? : {numbersFound}");

        // --- Extraction de toutes les occurrences ---
        MatchCollection foundNumbers = numberRegex.Matches(arcaneManuscript);

        if (foundNumbers.Count > 0)
        {
            Console.WriteLine($"  -> {foundNumbers.Count} valeur(s) numérique(s) découverte(s):");
            foreach (Match numberMatch in foundNumbers)
            {
                string matchedString = numberMatch.Value;
                Console.WriteLine($"     - '{matchedString}' (Index: {numberMatch.Index})");

                // Tentative de conversion en nombre C# pour validation/utilisation
                // Utilisation de CultureInfo.InvariantCulture pour que '.' soit TOUJOURS
                // interprété comme séparateur décimal, indépendamment des réglages système (comme à Metz/France où c'est ',')
                if (decimal.TryParse(matchedString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal numericValue))
                {
                    Console.WriteLine($"       (Interprété comme décimal : {numericValue})");
                }
                else
                {
                    // Ne devrait pas arriver si la Regex a matché, mais par sécurité...
                    Console.WriteLine($"       (Échec de l'interprétation en décimal avec InvariantCulture)");
                }
            }
             Console.WriteLine($"  (Note: Ce sort ne reconnaît que '.' comme séparateur décimal, pas la virgule ',')");
        }
        else if (numbersFound)
        {
             Console.WriteLine("  -> Intriguant... IsMatch rapporte une présence, mais aucune valeur n'est extraite.");
        }
        else
        {
            Console.WriteLine("  -> Aucune valeur numérique correspondant à ce format n'a été trouvée.");
        }
        Console.WriteLine("----------------------------------------------------");
    }

    // Testons l'efficacité de notre sortilège
    public static void TestNumberExtraction()
    {
        Console.WriteLine("--- Test de l'Incantation Numérique '-?\\d+(\\.\\d+)?' ---");

        FindNumbersInText("Il reste 15 potions et -3 antidotes. Coût: 49.95 or."); // Trouve 15, -3, 49.95
        FindNumbersInText("Température: -10.5 degrés. Pression: 1013 bar.");       // Trouve -10.5, 1013
        FindNumbersInText("Un simple 0 ou 1 peuvent changer le destin.");           // Trouve 0, 1
        FindNumbersInText("Pi vaut environ 3.14159");                              // Trouve 3.14159
        FindNumbersInText("Version 2.0 du grimoire.");                              // Trouve 2.0
        FindNumbersInText("Nombre sans partie entière: .5 ou -.5");                 // Ne trouve rien (le \d+ l'exige)
        FindNumbersInText("Nombre avec virgule: 12,5 euros.");                    // Trouve 12 et 5 séparément !
        FindNumbersInText("Texte sans nombres.");                                  // Ne trouve rien
        FindNumbersInText("Position X:42 Y:-100 Z:0.0");                          // Trouve 42, -100, 0.0
    }
}

// Pour lancer les tests depuis votre code :
// NumericValueExtractor.TestNumberExtraction();
```
Explications du Code C# :

string pattern = @"-?\d+(\.\d+)?";: La définition claire du pattern Regex grâce à la chaîne verbatim @"". \. est essentiel pour cibler le point littéral.
Regex numberRegex = new Regex(pattern);: Création de l'objet Regex.
IsMatch: Pour une vérification rapide.
Matches: Pour récupérer toutes les séquences qui correspondent au pattern dans le texte.
decimal.TryParse(..., CultureInfo.InvariantCulture, ...): Après avoir trouvé une chaîne qui correspond (ex: "-10.5"), cette partie montre comment essayer de la convertir en un type numérique C# (decimal ici). L'utilisation de CultureInfo.InvariantCulture est cruciale car elle garantit que le . est interprété comme le séparateur décimal, indépendamment des paramètres régionaux de l'ordinateur (qui, en France par exemple, utiliseraient la virgule ,).
Limitation Culturelle: Le code et les commentaires soulignent que ce pattern spécifique ne fonctionnera pas pour les nombres utilisant une virgule comme séparateur décimal (courant en France/Metz). Une autre Regex ou un traitement supplémentaire serait nécessaire pour gérer ce cas.
#############################################################################################################

Exercice avec des captures :

8. # Capturer tous les mots d'un texte qui commencent par la lettre a
   a\w+

<La Signification du Sortilège a\w+ :

a (La Rune Initiale) : Recherche le caractère littéral 'a' minuscule.
\w (La Rune de Mot) : Correspond à n'importe quel "caractère de mot". Ceci inclut :
Les lettres minuscules (a à z)
Les lettres majuscules (A à Z)
Les chiffres (0 à 9)
Le caractère de soulignement (_)
+ (Le Multiplicateur) : Exige que la rune \w précédente apparaisse une ou plusieurs fois.
Ce sortilège trouve donc toute séquence qui commence par 'a' et est suivie d'au moins un caractère de mot. Exemples : apple, and, a1, an_underscore.

<La Transcription en C# avec Capture :

Voici comment implémenter cela en C#, en distinguant la capture implicite de la totalité et la capture explicite d'une partie.
```cs
using System;
using System.Text.RegularExpressions; // N'oubliez pas d'invoquer la magie Regex !

public class WordHunter
{
    // --- Scénario 1: Trouver les mots, capture implicite de TOUTE la correspondance ---
    public static void FindWordsStartingWithA_ImplicitCapture(string sacredText)
    {
        // L'incantation simple : a\w+
        string pattern = @"a\w+"; // Utilisation de la chaîne verbatim @""

        Regex wordRegex = new Regex(pattern, RegexOptions.IgnoreCase); // Ajout IgnoreCase pour 'a' ou 'A'

        Console.WriteLine($"--- Chasse aux mots (Capture Totale) dans : \"{sacredText}\" ---");
        MatchCollection foundWords = wordRegex.Matches(sacredText);

        if (foundWords.Count > 0)
        {
            Console.WriteLine($"  -> {foundWords.Count} mot(s) commençant par 'a'/'A' trouvé(s):");
            foreach (Match wordMatch in foundWords)
            {
                // La capture implicite est la valeur complète de la correspondance
                // Accessible via wordMatch.Value ou wordMatch.Groups[0].Value
                Console.WriteLine($"     - Correspondance complète (Value): '{wordMatch.Value}'");
                // Console.WriteLine($"     - Correspondance complète (Groups[0]): '{wordMatch.Groups[0].Value}'");
            }
        }
        else
        {
            Console.WriteLine("  -> Aucun mot correspondant trouvé.");
        }
        Console.WriteLine("-------------------------------------------------------");
    }

    // --- Scénario 2: Trouver les mots ET capturer EXPLICITEMENT la partie APRÈS 'a'/'A' ---
    public static void FindAndCaptureAfterInitialA(string sacredText)
    {
        // Incantation modifiée avec parenthèses pour la capture explicite : a(\w+)
        // Les parenthèses créent le Groupe de Capture 1
        string pattern = @"a(\w+)"; // Notez les parenthèses autour de \w+

        // Ajout de IgnoreCase pour que 'a' ou 'A' fonctionnent au début
        Regex captureRegex = new Regex(pattern, RegexOptions.IgnoreCase);

        Console.WriteLine($"--- Chasse aux mots (Capture après 'a'/'A') dans : \"{sacredText}\" ---");
        MatchCollection foundMatches = captureRegex.Matches(sacredText);

        if (foundMatches.Count > 0)
        {
            Console.WriteLine($"  -> {foundMatches.Count} occurrence(s) trouvée(s) avec capture:");
            foreach (Match match in foundMatches)
            {
                // Groupe 0 contient TOUJOURS la correspondance complète
                Console.WriteLine($"     - Correspondance complète (Groups[0]): '{match.Groups[0].Value}'");
                // Groupe 1 contient ce qui a été capturé par les PREMIÈRES parenthèses
                Console.WriteLine($"       -> Partie Capturée (Groups[1]): '{match.Groups[1].Value}'");
            }
        }
        else
        {
             Console.WriteLine("  -> Aucune occurrence correspondante trouvée pour la capture.");
        }
        Console.WriteLine("-------------------------------------------------------");
    }

    // Lançons les tests sur des fragments de texte
    public static void TestTheHunt()
    {
        Console.WriteLine("### Test des Incantations 'a\\w+' et 'a(\\w+)' ###\n");
        string text1 = "An ancient artifact appeared around April.";
        // Texte utilisant potentiellement le contexte actuel (Metz, 2025)
        string text2 = "Archives de Metz: an 2025, absolument aucun artefact Antérieur.";
        string text3 = "1 apple, _a_test, b C d"; // Teste chiffres et underscores

        Console.WriteLine(">>> Test avec Capture Totale (a\\w+) <<<");
        FindWordsStartingWithA_ImplicitCapture(text1);
        FindWordsStartingWithA_ImplicitCapture(text2);
        FindWordsStartingWithA_ImplicitCapture(text3); // Devrait trouver 'apple' mais pas '_a_test' à cause de l'espace

        Console.WriteLine("\n>>> Test avec Capture après 'a'/'A' (a(\\w+)) <<<");
        FindAndCaptureAfterInitialA(text1);
        FindAndCaptureAfterInitialA(text2);
        FindAndCaptureAfterInitialA(text3);
    }
}

// Pour exécuter les tests depuis votre code principal :
// WordHunter.TestTheHunt();
```
Explication de la Capture en C# :

Capture Implicite (Tout le Match): Quand vous utilisez une Regex comme a\w+, le moteur trouve les sous-chaînes correspondantes (ex: "ancient", "artifact", "appeared", "around", "April"). En C#, l'objet Match retourné contient cette correspondance complète dans sa propriété Value et aussi dans Groups[0].Value. C'est la capture par défaut.
Capture Explicite (Groupes (...)): Lorsque vous ajoutez des parenthèses dans votre Regex, comme dans a(\w+), vous créez un groupe de capture.
Groups[0] contient toujours la correspondance complète (ex: "ancient").
Groups[1] contient la partie du texte qui a correspondu à l'intérieur des premières parenthèses (ex: "ncient").
S'il y avait d'autres paires de parenthèses, elles seraient Groups[2], Groups[3], etc.
RegexOptions.IgnoreCase: J'ai ajouté cette option lors de la création de l'objet Regex. Elle permet au a initial de correspondre indifféremment à 'a' ou 'A', ce qui est souvent souhaitable pour ce genre de recherche.
#############################################################################################################

9. # Capturer toutes les occurrences qui ressemblent à un nom de fichier qui finit par .png et ne garder que le nom du fichier (et pas le .png donc)
   \/?([a-zA-Z0-9_-]+\.png)

<La Signification du Sortilège \/?([a-zA-Z0-9_-]+\.png) :

\/? (Le Chemin Optionnel) :
\/ : Recherche le caractère littéral de la barre oblique /. L'échappement \ est une bonne pratique pour la clarté ou la portabilité, même si en C# dans une chaîne @"", un simple / suffirait souvent.
? : Rend cette barre oblique optionnelle. Le nom de fichier peut donc être précédé ou non d'un /.
( (Ouverture du Sceau de Capture) : Ceci marque le début du Groupe de Capture numéro 1. Tout ce qui correspondra à l'intérieur de ces parenthèses sera mémorisé séparément.
[a-zA-Z0-9_-]+ (Le Nom du Parchemin) :
[...] : Définit un ensemble de caractères autorisés.
a-zA-Z0-9 : Lettres (majuscules et minuscules) et chiffres.
_ : Le caractère de soulignement.
- : Le tiret.
Ensemble, [a-zA-Z0-9_-] correspond à un unique caractère qui est une lettre, un chiffre, un underscore ou un tiret (caractères très courants dans les noms de fichiers).
+ : Exige qu'il y ait au moins un de ces caractères pour former le nom de base du fichier.
\. (Le Point de Séparation) : Recherche le caractère littéral du point .. L'échappement \ est essentiel ici, car un point non échappé est un joker qui correspond à n'importe quel caractère.
png (Le Type de Parchemin) : Recherche la séquence littérale de caractères png. Par défaut, c'est sensible à la casse (ne trouvera pas .PNG).
) (Fermeture du Sceau de Capture) : Marque la fin du Groupe de Capture 1.
En somme, ce sortilège recherche :

Une éventuelle barre oblique /.
Suivie d'un nom de fichier contenant des lettres, chiffres, underscores ou tirets.
Suivi d'un point littéral ..
Suivi de l'extension littérale png.
La partie nom_de_fichier.png est explicitement capturée dans le Groupe 1.

<La Transcription en C# avec Capture :

Voici comment utiliser cette Regex en C# et accéder aux informations capturées :
```cs
using System;
using System.Text.RegularExpressions; // La source de notre pouvoir Regex

public class PngImageLocator
{
    // Méthode pour trouver et capturer les noms de fichiers PNG
    public static void FindAndCapturePngReferences(string textFragment)
    {
        // L'incantation : /?([a-zA-Z0-9_-]+\.png)
        // Note: Dans une chaîne C# verbatim (@""), le '/' n'a pas besoin d'être échappé.
        // Le '\.' est crucial pour le point littéral.
        string pattern = @"/?([a-zA-Z0-9_-]+\.png)";

        // Forgeons notre outil de localisation Regex
        // Par défaut, la recherche est sensible à la casse (pour 'png')
        Regex pngFinderRegex = new Regex(pattern);

        Console.WriteLine($"--- Recherche de références PNG dans : \"{textFragment}\" ---");
        MatchCollection foundReferences = pngFinderRegex.Matches(textFragment);

        if (foundReferences.Count > 0)
        {
            Console.WriteLine($"  -> {foundReferences.Count} référence(s) PNG trouvée(s) :");
            foreach (Match match in foundReferences)
            {
                // Groupe 0 : La correspondance complète (incluant le '/' optionnel)
                // Exemple : "/images/icon.png" ou "button.png"
                Console.WriteLine($"     - Correspondance Totale (Groupe 0): '{match.Groups[0].Value}'");

                // Groupe 1 : La partie capturée par les parenthèses (le nom du fichier .png)
                // Exemple : "icon.png" ou "button.png"
                Console.WriteLine($"       -> Nom de Fichier Capturé (Groupe 1): '{match.Groups[1].Value}'");
            }
        }
        else
        {
            Console.WriteLine("  -> Aucune référence PNG correspondante trouvée.");
        }
        Console.WriteLine("-------------------------------------------------------");
    }

    // Procédons aux tests d'invocation
    public static void TestPngLocator()
    {
        Console.WriteLine("### Test de l'Incantation '/?([a-zA-Z0-9_-]+\\.png)' ###\n");

        string sample1 = "Le logo est logo.png, chemin complet /assets/images/logo.png.";
        string sample2 = "Interface: button-ok.png, /icons/icon_cancel.png, avatar_123.png";
        // Exemple avec contexte Metz/Date
        string sample3 = "Rapport Metz 2025-04-02: voir schema_flux.png et carte_region_est.png";
        string sample4 = "Fichiers à ignorer : image.jpg, data.zip, /backup/archive.tar.gz";
        string sample5 = "Attention: fichier endommagé map.PNG"; // Ne trouvera pas car 'PNG' est en majuscules

        FindAndCapturePngReferences(sample1);
        FindAndCapturePngReferences(sample2);
        FindAndCapturePngReferences(sample3);
        FindAndCapturePngReferences(sample4);
        FindAndCapturePngReferences(sample5);

        // --- Test avec IgnoreCase ---
        Console.WriteLine("\n--- Test avec l'option IgnoreCase pour '.png' / '.PNG' ---");
        Regex pngFinderIgnoreCase = new Regex(pattern, RegexOptions.IgnoreCase); // Ajout de l'option
         Console.WriteLine($"--- Recherche (IgnoreCase) dans : \"{sample5}\" ---");
        MatchCollection ignoreCaseMatches = pngFinderIgnoreCase.Matches(sample5);
         if (ignoreCaseMatches.Count > 0)
        {
             Console.WriteLine($"  -> {ignoreCaseMatches.Count} référence(s) PNG/png trouvée(s) :");
             foreach (Match match in ignoreCaseMatches) {
                 Console.WriteLine($"     - Correspondance Totale (Groupe 0): '{match.Groups[0].Value}'");
                 Console.WriteLine($"       -> Nom de Fichier Capturé (Groupe 1): '{match.Groups[1].Value}'");
             }
        } else { Console.WriteLine("  -> Aucune référence PNG/png trouvée."); }
         Console.WriteLine("-------------------------------------------------------");
    }
}

// Pour lancer les tests depuis votre code principal :
// PngImageLocator.TestPngLocator();
```
Points Clés de la Capture en C# :

string pattern = @"/?([a-zA-Z0-9_-]+\.png)";: La définition du pattern avec les parenthèses () qui créent le groupe de capture.
MatchCollection foundReferences = pngFinderRegex.Matches(textFragment);: Trouve toutes les occurrences.
match.Groups[0].Value: Contient toujours la chaîne de caractères complète qui a correspondu à l'ensemble du pattern (par exemple, /logo.png ou button-ok.png). C'est identique à match.Value.
match.Groups[1].Value: Contient uniquement la partie du texte qui a correspondu à l'intérieur de la première paire de parenthèses capturantes (par exemple, logo.png ou button-ok.png). C'est généralement ce que l'on cherche à "capturer" dans ce cas : le nom de fichier lui-même.
Sensibilité à la Casse et RegexOptions.IgnoreCase: Par défaut, la partie png est sensible à la casse. Si vous voulez trouver .png, .PNG, .pNg, etc., vous devez ajouter RegexOptions.IgnoreCase lors de la création de l'objet Regex, comme montré dans le dernier test.
#############################################################################################################

10. # Capturer le tag de toutes les balises d'un fichier HTML ou XAML (par exemple une balise <div id="pouetpouet"> devrait capturer div)
    <([a-z]+)(\s+[^>]+)?>

<La Signification du Sortilège (Rappel) :

Ce sortilège est conçu pour trouver des balises ouvrantes simples, de type HTML ou XML, avec quelques caractéristiques précises :

< : Commence par un chevron ouvrant littéral.
([a-z]+) : Groupe de Capture 1 : Recherche et capture un nom de balise composé d'une ou plusieurs lettres minuscules.
(\s+[^>]+)? : Groupe de Capture 2 (Optionnel) :
\s+ : Recherche un ou plusieurs espaces (le début des attributs).
[^>]+ : Recherche un ou plusieurs caractères qui ne sont PAS un chevron fermant (le contenu des attributs).
? : Rend tout ce groupe d'attributs optionnel.
> : Se termine par un chevron fermant littéral.
Il trouvera <p>, <div>, <span class='hero'>, etc., et capturera séparément le nom de la balise et ses attributs (s'ils existent).

La Transcription en C# avec Capture Détaillée :

Voici comment utiliser cette Regex en C# et extraire les différentes parties capturées :
```cs
using System;
using System.Text.RegularExpressions; // L'arsenal indispensable

public class HtmlTagDecoder
{
    // Méthode pour trouver les balises et décoder leurs parties capturées
    public static void FindAndDecodeTags(string textContainingTags)
    {
        // L'incantation pour les balises simples, avec ses deux sceaux de capture.
        // Utilisation de la chaîne verbatim @"" pour une lisibilité optimale en C#.
        string pattern = @"<([a-z]+)(\s+[^>]+)?>";

        // Forgeons l'outil Regex. Note : sensible à la casse pour le nom de balise [a-z].
        Regex tagDecoderRegex = new Regex(pattern);

        Console.WriteLine($"--- Décodage des balises simples dans : \"{textContainingTags}\" ---");
        MatchCollection foundTags = tagDecoderRegex.Matches(textContainingTags);

        if (foundTags.Count > 0)
        {
            Console.WriteLine($"  -> {foundTags.Count} balise(s) simple(s) trouvée(s) :");
            int i = 0;
            foreach (Match tagMatch in foundTags)
            {
                i++;
                Console.WriteLine($"     --- Balise {i} ---");

                // Groupe 0 : Toujours la correspondance complète.
                Console.WriteLine($"       - Correspondance Totale (Groupe 0): '{tagMatch.Groups[0].Value}'");

                // Groupe 1 : Le nom de la balise (capturé par les premières parenthèses).
                // Ce groupe est garanti d'exister si la correspondance est trouvée.
                Console.WriteLine($"       - Nom de Balise Capturé (Groupe 1) : '{tagMatch.Groups[1].Value}'");

                // Groupe 2 : Les attributs (capturés par les secondes parenthèses).
                // Ce groupe est OPTIONNEL (? final). Il faut vérifier s'il a réussi !
                if (tagMatch.Groups[2].Success)
                {
                    // Il y avait des attributs. La valeur inclut l'espace initial.
                    Console.WriteLine($"       - Attributs Capturés (Groupe 2)    : '{tagMatch.Groups[2].Value}'");
                }
                else
                {
                    // Pas d'attributs trouvés pour cette balise.
                    Console.WriteLine($"       - Attributs Capturés (Groupe 2)    : [Aucun attribut]");
                }
            }
        }
        else
        {
            Console.WriteLine("  -> Aucune balise simple correspondante trouvée.");
        }
        Console.WriteLine("-------------------------------------------------------------");
    }

    // Exécutons quelques tests de décodage
    public static void TestTagDecoding()
    {
        Console.WriteLine("### Test de l'Incantation de Balise '<([a-z]+)(\\s+[^>]+)?>' ###\n");

        string htmlDoc = "<html><head><title>Test</title></head><body><p class='intro'>Bonjour!</p><div></div><img src='image.png'></body></html>";
        string xmlData = "<data><record id='1'>valeur1</record><record id='2' status='ok'>valeur2</record></data>";
        // Exemple avec contexte Metz/Date
        string logMetz = $"<log timestamp='{DateTime.Now:yyyy-MM-dd HH:mm:ss}' location='Metz'><event level='info'>Service démarré.</event></log>";
        string noTags = "Juste du texte simple.";
        string upperCaseTag = "<BODY><P>Majuscules</P></BODY>"; // Ne sera pas trouvé par [a-z]

        FindAndDecodeTags(htmlDoc);
        FindAndDecodeTags(xmlData);
        FindAndDecodeTags(logMetz);
        FindAndDecodeTags(noTags);
        FindAndDecodeTags(upperCaseTag); // Pour montrer la sensibilité à la casse

        // Pour trouver aussi les majuscules, il faudrait [a-zA-Z] ou RegexOptions.IgnoreCase
    }
}

// Pour lancer les tests depuis votre code :
// HtmlTagDecoder.TestTagDecoding();
```
Comprendre la Capture en C# ici :

string pattern = @"<([a-z]+)(\s+[^>]+)?>";: Le pattern contient deux paires de parenthèses (...), créant deux groupes de capture explicites.
MatchCollection foundTags = tagDecoderRegex.Matches(textContainingTags);: Trouve toutes les occurrences dans le texte.
tagMatch.Groups[0].Value: Pour chaque Match (tagMatch), Groups[0] contient toujours la correspondance complète de la Regex (ex: <p class='intro'> ou <div>). C'est identique à tagMatch.Value.
tagMatch.Groups[1].Value: Contient ce qui a été capturé par le premier groupe ([a-z]+), c'est-à-dire le nom de la balise (ex: p ou div).
tagMatch.Groups[2].Success et tagMatch.Groups[2].Value: Contient ce qui a été capturé par le deuxième groupe (\s+[^>]+). Comme ce groupe est optionnel (à cause du ? final), il est crucial de vérifier d'abord tagMatch.Groups[2].Success. Si c'est true, alors tagMatch.Groups[2].Value contiendra les attributs (ex: class='intro'). Si c'est false, cela signifie qu'il n'y avait pas d'attributs pour cette balise.