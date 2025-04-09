<De manière générale :

On peut commencer par extraire une classe, pour avoir accès aux propriétés plus facilement depuis toutes les autres classes qui en ont besoin (les burritos).

######

<class RobotAssembleur:

ligne 58 : on peut passer r.ComposantsStockes.Type == composantsNecessaires.ElementAt(i).Key en constante car on l'utilise plus d'une fois, comme à la ligne 96
ligne 58 : if((r.ComposantsStockes.Type == composantsNecessaires.ElementAt(i).Key) && (r.Quantite >= composantsNecessaires.ElementAt(i).Value))
ligne 60 : on peut passer r.Quantite >= composantsNecessaires.ElementAt(i).Value en constante car on l'utilise plus d'une fois, comme à la ligne 98
on passe de 2 if imbriqués à 1 seul avec un ET logique
ligne 96 : on peut faire une interface?
ligne 107 : on passe le séparateur de ligne en constante
lignes 107 et 108 : on peut passer les messages à afficher dans des constantes
ligne 111 : on passe le séparateur ":" en constante

######

<class RobotEtiqueteur:

ligne 14 : si on déclare le productId à 0 ici, on pourra le passer en index à la ligne 35
ligne 26 : on a une valeur en dur, il vaut mieux la déclarer dans une constante, des fois que le minimum pour un assemblage change
ligne 42 : on peut faire une méthode pour faciliter les éventuels changements dans le programme, si la pyramide change de nom, il suffira d'aller le changer dans la méthode
ligne 45 : on peut faire une méthode pour faciliter les éventuels changements dans le programme, si le cube change de nom, il suffira d'aller le changer dans la méthode
ligne 48 : on peut faire une méthode pour faciliter les éventuels changements dans le programme, si le pavé change de nom, il suffira d'aller le changer dans la méthode
ligne 57 : on peut passer le message à afficher dans une constante, on pourra s'en servir plus facilement

######

<class RobotTrieur:

ligne 24 : si on déclare le productId à 0 ici, on pourra le passer en index à la ligne 35
ligne 33 : on a une valeur en dur, il vaut mieux la déclarer dans une constante
ligne 51 : on a des séparateurs de lignes en dur, 2 d'affilés dans le même Console.Writeline, il vaut mieux faire une constante
ligne 55 : message à afficher en dur, on fait une constante

######

<class Bac:

######

<class Composant:

######

<class Produit:

######

<class Reserve:

######

<class Program:

il faut créer des nouveau objets hors des listes, avec des noms uniques, pour éviter autant de répétitions dans les instances
