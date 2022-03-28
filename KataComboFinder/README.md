Quelques explications sur le fonctionnement d'un moteur de jeu:
Le code de l'execution du jeu pourrait etre:
while (exit)
{
	Update(elapseTime);
	Draw();
}

où Update() pourrait etre:
public void Update(double elapsedTime)
{
	UpdateInput();
	UpdateGamePlay();
	//etc
}


Implementer la detection des mouvements de bases:
- se deplacer a droite
- se deplacer a gauche
- se baisser
- sauter
- coup de poing
- coup de pied

Implementer la reconnaisance du hadoken

Implementer la reconnaisance du hadoken en prenant en compte une durée max pour faire le combo
Effectivement dans les jeux de combats il y a une durée limité pour faire la combinaison de touche

Implementer la reconnaisance du hadoken en prenant en compte la gestion d' "erreur"


