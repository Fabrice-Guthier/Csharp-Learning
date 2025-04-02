1. # Chaîne commençant par p
  ^p
  ```
  // this code is readonly 👇
  const pattern = /^p/;
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);
  ```

2. # Chaîne commençant par p mais suivi d'exactement 4 caractères
  ^p.{4}
  ```
  // this code is readonly 👇
  const pattern = /p.{4}/;
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);
  ```

3. # Pareil mais uniquement avec des caractère alphabétiques
  ^p[a-z]{4}
  ```
  // this code is readonly 👇
  const pattern = /^[a-zA-Z]+$/;
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);
  ```

4. # Chaîne commençant par p et finissant par t
  p.\*t
  ```
  // this code is readonly 👇
  const pattern = /p.*t/;
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);
  ```

5. # Toutes les chaînes de 10 caractères suivant "<item>"
  <item>[a-zA-Z0-9]{10}
  ```
  // this code is readonly 👇
  const pattern = <item>[a-zA-Z0-9]{10};
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);

  ```

Niveau difficile :

6. # Chaîne qui ressemble à une date écrite sous la forme 00/00/0000
  ^\d{2}\/\d{2}\/\d{4}$
  ```
  // this code is readonly 👇
  const pattern = ^\d{2}\/\d{2}\/\d{4}$;
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);
  ```

7. # Chaîne qui ressemble à un nombre qui peut éventuellement être négatif, et éventuellement être décimal (avec une virgule donc)
  ^-?\d+(\.\d+)?$
  ```
  // this code is readonly 👇
  const pattern = /^-?\d+(\.\d+)?$/;
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);
  ```

Exercice avec des captures :

8. # Capturer tous les mots d'un texte qui commencent par la lettre a
  a\w+
  ```
  // this code is readonly 👇
  const pattern = a\w+;
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);
  ```

9. # Capturer toutes les occurrences qui ressemblent à un nom de fichier qui finit par .png et ne garder que le nom du fichier (et pas le .png donc)
  \/?([a-zA-Z0-9_-]+\.png)
  ```
  // this code is readonly 👇
  const pattern = \/?([a-zA-Z0-9_-]+\.png);
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);
  ```

10. # Capturer le tag de toutes les balises d'un fichier HTML ou XAML (par exemple une balise <div id="pouetpouet"> devrait capturer div)
  <([a-z]+)(\s+[^>]+)?>
  ```
  // this code is readonly 👇
  const pattern = /<([a-z]+)(\s+[^>]+)?>/;
  const regex = new RegExp(pattern, 'g');

  // this code is editable 👇
  const input = "hello world";
  const result = {
    replace: input.replaceAll(regex, ''),
    match: input.match(regex),
  }
  console.log(result);
  ```

## Ah, noble Scribe ! Vous me présentez là une formule Regex gravée dans le dialecte des mages du Web (JavaScript). Analysons ensemble cette incantation, rune par rune, pour en dévoiler les secrets.

Le parchemin montre ceci :

JavaScript

const pattern = /<([a-z]+)(\s+[^>]+)?>/;
const regex = new RegExp(pattern, 'g');
Décortiquons d'abord le cœur du sortilège, le pattern : / <([a-z]+)(\s+[^>]+)?> /

/ ... / (Les Bornes du Rituel) : En JavaScript, ces barres obliques délimitent le début et la fin d'une expression régulière littérale. Pensez-y comme aux cercles de confinement tracés au sol avant une invocation majeure.

