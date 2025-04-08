1) Que va afficher à l'écran le contrôle ci-dessous ? (0,5 pt)
il y aura inscrit Welcome ! dans la zone de texte     0.5


2) Quelle est la différence entre un contrôle <TextBox> et un contrôle <PasswordBox> ? (0,5 pt)
le passwordBox masque les caractères saisis           0.5


3) À quoi sert l'attribut Click d'un contrôle <Button> ? (0,5 pt)
à appeler la méthode qui lui est associée pour déclencher l'évènement       0.5



4) Quelle est la différence entre un contrôle <StackPanel> et un <WrapPanel> ? (0,5pt)
le stack sert à empiler les zones à afficher, le wrap les mets côte à côte      0.5


5) À quoi sert l'attribut Rowspan d'un contrôle <Grid> ? (0,5 pt)
je ne sais pas du tout          ça sert à fusionner des cellules          0



6) Pourquoi le code suivant indique une erreur ? (0,5 pt)
ce n'est pas un nom de balise valide  X       un contrôle ne peut contenir qu'un seul autre controle, à part les panels, qui peuvent être plusieurs



7) Pourquoi le code suivant indique une erreur ? (0,5 pt)
la balise button n'a pas été fermée       0.5



8) Qu'est-ce que le DataContext en WPF ? (0,5 pt)
je ne sais pas      0



9) Que prend en paramètre la méthode File.ReadAllText et que va-t-elle renvoyer(note : on ne veut pas seulement le type mais bien ce que sémantiquement les données en question représentent) ? (0,5 pt)
le fichier à traiter (string), auquel on aura donné le chemin pour y accéder      0
prend un chemin en paramêtre, renvoie un contenu de fichier




10) Que va faire cette méthode ? (0,5 pt)
elle va écrire dans un fichier chaque ligne qui ne commence pas par //        0.5



11, 12 & 13) Voici trois situations où l'on souhaite stocker des données. Indiquez
pour chacune d'elle s'il vaut mieux exporter/importer les données en .csv ou
sérialiser/désérialiser en .json et justifiez votre choix. (0,5 pt par réponse, 1,5 pts en
tout)
<Situation A : Vous travaillez dans un laboratoire de recherche dans le domaine
médical et vos collègues laborantin/e/s vont régulièrement avoir des données à
ajouter ou modifier suite aux différentes expériences qu'ils et elles vont réaliser

je choisirai le format csv, son côté données tabulaires permet facilement de recouper les informations stockées       0.5

<Situation B : Vous développez un logiciel permettant de créer des canaux de
discussions avec ses amis. Un menu permettra aux utilisateurs/trices de choisir des
préférences (par exemple pour les notifications) et il s'agit là des données que l'on
souhaite stocker pour qu'à chaque exécution du programme, les préférences
choisies soient de nouveau appliquées

je choisirai le format json     0.5


<Situation C : Vous développez un logiciel de gestion de comptabilité personnelle. Les
utilisateurs/trices vont y entrer leurs dépenses afin de pouvoir obtenir des
statistiques et gérer leur budget. Nous souhaitons donc que le logiciel stocke toutes
ces dépenses pour qu'à chaque démarrage du logiciel, elles soient de nouveau
présentes

je choisirai le format csv, son côté données tabulaires permet facilement de recouper les informations stockées, idéal pour les utilisateurs non avertis    X
json, données rentrées directement dans le programme, pas dans le fichier directement



14) Que vérifie l'expression régulière suivante : ^[a-zA-Z]{3}$ ? (0,5 pt)
chaîne de 3 lettres, minuscule ou majuscule       0.5



15) Écrivez une expression régulière qui vérifie si une chaîne de caractère ressemble
à une opération mathématique, c'est à dire qu'elle est composée d'un nombre entier
positif, d'un opérateur parmi + - * ou / lui même suivi d'un autre nombre. Il peut y
avoir un ou plusieurs espaces entre chaque nombre et l'opérateur. (0,5 pt)
Voici quelques exemples de chaînes de caractère valides :
^\d+\s*[+\-*\/]\s*\d+$        0.5


16) Que vérifie l'expression régulière suivante : ^(?:\d{2} ){4}\d{2}$ ? (0,5 pt)
commence par 4 fois 2 chiffres avec un espace après les 2 chiffres, fini par 2 chiffres       0.5



5.5

TP A
0 5 8 7 6 7 9 5 7 7
4

TP B


TP C