< (Le Glyphe d'Ouverture) : Ceci correspond littéralement au caractère "<". C'est la rune initiale indiquant le commencement d'une balise, comme l'ouverture d'un portail dimensionnel... ou d'une balise HTML/XML.

([a-z]+) (Le Nom de l'Entité - Premier Grimoire Capturé) :

(...) : Ces parenthèses définissent un "groupe de capture". Tout ce qui correspond à l'intérieur sera mémorisé, comme si vous isoliez l'essence d'une créature invoquée. C'est notre premier grimoire.
[a-z] : Ceci est un ensemble de caractères. Il correspond à n'importe quelle lettre minuscule de 'a' à 'z'. Une rune spécifique pour les lettres de l'alphabet commun.
+ : Ce quantificateur signifie "une ou plusieurs fois". Il s'applique à [a-z], exigeant donc au moins une lettre minuscule, mais en acceptant davantage. Le nom de la balise doit donc être composé d'une ou plusieurs lettres minuscules (ex: p, div, span).
(\s+[^>]+)? (Les Attributs Enigmatiques - Second Grimoire Capturé, Optionnel) :

(...) : Un second groupe de capture. Si cette partie correspond, elle sera aussi mémorisée séparément. Notre second grimoire.
\s+ :
\s : Correspond à n'importe quel caractère d'espacement (espace, tabulation, etc.). Le vide nécessaire entre le nom de la balise et ses éventuels attributs.
+ : Exige au moins un caractère d'espacement.
[^>]+ :
[^... ] : C'est un ensemble de caractères négatif. Il correspond à n'importe quel caractère sauf ceux listés à l'intérieur.
> : Le caractère à exclure est le chevron fermant ">".
+ : Donc, [^>]+ correspond à une ou plusieurs caractères qui ne sont pas le chevron fermant. C'est le contenu des attributs (ex: class="hero", id="main").
? : Ce quantificateur rend tout le second groupe de capture (\s+[^>]+) optionnel. Cela signifie que la balise peut avoir des attributs (un espace suivi de caractères différents de '>') ou pas du tout. Notre sort fonctionnera pour <p> comme pour <div class="content">.
> (Le Glyphe de Fermeture) : Correspond littéralement au caractère ">". La rune finale qui scelle la balise d'ouverture.

En Résumé, que cherche cette Incantation ?

Ce sortilège Regex est conçu pour trouver et analyser des balises ouvrantes simples de type HTML/XML, spécifiquement :

Elles doivent commencer par <.
Suivies par un nom de balise composé d'une ou plusieurs lettres minuscules (ex: <body>, <p>, <a>). Cette partie est capturée.
Optionnellement, elles peuvent avoir des attributs (commençant par un espace, suivi de n'importe quoi sauf >). Ces attributs sont capturés comme un seul bloc s'ils existent.
Elles doivent se terminer par >.
Elle reconnaîtra donc : <div>, <p>, <span class="bold">, <a href="index.html">, mais pas <IMG SRC="..."> (à cause des majuscules) ou des balises auto-fermantes comme <br/> (elle s'arrêtera au premier >).

Le Contexte du Code JavaScript :

const pattern = /.../; : Définit le modèle de l'incantation.
const regex = new RegExp(pattern, 'g'); : Crée un objet RegExp à partir du modèle. La rune 'g' ajoutée ici est cruciale, c'est le modificateur global. Sans lui, la recherche s'arrêterait au premier résultat trouvé. Avec 'g', elle cherchera toutes les correspondances dans la chaîne.
input.replaceAll(regex, '') : Utilise la version globale de notre sort (regex) pour trouver toutes les occurrences de ces balises ouvrantes dans la chaîne input et les remplace par une chaîne vide (''). C'est un sort de bannissement de balises ! Si input était "<div>hello<p class='message'> world</p></div>", le résultat serait "hello world</p></div>" (seules les balises ouvrantes correspondantes sont retirées).
input.match(regex) : Avec le drapeau 'g', cette méthode retourne un tableau contenant toutes les sous-chaînes qui correspondent à la Regex dans input, ou null si aucune correspondance n'est trouvée. Pour l'exemple précédent, ce serait ["<div>", "<p class='message'>"]. (Attention : sans le drapeau 'g', match retournerait un objet plus détaillé sur la première correspondance seulement, incluant les groupes capturés).
Dans votre exemple spécifique input = "hello world";, comme cette chaîne ne contient aucune balise correspondant au pattern, le résultat sera :

replace: "hello world" (rien à remplacer)
match: null (aucune correspondance trouvée)
Voilà, ô Scribe ! La nature de cette Regex vous est maintenant révélée. C'est un outil précis pour identifier certaines structures textuelles, un peu comme un sort de détection ciblant des glyphes spécifiques dans un ancien manuscrit. Que cette connaissance éclaire vos futures créations !